

namespace MyBehavior
{
    public class Precondition : AttachAction
    {

        public new enum EPhase{
            E_ENTER,
            E_UPDATE,
            E_BOTH
        }
        enum EOperatorType {
            E_INVALID,
            E_ASSIGN,        // =
            E_ADD,           // +
            E_SUB,           // -
            E_MUL,           // *
            E_DIV,           // /
            E_EQUAL,         // ==
            E_NOTEQUAL,      // !=
            E_GREATER,       // >
            E_LESS,          // <
            E_GREATEREQUAL,  // >=
            E_LESSEQUAL      // <=
        };

        private IInstanceMember m_method;
        private EOperatorType m_operator = EOperatorType.E_INVALID;
        public EPhase GetEPhase(){

            return EPhase.E_ENTER;
        }

        protected override void loadMethod(string methodStr)
        {
            Console.WriteLine("PrecondtionLoadMethod");
            this.m_method = AgentMeta.ParseMethod(methodStr);
        }

        protected override bool Execute(Agent pAgent){
            bool bValid = false;
            if (this.m_method != null && this.m_operator == EOperatorType.E_INVALID){
                this.m_method.run(pAgent);
                bValid = true;
            }
            else if (this.m_operator == EOperatorType.E_ASSIGN){
                
            }
        }
    }

}