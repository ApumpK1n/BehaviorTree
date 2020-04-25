

namespace MyBehavior
{
    public class Precondition : AttachAction
    {

        public new enum EPhase{
            E_ENTER,
            E_UPDATE,
            E_BOTH
        }

        public EPhase GetEPhase(){

            return EPhase.E_ENTER;
        }
    }

}