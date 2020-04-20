
using System;
using System.Collections.Generic;

namespace MyBehavior{

    public class AgentMeta{

        private Dictionary<string, IInstanceMember> _methods = new Dictionary<string, IInstanceMember>();
        public static Dictionary<string, AgentMeta> agentMetas = new Dictionary<string, AgentMeta>();
        public void RegisterMethod(string methodName, IInstanceMember method){
            _methods.Add(methodName, method);
        }

        public IInstanceMember GetMethod(string methodName){
            if (_methods.ContainsKey(methodName)) return _methods[methodName];
            return null;
        }

        public static AgentMeta GetMeta(string metaName){
            if (agentMetas.ContainsKey(metaName)) return agentMetas[metaName];
            return null;
        }

        public static string ParseMethodName(string valueStr){
            int startMethod = valueStr.IndexOf(':');
            int endMethod = valueStr.IndexOf('(');
            string methodName = "";
            for(int i=startMethod + 1; i < endMethod; i++){
                methodName += valueStr[i];
            }
            return methodName;
        }

        public static string ParseAgentName(string valueStr){
            int startAgent = valueStr.IndexOf('.');
            int endAgent = valueStr.IndexOf(':');
            string agentName = "";
            for(int i=startAgent + 1; i < endAgent; i++){
                agentName += valueStr[i];
            }
            return agentName;
        }
        public static IInstanceMember ParseMethod(string valueStr){
            if (String.IsNullOrEmpty(valueStr)){
                return null;
            }
            string methodName = AgentMeta.ParseMethodName(valueStr);
            string agentName = AgentMeta.ParseAgentName(valueStr);
            AgentMeta meta = AgentMeta.GetMeta(agentName);
            if (meta != null){
                IInstanceMember method = meta.GetMethod(methodName);
                if (method != null) {
                    
                }
                return method;
            }
            return null;
        }
    }
}