
using System;

namespace MyBehavior
{
    public class Precondition : AttachAction
    {

        public new enum EPhase{
            E_ENTER,
            E_UPDATE,
            E_BOTH
        }

        private IInstanceMember m_method;
        public EPhase GetEPhase(){

            return EPhase.E_ENTER;
        }

        protected override void loadMethod(string methodStr)
        {
            Console.WriteLine("PrecondtionLoadMethod");
            this.m_method = AgentMeta.ParseMethod(methodStr);
        }

        protected override bool Execute(Agent pAgent){
            bool bValid = true;
            if (this.m_method != null){
                bValid = this.m_method.run(pAgent, ref bValid);
            }
            return bValid;
        }
    }

}