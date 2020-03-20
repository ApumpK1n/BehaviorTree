//序列节点

namespace BehaviorTree{
	
	public class BehaviorSequence : BehaviorNode{

		public BehaviorSequence (BehaviorPrecondition precondition = null) : base (precondition) {}

		public override bool Evaluate(){
			bool ret = true;
			foreach (BehaviorNode child in children){
				ret = child.IsEvaluate();
				if (!ret) break;
			}
			return ret;
		}

		public override Phase Tick(){
			Phase ret = Phase.S_SUCCESS;
			int index = 0;
			for(;;){
				BehaviorNode child = children[index];
				if (child.Tick() == Phase.S_FAILURE) return Phase.S_FAILURE;
				++index;
				if (index >= children.Count) return Phase.S_SUCCESS;
				ret = Phase.S_RUNNING;
			}
			return ret;
		}

		public override void Clear(){
			foreach (BehaviorNode child in children) child.Clear();
		}

	}
}