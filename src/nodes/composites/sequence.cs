

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
    }
}