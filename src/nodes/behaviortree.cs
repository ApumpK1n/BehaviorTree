
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
            Console.WriteLine(xDocument);
            if (xmlBehavior == null) {
                return false;
            }

             foreach(XAttribute attr in xmlBehavior.Attributes()){
                string Name = attr.Name.LocalName;
                if (Name == kStrVersion) this.Version = attr.Value;
            }

            int Count = 0;
            foreach(XElement ele in xmlBehavior.Elements()){
                Console.WriteLine(ele.Name);
                if (Count == 0) {
                    Count += 1;
                    this.ParseFirstNode(ele);
                }
                this.ParseChildren(ele, this);

                break;
            }

            return true;
        }

        public void ParseFirstNode(XElement ele){
            if (ele.Name != kStrNode) return;
            foreach(XAttribute attr in ele.Attributes()){
                string Name = attr.Name.LocalName;
                if (Name == kStrClass) this.Name = attr.Value;
                if (Name == kStrAgentType) this.AgentType = attr.Value;
            }

        }

        public void ParseChildren(XElement xmlEle, BehaviorNode parent){
            foreach(XElement ele in xmlEle.Elements()){
                string elmentName = ele.Name.LocalName;
                if (elmentName == kStrNode){
                    foreach(XAttribute attr in ele.Attributes()){
                        string Name = attr.Name.LocalName;
                        if (Name == kStrClass) node.ClassName = attr.Value;
                        if (Name == kStrId) node.Id = attr.Value;
                    }
                    parent.AddNode(node);
                }
                else if (elmentName == kStrProperty){
                    PropertyNode node = new PropertyNode(kStrProperty);
                    foreach(XAttribute attr in ele.Attributes()){
                        string Name = attr.Name.LocalName;
                        if (Name == kStrClass) node.ClassName = attr.Value;
                        if (Name == kStrId) node.Id = attr.Value;
                    }
                }
                else{
                    
                }
            }
        }
        public void load_properties_pars_attachments_children(string agentType, XmlNode node){

        }
    }
}