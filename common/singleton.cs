
using System;

namespace MyBehavior{
    public class Singleton<T> where T : class, new()
    {
        private static T s_instance;
        public static T Instance
        {
            get
            {
                if (s_instance == null) CreateInstance();
                return s_instance;
            }
        }
        public static void CreateInstance()
        {
            if (s_instance == null)
            {
                s_instance = Activator.CreateInstance<T>();
                (s_instance as Singleton<T>).Init();
            }
        }
        public static void DestroyInstance()
        {
            if (s_instance != null)
            {
                (s_instance as Singleton<T>).UnInit();
                s_instance = (T)((object)null);
            }
        }
        public static T GetInstance()
        {
            if (s_instance == null) CreateInstance();
            return s_instance;
        }
        public virtual void Init()
        {
        }
      
        public virtual void UnInit()
        {
        }
    }
}
