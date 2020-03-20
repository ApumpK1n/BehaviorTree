
using System.Collections.Generic;

namespace BehaviorTree
{
	public abstract class BehaviorNode
	{
		public enum Phase //节点状态
		{
			S_SUCCESS,
			S_FAILURE,
			S_RUNNING,
		};
		public BehaviorNode(){
			this.precondition = null;
		}
		public BehaviorNode(BehaviorPrecondition precondition){
			this.precondition = precondition;
		}
		protected List<BehaviorNode> _children;
		
		public List<BehaviorNode> children {get{return _children;}}

		public bool active;
		public BehaviorPrecondition precondition;
		public abstract Phase Tick();// 执行

		public virtual bool Evaluate(){ return true;} // 提供子类自定义检查

		public bool IsEvaluate(){
			return active && (precondition == null || precondition.Check()) && Evaluate();
		}

		public virtual void Clear(){}

		public virtual void AddChild(BehaviorNode node){
			if (_children == null) _children = new List<BehaviorNode>();
			if (node != null) _children.Add(node);
		}

		public virtual void RemoveChild(BehaviorNode node){
			if (_children != null && node != null) _children.Remove(node);
		}

	}
}
