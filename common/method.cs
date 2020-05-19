using System;

namespace MyBehavior{

    public class CAgentMethodVoidBase : IInstanceMember{

        public override bool IsMethod(){
            return true;
        }

        public override void run(Agent agent){
            
        }

        public override void run(Agent agent, bool bValid){
        }
    }


    public class CAgentMethodVoid : CAgentMethodVoidBase{
        System.Action<Agent> _run;
        public CAgentMethodVoid(System.Action<Agent> runMethod){
            this._run = runMethod;
        }
        public override void run(Agent agent){
            this._run(agent);
        }
    }

    public class CAgentMethodBool : CAgentMethodVoidBase{
        System.Action<Agent, bool> _run;
        public CAgentMethodBool(System.Action<Agent, bool> runMethod){
            this._run = runMethod;
        }
        public override void run(Agent agent, bool bValid){
            this._run(agent, bValid);
        }
    }
}