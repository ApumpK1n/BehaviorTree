using System;
using System.Collections.Generic;

namespace MyBehavior{

    public class Parallel : BehaviorNode
    {
        

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