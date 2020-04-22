using System;

namespace MyBehavior
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = "C:\\Users\\Administrator\\Documents\\GitHub\\BehaviorTree\\test\\SecondBT.xml";
            // Xml.LoadXml(path);
            Agent firstAgent = new FirstAgent();
            firstAgent.SetCurrentBT(path);
            Workspace.GetInstance().Update();
        }
    }
}
