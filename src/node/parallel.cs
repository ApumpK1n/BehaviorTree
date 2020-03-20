// 平行节点，同时执行所有子节点。

using System.Collections.Generic;

namespace BehaviorTree{

	public class BehaviorParallel : BehaviorNode{
		protected ResultType _type;
		public enum ResultType {
			And = 1,
			Or = 2
		};

		public ResultType Type {get; set;}

		public BehaviorParallel (ResultType type, BehaviorPrecondition precondition) : base (precondition){
			this._type = type;
		}
		public override bool Evaluate(){
			foreach (BehaviorNode child in children){
				if(!child.IsEvaluate()){ // 任一子结点的准入条件失败
					return false;
				}
			}
			return true;
		}

		public override Phase Tick(){
			if (!Evaluate()) return Phase.S_FAILURE;
			int failCount = 0;
			foreach(BehaviorNode child in children){
				Phase result = child.Tick();
				if (result == Phase.S_FAILURE) failCount += 1;
			}
			int CompareNum = 0;
			if (this.Type == ResultType.And) CompareNum = children.Count;
			else CompareNum = 1;
				
			if (failCount >= CompareNum) return Phase.S_FAILURE;
			else return Phase.S_SUCCESS;
			}
		
		public override void Clear(){
			foreach (BehaviorNode child in children) child.Clear();
		}
	}

}
