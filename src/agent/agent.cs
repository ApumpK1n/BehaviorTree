using System;

namespace MyBehavior{


    public class Agent {

        private BehaviorTask m_currentBT = null;
        private bool m_bActive = true;
        public Agent(){
            this.Create();
        }

        public void Create(){
            Workspace.GetInstance().AddAgent(this.GetType().Name, this);
        }

        public void SetCurrentBT(string relativePath){
            if (String.IsNullOrEmpty(relativePath)){
                throw new Exception("relativePath is null!");
            }
            BehaviorTreeTask pTask = Workspace.GetInstance().CreateBehaviorTreeTask(relativePath);
            this._setCurrentTreeTask(pTask);
        }

        private void _setCurrentTreeTask(BehaviorTask pTask){
            this.m_currentBT = pTask;
       }


        public EBTStatus btExec(){
            if (this.m_bActive){
                EBTStatus status = this._btExec();
                return status;
            }
            return EBTStatus.BT_INVALID;
        }

        private EBTStatus _btExec(){
            if (this.m_currentBT == null) return EBTStatus.BT_INVALID;
            EBTStatus status = this.m_currentBT.exec(this);
            Console.WriteLine("_btExec");
            return status;
        }
    }
}