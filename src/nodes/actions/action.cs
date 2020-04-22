using System;

namespace MyBehavior
{
    public class Action : BehaviorNode
    {
        protected IInstanceMember m_method;
        protected EBTStatus m_resultOption;
        
        protected override void loadMethod(string methodStr){
            this.m_method = AgentMeta.ParseMethod(methodStr);
            
        }
        public EBTStatus Execute(Agent pAgent, EBTStatus childStatus){
            Console.WriteLine("ActionExecute");
            EBTStatus result = EBTStatus.BT_SUCCESS;
            if (this.m_method != null){
                if (this.m_resultOption != EBTStatus.BT_INVALID){
                    this.m_method.run(pAgent);
                    result = this.m_resultOption;
                }
                else{

                }
            }
            return result;
        }
        
    }

    public class ActionTask : BehaviorTask{

        public override EBTStatus update(Agent pAgent, EBTStatus childStatus){
            Console.WriteLine("ActionTaskUpdate");
            Action pActionNode = (Action)this.GetNode();
            EBTStatus result = pActionNode.Execute(pAgent, childStatus);
            return result;
        }
    }
}