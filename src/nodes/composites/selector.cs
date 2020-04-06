// 按顺序选择一个可以执行的节点


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
    }
}