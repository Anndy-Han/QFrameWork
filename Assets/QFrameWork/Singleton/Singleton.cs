using System;
using System.Reflection;
using UnityEngine;

namespace QFrameWork
{
    public abstract class QSingleton<T> : ISingleton where T:QSingleton<T>
    {
        protected static T instance;

        protected QSingleton()
        {

        }

        public static T Instance()
        {
            if (instance == null)
            {

                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                    throw new Exception("Non-public ctor() not found!");

                instance = ctor.Invoke(null) as T;
            }

            return instance;
        }

        public void InitSingleton()
        {
            
        }
    }

    public abstract class QMonoSingleton<T> : MonoBehaviour, ISingleton where T : QMonoSingleton<T>
    {
        protected static T instance;

        public static T Instance()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (FindObjectsOfType<T>().Length > 1)
                {
                    return instance;
                }

                if (instance == null)
                {
                    string instanceName = typeof(T).Name;
                    GameObject instanceGO = GameObject.Find(instanceName);

                    if (instanceGO == null)
                        instanceGO = new GameObject(instanceName);
                    instance = instanceGO.AddComponent<T>();
                }
            }

            return instance;
        }

        public void InitSingleton()
        {
            
        }

        protected virtual void Awake()
        {
            
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }

}
