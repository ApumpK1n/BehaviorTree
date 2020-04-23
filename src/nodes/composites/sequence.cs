using System;
using System.Collections.Generic;


namespace MyBehavior{

    public class Sequence : BehaviorNode{


        public override bool Evaluate(Agent pAgent){
            bool ret = true;
            foreach(BehaviorNode child in this.m_children){
                ret = child.Evaluate(pAgent);
                if (!ret) break;
            }
            return ret;
        }
        
        public override BehaviorTask CreateTask()
        {
            BehaviorTask pBehaviorTask = new SequenceTask();
            return pBehaviorTask;
        }

        public EBTStatus SequenceUpdate(Agent pAgent, EBTStatus childStatus, int activeChildIndex, List<BehaviorTask> children)
        {
            EBTStatus result = childStatus;
            for(;;)
            {
                if (result == EBTStatus.BT_RUNNING) 
                {
                    BehaviorTask pBehavior = children[activeChildIndex];
                    result = pBehavior.exec(pAgent);
                }
                // If the child fails, or keeps running, do the same.
                if (result != EBTStatus.BT_SUCCESS) {
                    return result;
                }
                activeChildIndex ++;
                if (activeChildIndex >= children.Count)
                {
                    return EBTStatus.BT_SUCCESS;
                }
                result = EBTStatus.BT_RUNNING;
            }
        }
    }



    public class SequenceTask : CompositeTask
    {
        public override EBTStatus update(Agent pAgent, EBTStatus childStatus)
        {
            Console.WriteLine("SequenceTaskUpdate");
            Sequence node = (Sequence)this.GetNode();
            EBTStatus result = node.SequenceUpdate(pAgent, childStatus, this.m_activeChildIndex, this.m_children);
            return result;
        }
    }
}