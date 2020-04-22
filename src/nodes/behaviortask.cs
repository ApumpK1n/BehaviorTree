
namespace MyBehavior{

    public class BehaviorTask{

        private BehaviorNode m_node = null;
        private BehaviorTask m_parent = null;
        public virtual void Init(BehaviorNode node){
            this.m_node = node;
        }

        public BehaviorNode GetNode(){
            return this.m_node;
        }

        public void SetParent(BehaviorTask parent){
            this.m_parent = parent;
        }
        public virtual void AddChild(BehaviorTask pTask){

        }

        private EBTStatus m_status = EBTStatus.BT_INVALID;
        public EBTStatus exec(Agent pAgent){
            EBTStatus childStatus = EBTStatus.BT_RUNNING;
            return this.exec(pAgent, childStatus);
        }
        public EBTStatus exec(Agent pAgent, EBTStatus childStatus){
            return this.UpdateCurrent(pAgent, childStatus);
        }

        public EBTStatus UpdateCurrent(Agent pAgent, EBTStatus childStatus){
            EBTStatus s = this.update(pAgent, childStatus);
            return s;
        }

        public virtual EBTStatus update(Agent pAgent, EBTStatus childStatus){
            return EBTStatus.BT_FAILURE;
        }
    }
}