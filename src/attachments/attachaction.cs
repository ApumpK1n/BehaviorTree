

namespace MyBehavior{

    public class AttachAction : BehaviorNode{
        
        public override bool Evaluate(Agent pAgent){
            bool bValid = this.Execute(pAgent);

            if (!bValid){
                EBTStatus childStatus = EBTStatus.BT_INVALID;
            }
            return bValid;
        }

        protected virtual bool Execute(Agent pAgent){
            return true;
        }
    }
}