
using System.Collections.Generic;

namespace MyBehavior{

    public class AgentMeta{

        private Dictionary<int, IInstanceMember> _methods;
        public void RegisterMethod(int methodId, IInstanceMember method){
            _methods.Add(methodId, method);
        }

        public IInstanceMember GetMethod(int methodId){
            if (_methods.ContainsKey(methodId)) return _methods[methodId];
            return null;
        }
    }
}