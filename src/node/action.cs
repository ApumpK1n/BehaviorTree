

namespace BehaviorTree
{
	public abstract class BehaviorAction : BehaviorNode{

		public enum ActionStatus {
			Ready = 1,
			Running = 2,
		};

		private ActionStatus _status = ActionStatus.Ready;

		public override Phase Tick(){
			Phase result = Phase.S_SUCCESS;
			if (_status == ActionStatus.Ready){
				_status = ActionStatus.Running;
				Enter();
			}
			else if (_status == ActionStatus.Running){
				result = Run();
				if (result != Phase.S_RUNNING){
					_status = ActionStatus.Ready;
					Exit();
				}
			}
			return result;
		}

		public abstract void Enter();

		public abstract Phase Run();

		public abstract void Exit();

		public override void Clear(){
			if (_status != ActionStatus.Ready){
				Exit();
				_status = ActionStatus.Ready;
			}
		}

	}
}