using System;
using System.Xml.Linq;
using System.Collections.Generic;


namespace MyBehavior{
    
    public class Xml{
        static string kStrBehavior = "Behavior";
        static string kStrAgentType = "Agenttype";
        static string kStrId = "Id";
        static string kStrPars = "Pars";
        static string kStrPar = "Par";
        static string kStrNode = "Node";
        static string kStrCustom = "Custom";
        static string kStrProperty = "Property";
        static string kStrAttachment = "Attachment";
        static string kStrClass = "Class";
        static string kStrName = "Name";
        static string kStrType = "Type";
        static string kStrValue = "Value";
    // static const char* kEventParam = "eventParam";
        static string kStrVersion = "Version";
        public static void LoadXml(string relativepath){
            XDocument document = XDocument.Load(relativepath);
            //获取到XML的根元素进行操作
            XElement root= document.Root;
            XmlTree xmlTree = new XmlTree();
            RootNode rootNode = new RootNode(kStrBehavior);
            foreach(XElement ele in root.Elements()){
                XmlNode node;
               if (ele.Name == kStrNode){
                   node = new NodeNode(kStrNode);
               }
               else{
                   node = null;
               }


               rootNode.AddNode(node);
            }
        }
    }

}