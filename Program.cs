using System;

namespace MyBehavior
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = "C:\\Users\\Administrator\\Documents\\GitHub\\BehaviorTree\\test\\FirstBT.xml";
            // Xml.LoadXml(path);
            Workspace.GetInstance().Load(path);
            Agent firstAgent = new FirstAgent();
            firstAgent
        }
    }
}
