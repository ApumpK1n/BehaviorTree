
// 按顺序选择一个可以执行的节点
using System;
using System.Collections.Generic;

namespace MyBehavior{

    public class Selector : BehaviorNode{
        

        public override bool Evaluate(Agent pAgent){
            bool ret = true;
            foreach(BehaviorNode child in this.m_children){
                ret = child.Evaluate(pAgent);
                if (ret) break;
            }
            return ret;
        }


        public EBTStatus SelectorUpdate(Agent pAgent, EBTStatus childStatus, int activeChildIndex, List<BehaviorTask> children)
        {   
            EBTStatus result = childStatus;
            for(;;)
            {
                if (result == EBTStatus.BT_RUNNING)
                {
                    BehaviorTask pBehaviorTask = children[activeChildIndex];
                    result = pBehaviorTask.exec(pAgent);
                }
                
                // if child succeed or keep running, do the same.
                if (result != EBTStatus.BT_FAILURE)
                {
                    return result;
                }

                activeChildIndex ++;
                if (activeChildIndex >= children.Count)
                {
                    return EBTStatus.BT_FAILURE;
                }
                result = EBTStatus.BT_RUNNING;
            }

        }

        public override BehaviorTask CreateTask()
        {
            BehaviorTask pBehaviorTask = new SelectorTask();
            return pBehaviorTask;
        }
    }

    public class SelectorTask : CompositeTask
    {

        public override EBTStatus update(Agent pAgent, EBTStatus childStatus)
        {
            Console.WriteLine("SelectorTaskUpdate");
            Selector node = (Selector)this.GetNode();
            EBTStatus result = node.SelectorUpdate(pAgent, childStatus, this.m_activeChildIndex, this.m_children);
            return result;
        }

    }
}