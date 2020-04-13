
using System.Collections.Generic;
using System;


namespace MyBehavior{

    public class Factory{

        public static BehaviorNode Create(string className){
            Type type = Type.GetType(className);
            if (type != null)
                return (BehaviorNode)Activator.CreateInstance(type);
            return null;
        }
    }
}