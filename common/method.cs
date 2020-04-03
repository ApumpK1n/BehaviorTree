using System;

namespace MyBehavior{

    public class CAgentMethodVoidBase : IInstanceMember{

        public override bool IsMethod(){
            return true;
        }

        public override void run(Agent agent){

        } 
    }


    public class CAgentMethodVoid : CAgentMethodVoidBase{
        Action _run;

        CAgentMethodVoid(Action runMethod){
            this._run = runMethod;
        }
        public override void run(Agent agent){
            this._run(agent);
        }
    }
}