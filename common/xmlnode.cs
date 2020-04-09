using System.Collections.Generic;

namespace MyBehavior{

    public class XmlNode{

        protected string type;

        protected List<XmlNode> children = new List<XmlNode>();

        public void AddNode(XmlNode node){
            if (node != null && !this.children.Contains(node)){
                this.children.Add(node);
            }
        }
        public XmlNode(string type){
            this.type = type;
        }

        public string Type {get;}
    }


    public class RootNode : XmlNode{

        public RootNode(string type) : base(type){

        }

        public string Name { get; set; }

        public string Agenttype { get; set; }
    }

    public class NodeNode : XmlNode{
        public NodeNode(string type) : base(type){
    
        }

        public string ClassName{ get; set;}

        public string Id{ get; set;}


    }

    public class PropertyNode : XmlNode{
        public PropertyNode(string type) : base(type){
    
        }

        public string ClassName{ get; set;}

        public string Id{ get; set;}


    }
}