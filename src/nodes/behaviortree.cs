
using System;
using System.Xml.Linq;

namespace MyBehavior{
    public class BehaviorTree : BehaviorNode {
        public string Name{ get; private set;}

        public string Version{ get; private set;}
        public string AgentType{ get; private set;}
        public string Domains{ get; set;}

        public bool load_xml(XDocument xDocument){
            XElement xmlBehavior = xDocument.Element(kStrBehavior);
            if (xmlBehavior == null) {
                return false;
            }

             foreach(XAttribute attr in xmlBehavior.Attributes()){
                string Name = attr.Name.LocalName;
                if (Name == kStrVersion) this.Version = attr.Value;
            }

            foreach (XElement treeEle in xmlBehavior.Elements())
            {
                this.ParseFirstNode(treeEle);
                this.load_children(this.AgentType, treeEle);
            }
            return true;
        }

        public void ParseFirstNode(XElement ele){
            if (ele.Name != kStrNode) return;
            foreach(XAttribute attr in ele.Attributes()){
                string Name = attr.Name.LocalName;
                if (Name == kStrClass) this.Name = attr.Value;
                if (Name == kStrAgentType) {
                    this.AgentType = attr.Value;
                }
            }
        }
    }

    public class BehaviorTreeTask : BehaviorTask{
        
        private BehaviorTask m_root = null;
        public override void Init(BehaviorNode node){
            base.Init(node);

            int childrenCount = node.GetChildrenCount();

            if (childrenCount == 1)
            {
                BehaviorNode childNode = node.GetChildByIndex(0);
                BehaviorTask childTask = childNode.CreateAndInitTask();

                this.AddChild(childTask);
            }
        }

        public override void AddChild(BehaviorTask pTask){
            pTask.SetParent(this);
            this.m_root = pTask;
        }
        
        public override EBTStatus update(Agent pAgent, EBTStatus childStatus){
            if (this.m_root == null) return EBTStatus.BT_FAILURE;
            EBTStatus result = this.m_root.exec(pAgent, childStatus);
            return result;
        }
    }
}