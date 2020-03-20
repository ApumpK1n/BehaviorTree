// 条件节点

namespace BehaviorTree
{
	public abstract class BehaviorPrecondition: BehaviorNode{

		public abstract bool Check();
		public override Phase Tick(){
			bool success = Check();
			if (success) return Phase.S_SUCCESS;
			else return Phase.S_FAILURE;
		}
	}
}