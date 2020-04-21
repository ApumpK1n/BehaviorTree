

namespace BehaviorTree{
	
	public class BehaviorTree{
		protected BehaviorNode _root = null;

		public void Awake(){

		}

		public void SetRoot(BehaviorNode root){
			_root = root;
		}

		public void Update(){
			if (_root == null) return;
			if(_root.IsEvaluate()) _root.Tick();
		}

		public void OnDestroy(){
			if (_root != null) _root.Clear();
		}

		public void ResetBehaviorTree(){
			if (_root != null) _root.Clear();
		}
	}
}