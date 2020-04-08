using System.Collections.Generic;

namespace MyBehavior{

    public class XmlNode{

        protected string type;

        protected List<XmlNode> children = new List<XmlNode>();
        public XmlNode GetRoot(){
            return root;
        }

        public void AddNode(XmlNode node){
            if (node != null && !this.children.Contains(node)){
                this.children.Add(node);
            }
        }

        public XmlNode(string type){
            this.type = type;
        }
    }


    public class RootNode : XmlNode{

        public RootNode(string type) : base(type){

        }
    }

    public class NodeNode : XmlNode{
         public NodeNode(string type) : base(type){

        }
    }
}