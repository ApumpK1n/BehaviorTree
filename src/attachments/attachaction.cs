

namespace MyBehavior{

    public class AttachAction : BehaviorNode{
        
        public class ActionConfig{

        }

        protected ActionConfig m_ActionConfig;
        public override bool Evaluate(Agent pAgent){
            bool bValid = this.m_ActionConfig.Execute((pAgent);

            if (!bValid){
                EBTStatus childStatus = EBTStatus.BT_INVALID;
            }
            return bValid;
        }
    }
}