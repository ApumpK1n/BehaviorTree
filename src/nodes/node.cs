
using System.Collections.Generic;
using System.Xml.Linq;
using System;

namespace MyBehavior{

    public enum EBTStatus {
        BT_INVALID,
        BT_SUCCESS,
        BT_FAILURE,
        BT_RUNNING,
    };

    public class BehaviorNode{

        public static string kStrBehavior = "Behavior";
        public static string kStrNode = "Node";
        public static string kStrAgentType = "Agenttype";
        public static string kStrId = "Id";
        public static string kStrPars = "pars";
        public static string kStrPar = "par";
        public static string kStrCustom = "custom";
        public static string kStrProperty = "property";
        public static string kStrAttachment = "attachment";
        public static string kStrClass = "Class";
        public static string kStrName = "Name";
        public static string kStrType = "type";
        public static string kStrValue = "value";
        public static string kStrVersion = "Version";
        public static string KStrConnector = "Connector";
        public static string KStrMethod = "Method";
        protected bool m_bHasEvents;
        protected List<BehaviorNode> m_children = new List<BehaviorNode>();
        protected List<BehaviorNode> m_preconditions = new List<BehaviorNode>();
        protected BehaviorNode m_parent;
        protected BehaviorNode m_customCondition;

        private string m_agentType;
        private string m_className;
        private Int16 m_id;
        private List<BehaviorNode> m_effectors = new List<BehaviorNode>();
        private List<BehaviorNode> m_events = new List<BehaviorNode>();

        public enum EPhase {
            E_SUCCESS,
            E_FAILURE,
            E_BOTH
        };

        private void SetClassName(string className){
            this.m_className = className;
        }
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
    
        public virtual bool CheckPreconditions(Agent pAgent, bool IsActive){
            
            return true;
        }

        public virtual void ApplyEffects(){

        }

        public bool CheckEvents(string eventName){
            return true;
        }

        public virtual void Attach(){

        }

        public virtual bool Evaluate(Agent pAgent){
            return false;
        }

        public virtual bool IsManagingChildrenAsSubTrees(){
            return false;
        }

        public void load_children(string agentType, XElement parent){ // elementChild
            this.SetAgentType(agentType);
            foreach(XElement nodeEle in parent.Elements()){
                string elementName = nodeEle.Name.LocalName;
                if (elementName == kStrNode){
                    BehaviorNode pBehaviorNode = BehaviorNode.load(agentType, nodeEle);
                    Console.WriteLine(String.Format("ABehaviorNode {0}", pBehaviorNode.ToString()));
                    Console.WriteLine(string.Format("parentNode, {0}", this.ToString()));
                    this.AddChild(pBehaviorNode);
                }
                // if (StringUtils::StringEqual(c->name(), kStrAttachment)) {
                //     bHasEvents |= this->load_attachment(version, agentType, bHasEvents, c);
                
                }
        }

        protected virtual void loadMethod(string methodStr){

        }

        public static BehaviorNode load(string agentType, XElement ele){
            XAttribute attr = ele.Attribute(kStrClass);
            string className = attr.Value;
            BehaviorNode pBehaviorNode = Factory.Create(className);
            if (pBehaviorNode == null) {
                Console.WriteLine(String.Format("invalid node class {0} /n" , className));
            }
            Console.WriteLine(pBehaviorNode.ToString());
            pBehaviorNode.SetClassName(className);
            pBehaviorNode.load_properties(ele);
            pBehaviorNode.load_children(agentType, ele);
            return pBehaviorNode;
            // foreach(XAttribute attr in ele.Attributes()){
            //     string Name = attr.Name.LocalName;
            //     if (Name == kStrClass) {
            //         .SetClassName(Name);
            //     //if (Name == kStrId) node.Id = attr.Value;
            //     }
            // }
        }
    
        protected void load_properties(XElement eleNode){
            foreach(XAttribute attr in eleNode.Attributes()){
                if (attr.Name.LocalName == KStrMethod){
                    this.loadMethod(attr.Value);
                }
            }
        }

        protected virtual void AddChild(BehaviorNode pChild){
            if (pChild != null){
                pChild.m_parent = this;
                this.m_children.Add(pChild);
            }
        }

        protected void SetAgentType(string agentType){
            this.m_agentType = agentType;
        }

        protected bool EvaluteCustomCondition(){
            // if (this.m_customCondition != null){
            //     return this.m_customCondition.Evaluate();
            // }
            return false;
        }

        protected void SetCustomCondition(BehaviorNode node){
            this.m_customCondition = node;
        }


        public virtual BehaviorTask CreateTask(){
            BehaviorTask pBehaviorTask = new BehaviorTask();
            return pBehaviorTask;
        }

        public BehaviorTask CreateAndInitTask(){
            BehaviorTask pTask = this.CreateTask();
            pTask.Init(this);
            return pTask;
        }

    }

    public class DecoratorNode : BehaviorNode{

        protected bool m_bDecorateWhenChildEnds;

    }


}