// 选择节点


namespace BehaviorTree{
	public class BehaviorSelector : BehaviorNode{

		public BehaviorSelector (BehaviorPrecondition precondition = null) : base (precondition) {}

		private BehaviorNode _selectNode;
		public override bool Evaluate(){
			foreach (BehaviorNode child in children){
				if (child.IsEvaluate()) {
					_selectNode = child;
					return true;
				}
			}
			_selectNode = null;
			return false;
		}

		public override Phase Tick(){
			if (_selectNode == null) return Phase.S_FAILURE;
			return _selectNode.Tick();
		}

		public override void Clear(){
			if (_selectNode != null) {
				_selectNode.Clear();
				_selectNode = null;
			}
		}
	}
}