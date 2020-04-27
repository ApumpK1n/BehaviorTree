using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MyBehavior{

    public class Parallel : BehaviorNode
    {
        const string FailurePolicy = "FailurePolicy";
        const string SuccessPolicy = "SuccessPolicy";
        enum EFAILURE_POLICY {
            FAIL_ON_ONE,
            FAIL_ON_ALL
        };

        enum ESUCCESS_POLICY {
            SUCCEED_ON_ONE,
            SUCCEED_ON_ALL
        };
    
        private EFAILURE_POLICY m_failPolicy = EFAILURE_POLICY.FAIL_ON_ONE;
        private ESUCCESS_POLICY m_succeedPolicy = ESUCCESS_POLICY.SUCCEED_ON_ONE;
        protected  override void loadProperties(XAttribute attr){
            string name = attr.Name.LocalName;
            if (name == FailurePolicy)
            {
                if (attr.Value == "FAIL_ON_ONE"){
                    this.m_failPolicy = EFAILURE_POLICY.FAIL_ON_ONE;
                }
                else if (attr.Value == "FAIL_ON_ALL"){
                    this.m_failPolicy = EFAILURE_POLICY.FAIL_ON_ALL;
                }
            }
            else if (name == SuccessPolicy){
                if (attr.Value == "SUCCEED_ON_ONE"){
                    this.m_succeedPolicy = ESUCCESS_POLICY.SUCCEED_ON_ONE;
                }
                else if (attr.Value == "SUCCEED_ON_ALL"){
                    this.m_succeedPolicy = ESUCCESS_POLICY.SUCCEED_ON_ALL;
                }
            }
            
        }   

        public override BehaviorTask CreateTask()
        {
            BehaviorTask pBehaviorTask = new ParallelTask();
            return pBehaviorTask;
        }

        public EBTStatus ParallelUpdate(Agent pAgent, List<BehaviorTask> children)
        {
            bool sawSuccess = false;
            bool sawFail = false;
            bool sawRunning = false;
            bool sawAllFails = true;
            bool sawAllSuccess = true;

            for (int i = 0; i < children.Count; i++){
                BehaviorTask pChild = children[i];
                EBTStatus treeStatus = pChild.GetStatus();
                if (treeStatus == EBTStatus.BT_RUNNING || treeStatus == EBTStatus.BT_INVALID)
                {
                    EBTStatus status = pChild.exec(pAgent);
                    if (status == EBTStatus.BT_FAILURE)
                    {
                        sawFail = true;
                        sawAllSuccess = false;
                    }
                    else if (status == EBTStatus.BT_SUCCESS)
                    {
                        sawSuccess = true;
                        sawAllFails = false;
                    }
                    else if (status == EBTStatus.BT_RUNNING)
                    {
                        sawRunning = true;
                        sawAllFails = false;
                        sawAllSuccess = false;
                    }
                }
                else if (treeStatus == EBTStatus.BT_SUCCESS)
                {
                    sawSuccess = true;
                    sawAllFails = false;
                }
                else{
                    sawFail = true;
                    sawAllSuccess = false;
                }
            }

            EBTStatus result = sawRunning ? EBTStatus.BT_RUNNING : EBTStatus.BT_FAILURE;
            
            if ((this.m_failPolicy == EFAILURE_POLICY.FAIL_ON_ALL && sawAllFails)||
                (this.m_failPolicy == EFAILURE_POLICY.FAIL_ON_ONE && sawFail)){
                    result = EBTStatus.BT_FAILURE;
            }
            else if ((this.m_succeedPolicy == ESUCCESS_POLICY.SUCCEED_ON_ALL && sawAllSuccess) ||
                    (this.m_succeedPolicy == ESUCCESS_POLICY.SUCCEED_ON_ONE && sawSuccess)){
                        result = EBTStatus.BT_SUCCESS;
                    }
            Console.WriteLine("22222" + result);
            return result;
        }

    }


    public class ParallelTask : CompositeTask 
    {
        public override EBTStatus update(Agent pAgent, EBTStatus childStatus)
        {
            Console.WriteLine("ParallelTaskUpdate");
            Parallel node = (Parallel)this.GetNode();
            EBTStatus result = node.ParallelUpdate(pAgent, this.m_children);
            return result;
        }
    }
}