using System;
using System.Xml.Linq;
using System.Collections.Generic;


namespace MyBehavior{
    
    public class Xml{
        static string kStrBehavior = "behavior";
        static string kStrAgentType = "agenttype";
        static string kStrId = "id";
        static string kStrPars = "pars";
        static string kStrPar = "par";
        static string kStrNode = "node";
        static string kStrCustom = "custom";
        static string kStrProperty = "property";
        static string kStrAttachment = "attachment";
        static string kStrClass = "class";
        static string kStrName = "name";
        static string kStrType = "type";
        static string kStrValue = "value";
    // static const char* kEventParam = "eventParam";
        static string kStrVersion = "version";
        public static void LoadXml(){
            XDocument document = XDocument.Load("D:\\123.xml");
            //获取到XML的根元素进行操作
            XElement root= document.Root;
            XElement ele= root.Element("BOOK");
            //获取name标签的值
            XElement shuxing= ele.Element("name");
            Console.WriteLine(shuxing.Value);
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                foreach (XElement item1 in item.Elements())
                {
                    Console.WriteLine(item1.Name);   //输出 name  name1            
                }
                Console.WriteLine(item.Attribute("id").Value);  //输出20
            }   
            Console.ReadKey();
        }
    }
    
    public class XmlNode{
        
    }

}