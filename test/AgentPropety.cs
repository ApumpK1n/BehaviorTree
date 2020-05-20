using System;
using System.Reflection;

namespace MyBehavior
{
    public class BehaviorLoaderImplement : BehaviorLoader
    {

        public override bool Load(){
            

            Console.WriteLine("LOoooooooooooooad");
            // FirstAgent
            AgentMeta meta = new AgentMeta();
            AgentMeta.agentMetas["FirstAgent"] = meta;
            
            String methodName ="SayHello";
            // Type type = this.GetType();
            // MethodInfo method = type.GetMethod(methodName);
            meta.RegisterMethod(methodName, new CAgentMethodVoid(delegate(Agent self){((FirstAgent)self).SayHello();}));

            string methodNameEnter = "CanEnterAction";
            meta.RegisterMethod(methodNameEnter, new CAgentMethodBool(delegate(Agent self){return ((FirstAgent)self).CanEnterAction();}));
            return true;
        }
    }

}
 