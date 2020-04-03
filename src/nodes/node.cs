
using System.Collections.Generic;
using System;

namespace MyBehavior{

    public enum EBTStatus {
        BT_INVALID,
        BT_SUCCESS,
        BT_FAILURE,
        BT_RUNNING,
    };

    public class BehaviorNode{

        protected bool m_bHasEvents;
        protected List<BehaviorNode> m_children;
        protected List<BehaviorNode> m_preconditions;
        protected BehaviorNode m_parent;
        protected BehaviorNode m_customCondition;

        private string m_agentType;
        private string m_className;
        private Int16 m_id;
        private List<BehaviorNode> m_effectors;
        private List<BehaviorNode> m_events;

        public enum EPhase {
            E_SUCCESS,
            E_FAILURE,
            E_BOTH
        };

        public static bool Register<T> () where T: BehaviorNode
        {
            return true;
        }

        public static void UnRegister<T>() where T: BehaviorNode{

        }

        // public static BehaviorNode Create(string className){
        //     BehaviorNode pBehaviorNode = Factory()>.CreateObj(className);
        //     return pBehaviorNode;
        // }
        
        // public static BehaviorNode Load(string agentType, string className){
        //     BehaviorNode pBehaviorNode = BehaviorNode.Create(className);
        //     return pBehaviorNode;
        // }

        public static void Cleanup(){

        }

        // public static void CombineResults(Precondition pPrecondition){

        // }

        // public BehaviorTask CreateAndInitTask(){
            
        // }

        public bool HasEvents(){
            return this.m_bHasEvents;
        }

        public void SetHasEvents(bool hasEvents){
            this.m_bHasEvents = hasEvents;
        }

        public Int32 GetChildrenCount(){
            if (this.m_children != null){
                return this.m_children.Count;
            }
            return 0;
        }

        public BehaviorNode GetChildByIndex(Int32 index){
            if (this.m_children != null && index < this.m_children.Count){
                return this.m_children[index];
            }
            return null;
        }

        public BehaviorNode GetParent(){
            return this.m_parent;
        }

        public void Clear(){
            if (this.m_children != null){
                for (int i=0; i < this.m_children.Count; ++i){
                    BehaviorNode pChild = this.m_children[i];
                    // 刪除child
                }
                this.m_children.Clear();
                this.m_children = null;
            }

            if (this.m_customCondition != null){
                // 刪除
                this.m_customCondition = null;
            }

            for (int i = 0; i < this.m_preconditions.Count; i++){
                if (this.m_preconditions[i] != null){
                    //delete
                    this.m_preconditions[i] = null;
                }
            }

            for (int i = 0; i < this.m_effectors.Count; ++i) {
                if (this.m_effectors[i] != null) {
                    //BEHAVIAC_DELETE m_effectors[i];
                    this.m_effectors[i] = null;
                }
            }

            for (int i = 0; i < this.m_events.Count; ++i) {
                if (this.m_events[i] != null) {
                    //BEHAVIAC_DELETE m_events[i];
                    this.m_events[i] = null;
                }
            }
        }
    
        public virtual bool CheckPreconditions(){
            return true;
        }

        public virtual void ApplyEffects(){

        }

        public bool CheckEvents(string eventName){
            return true;
        }

        public virtual void Attach(){

        }

        public virtual bool Evaluate(){
            return false;
        }

        public virtual bool IsManagingChildrenAsSubTrees(){
            return false;
        }

        protected virtual void load(string agentType, XmlNode node){
            
        }
    
        protected void load_properties(){

        }

        protected virtual void AddChild(BehaviorNode pChild){
            pChild.m_parent = this;
            this.m_children.Add(pChild);
        }

        protected void SetAgentType(string agentType){
            this.m_agentType = agentType;
        }

        protected bool EvaluteCustomCondition(){
            if (this.m_customCondition != null){
                return this.m_customCondition.Evaluate();
            }
            return false;
        }

        protected void SetCustomCondition(BehaviorNode node){
            this.m_customCondition = node;
        }


        // private virtual BehaviorTask CreateTask(){

        // }

    }

    public class DecoratorNode : BehaviorNode{

        protected bool m_bDecorateWhenChildEnds;

    }


}