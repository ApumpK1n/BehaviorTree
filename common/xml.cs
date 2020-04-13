using System;
using System.Xml.Linq;
using System.Collections.Generic;


namespace MyBehavior{
    
    public class Xml{
        public static string kStrBehavior = "Behavior";
        public static string kStrNode = "Node";
        public static string kStrAgentType = "Agenttype";
        public static string kStrId = "id";
        public static string kStrPars = "pars";
        public static string kStrPar = "par";
        public static string kStrCustom = "custom";
        public static string kStrProperty = "property";
        public static string kStrAttachment = "attachment";
        public static string kStrClass = "class";
        public static string kStrName = "name";
        public static string kStrType = "type";
        public static string kStrValue = "value";
    // static const char* kEventParam = "eventParam";
        public static string kStrVersion = "version";
        public static void LoadXml(string relativepath){
            XDocument document = XDocument.Load(relativepath);
            XElement xmlBehavior = document.Element(kStrBehavior);
            RootNode rootNode = new RootNode(kStrBehavior);
            foreach(XAttribute attr in xmlBehavior.Attributes()){
                string Name = attr.Name.LocalName;
                if (Name == kStrName) rootNode.Name = attr.Value;
                if (Name == kStrAgentType) rootNode.Agenttype = attr.Value;
            }
            ParseNode(xmlBehavior, rootNode);
        }

        public static void ParseNode(XElement xmlEle, XmlNode parent){
            foreach(XElement ele in xmlEle.Elements()){
                string elmentName = ele.Name.LocalName;
                if (elmentName == kStrNode){
                    NodeNode node = new NodeNode(kStrNode);
                    foreach(XAttribute attr in ele.Attributes()){
                        string Name = attr.Name.LocalName;
                        if (Name == kStrClass) node.ClassName = attr.Value;
                        if (Name == kStrId) node.Id = attr.Value;
                    }
                    ParseNode(ele, node);
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
    }

}