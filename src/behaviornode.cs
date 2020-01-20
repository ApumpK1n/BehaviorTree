


namespace BehaviorTree
{
	class BehaviorNode
	{
		public enum Phase //节点状态
		{
			S_SUCCESS,
			S_FAILURE,
			S_BOTH
		};

		public static void Register<T>() where T: BehaviorNode
		{
			//Factory().Register<T>();
		}
		public static void UnRegister<T>() where T: BehaviorNode
		{
			//Factory().UnRegister<T>();
		}

		
	}
}
