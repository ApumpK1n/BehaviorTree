using System;

namespace MyBehavior
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = "C:/Users/Administrator/Documents/GitHub/BehaviorTree/test/test.xml";
            Xml.LoadXml(path);
        }
    }
}
