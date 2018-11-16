using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace QFrameWork
{
    public enum AppMode
    {
        Developing,
        Android,
        Ios
    }

    public class App:QBehaviour,IApp
    {
        public AppMode appMode = AppMode.Developing;

        public AppMate appMate;

        private App()
        {

        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            StartCoroutine(ApplicationDidFinishLaunching());
        }

        public AppMode GetAppMode()
        {
            return this.appMode;
        }

        private void LoadRuntimeManager()
        {
            Global.app = this;

            Global.eventDispatcher = GetRuntimeManager<EventDispatcher>() as EventDispatcher;

            Global.loadManager = GetRuntimeManager<LoadManager>() as LoadManager;

            Global.resourcesManager = GetRuntimeManager<ResourcesManager>() as ResourcesManager;

            Global.sceneManager = GetRuntimeManager<SceneManager>() as SceneManager;

            Global.uiManager = GetRuntimeManager<UIManager>() as UIManager;

            Global.proceduceManager = GetRuntimeManager<ProcedureManager>() as ProcedureManager;

            Global.audioManager = GetRuntimeManager<AudioManager>() as AudioManager;

            Global.networkManager = GetRuntimeManager<NetWorkManager>() as NetWorkManager;
        }

        public object GetRuntimeManager<T>()
        {
            object instance = null;

            Type type = typeof(T);

            if (type.IsSubclassOf(typeof(MonoBehaviour)))
            {
                instance = GetComponent(type) ?? gameObject.AddComponent(type);
            }
            else if (type.IsInterface)
            {
                instance = gameObject.GetComponent(type);
            }
            else
            {
                instance = Activator.CreateInstance<T>();
            }
            IPlugin plugin = instance as IPlugin;

            plugin.Load();

            Debug.Log("LoadRuntimeManager  "+instance.GetType()+" Success");

            return instance;
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <returns></returns>
        private IEnumerator ApplicationDidFinishLaunching()
        {
            Debug.Log("=======App is launching=======");

            Application.targetFrameRate = this.appMate.targetFrameRate;

            QLog.Instance();

            LoadRuntimeManager();

            BaseProcedure.qBehaviour = this;

            LoadProceduces(this.appMate.procedureMates);

            ChangeProcedure(CreateProcedureEnter(this.appMate.startProcedure));

            if (appMode == AppMode.Developing)
            {
               
            }
            else
            {
                
            }
            yield return null;
        }

        public AppMate GetAppMate()
        {
            return this.appMate;
        }
    }
}
