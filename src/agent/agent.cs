

namespace MyBehavior{


    public class Agent {

        public Agent(){
            this.Create();
        }

        public void Create(){
            Workspace.GetInstance().AddAgent(this.GetType().Name, this);
        }
    }
}