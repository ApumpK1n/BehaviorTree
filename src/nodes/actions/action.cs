using System;

namespace MyBehavior
{
    public class Action : BehaviorNode
    {
        protected IInstanceMember m_method;
        
        protected override void loadMethod(string methodStr)
        {
            Console.WriteLine("LoadMethod:"+methodStr);
            this.m_method = AgentMeta.ParseMethod(methodStr);
            
        }

        public EBTStatus Execute(Agent pAgent, EBTStatus childStatus)
        {
            EBTStatus result = EBTStatus.BT_SUCCESS;
            if (this.m_method != null){                   
                this.m_method.run(pAgent);
            }
            
            return result;
        }
        
        public override BehaviorTask CreateTask()
        {
            BehaviorTask pBehaviorTask = new ActionTask();
            return pBehaviorTask;
        }

    }

    public class ActionTask : BehaviorTask{

        public override EBTStatus update(Agent pAgent, EBTStatus childStatus)
        {
            Console.WriteLine("ActionTaskUpdate");
            Action pActionNode = (Action)this.GetNode();
            EBTStatus result = pActionNode.Execute(pAgent, childStatus);
            return result;
        }
    }
}