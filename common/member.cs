

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
    }
}