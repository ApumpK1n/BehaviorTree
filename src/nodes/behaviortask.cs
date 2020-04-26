using System.Collections.Generic;

namespace MyBehavior{

    public class BehaviorTask{

        private BehaviorNode m_node = null;
        private BehaviorTask m_parent = null;
        private EBTStatus m_status = EBTStatus.BT_INVALID;
        public virtual void Init(BehaviorNode node){
            this.m_node = node;
        }

        public BehaviorNode GetNode(){
            return this.m_node;
        }

        public EBTStatus GetStatus(){
            return this.m_status;
        }

        public void SetParent(BehaviorTask parent){
            this.m_parent = parent;
        }
        public virtual void AddChild(BehaviorTask pTask){

        }

        public EBTStatus exec(Agent pAgent){
            EBTStatus childStatus = EBTStatus.BT_RUNNING;
            return this.exec(pAgent, childStatus);
        }
        public EBTStatus exec(Agent pAgent, EBTStatus childStatus){
            bool bEnterResult = false;

            if (this.m_status == EBTStatus.BT_RUNNING) {
                bEnterResult = true;
            } else {
                //reset it to invalid when it was success/failure
                this.m_status = EBTStatus.BT_INVALID;

                bEnterResult = this.CanEnterAction(pAgent);
            }
            if (bEnterResult){
                this.m_status =  this.UpdateCurrent(pAgent, childStatus);
            }
            
            return this.m_status;
        }

        private bool CanEnterAction(Agent pAgent)
        {
            bool bResult = this.CheckPreconditions(pAgent, false);
            if (bResult)
            {
                bResult = this.onEnter(pAgent);
            }
            return bResult;
        }

        protected virtual bool onEnter(Agent pAgent)
        {
            return true;
        }

        private bool CheckPreconditions(Agent pAgent, bool bIsActive){
            bool bResult = true;
            if (this.m_node != null){
                bResult = this.m_node.CheckPreconditions(pAgent, bIsActive);
            }
            return bResult;
        }

        public EBTStatus UpdateCurrent(Agent pAgent, EBTStatus childStatus){
            EBTStatus s = this.update(pAgent, childStatus);
            return s;
        }

        public virtual EBTStatus update(Agent pAgent, EBTStatus childStatus){
            return EBTStatus.BT_FAILURE;
        }
    }



    public class CompositeTask : BehaviorTask
    {
        public int m_activeChildIndex = 0;
        public List<BehaviorTask> m_children = new List<BehaviorTask>();
    
        public override void AddChild(BehaviorTask pTask){
            pTask.SetParent(this);
            this.m_children.Add(pTask);;
        }

        public override void Init(BehaviorNode node){
            base.Init(node);
            int childrenCount = node.GetChildrenCount();
            for (int i = 0; i < childrenCount; i++)
            {
                BehaviorNode childNode = node.GetChildByIndex(0);
                BehaviorTask childTask = childNode.CreateAndInitTask();
                
                this.AddChild(childTask);
            }
        }
    }
}