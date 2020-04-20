using Newtonsoft.Json;

namespace MyBehavior{

    public class IInstanceMember{

        protected static int kInstanceNameMax = 128;

        public virtual int GetClassTypeNumberId(){
            return 0;
        }

        public virtual int GetCount(Agent agent){
            return 0;
        }

        public virtual bool IsMethod(){
            return false;
        }

        public virtual void run(Agent agent) {
        }

        public IInstanceMember CloneJson()
        {
            // Don't serialize a null object, simply return the default for that object
            var deserializeSettings = new JsonSerializerSettings {ObjectCreationHandling = ObjectCreationHandling.Replace};
            return JsonConvert.DeserializeObject<IInstanceMember>(JsonConvert.SerializeObject(this), deserializeSettings);
        }
    }
}