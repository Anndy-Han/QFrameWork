using System;
using System.Collections.Generic;

namespace QFrameWork
{
    public class SceneManager : ISceneManager,IPlugin
    {
        private readonly List<string> m_LoadedSceneAssetNames = new List<string>();
        private readonly List<string> m_LoadingSceneAssetNames = new List<string> ();
        private readonly List<string> m_UnloadingSceneAssetNames = new List<string> ();
        private LoadSceneCallbacks m_LoadSceneCallbacks = null;
        private UnloadSceneCallbacks m_UnloadSceneCallbacks = null;

        public event EventHandler<LoadSceneSuccessEventArgs> m_LoadSceneSuccessEventHandler = null;
        public event EventHandler<LoadSceneFailureEventArgs> m_LoadSceneFailureEventHandler = null;
        public event EventHandler<LoadSceneUpdateEventArgs> m_LoadSceneUpdateEventHandler = null;
        public event EventHandler<UnloadSceneSuccessEventArgs> m_UnloadSceneSuccessEventHandler = null;
        public event EventHandler<UnloadSceneFailureEventArgs> m_UnloadSceneFailureEventHandler = null;

        public SceneManager()
        {
            m_LoadSceneCallbacks = new LoadSceneCallbacks(LoadSceneSuccessCallback, LoadSceneFailureCallback);

            m_UnloadSceneCallbacks = new UnloadSceneCallbacks(UnloadSceneSuccessCallback, UnloadSceneFailureCallback);
        }

        /// <summary>
        /// 加载场景成功事件。
        /// </summary>
        public event EventHandler<LoadSceneSuccessEventArgs> LoadSceneSuccess
        {
            add
            {
                m_LoadSceneSuccessEventHandler += value;
            }
            remove
            {
                m_LoadSceneSuccessEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载场景失败事件。
        /// </summary>
        public event EventHandler<LoadSceneFailureEventArgs> LoadSceneFailure
        {
            add
            {
                m_LoadSceneFailureEventHandler += value;
            }
            remove
            {
                m_LoadSceneFailureEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载场景更新事件。
        /// </summary>
        public event EventHandler<LoadSceneUpdateEventArgs> LoadSceneUpdate
        {
            add
            {
                m_LoadSceneUpdateEventHandler += value;
            }
            remove
            {
                m_LoadSceneUpdateEventHandler -= value;
            }
        }

        /// <summary>
        /// 卸载场景成功事件。
        /// </summary>
        public event EventHandler<UnloadSceneSuccessEventArgs> UnloadSceneSuccess
        {
            add
            {
                m_UnloadSceneSuccessEventHandler += value;
            }
            remove
            {
                m_UnloadSceneSuccessEventHandler -= value;
            }
        }

        /// <summary>
        /// 卸载场景失败事件。
        /// </summary>
        public event EventHandler<UnloadSceneFailureEventArgs> UnloadSceneFailure
        {
            add
            {
                m_UnloadSceneFailureEventHandler += value;
            }
            remove
            {
                m_UnloadSceneFailureEventHandler -= value;
            }
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneAssetName">加载场景的名字</param>
        /// <param name="loadSceneSuccessEventArgs">加载场景成功的回调</param>
        /// <param name="loadSceneFailureEventArgs">加载场景失败的回调</param>
        public void LoadScene(string sceneAssetName)
        {
            if (string.IsNullOrEmpty(sceneAssetName))
            {
                throw new Exception("Scene asset name is invalid.");
            }

            if (SceneIsUnload(sceneAssetName))
            {
                throw new Exception(string.Format("Scene asset '{0}' is being unloaded.", sceneAssetName));
            }

            if (SceneIsLoading(sceneAssetName))
            {
                throw new Exception(string.Format("Scene asset '{0}' is being loaded.", sceneAssetName));
            }

            if (SceneIsLoaded(sceneAssetName))
            {
                throw new Exception(string.Format("Scene asset '{0}' is already loaded.", sceneAssetName));
            }
            m_LoadingSceneAssetNames.Add(sceneAssetName);

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneAssetName);

            UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
        {
            if (m_LoadSceneSuccessEventHandler==null)
            {
                return;
            }

            m_LoadSceneSuccessEventHandler(this,new LoadSceneSuccessEventArgs (arg0.name));
        }

        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="sceneAssetName">卸载场景的名字</param>
        /// <param name="unloadSceneSuccessEventArgs">卸载场景成功的回调</param>
        /// <param name="unloadSceneFailureEventArgs">卸载场景失败的回调</param>
        public void UnloadScene(string sceneAssetName)
        {
            if (string.IsNullOrEmpty(sceneAssetName))
            {
                throw new Exception("Scene asset name is invalid.");
            }

            if (SceneIsUnload(sceneAssetName))
            {
                throw new Exception(string.Format("Scene asset '{0}' is being unloaded.", sceneAssetName));
            }

            if (SceneIsLoading(sceneAssetName))
            {
                throw new Exception(string.Format("Scene asset '{0}' is being loaded.", sceneAssetName));
            }

            if (SceneIsLoaded(sceneAssetName))
            {
                throw new Exception(string.Format("Scene asset '{0}' is already loaded.", sceneAssetName));
            }
            m_UnloadingSceneAssetNames.Add(sceneAssetName);

            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneAssetName);

            UnityEngine.SceneManagement.SceneManager.sceneUnloaded += SceneManager_sceneUnloaded;
        }

        private void SceneManager_sceneUnloaded(UnityEngine.SceneManagement.Scene arg0)
        {
            m_UnloadSceneSuccessEventHandler(this,new UnloadSceneSuccessEventArgs(arg0.name));
        }

        /// <summary>
        /// 场景是否已被加载
        /// </summary>
        /// <param name="sceneAssetName">场景名字</param>
        /// <returns></returns>
        public bool SceneIsLoaded(string sceneAssetName)
        {
            return m_LoadedSceneAssetNames.Contains(sceneAssetName);
        }

        /// <summary>
        /// 场景是否正在加载
        /// </summary>
        /// <param name="sceneAssetName">场景名字</param>
        /// <returns></returns>
        public bool SceneIsLoading(string sceneAssetName)
        {
            return m_LoadingSceneAssetNames.Contains(sceneAssetName);
        }

        /// <summary>
        /// 场景是否已经卸载
        /// </summary>
        /// <param name="sceneAssetName"></param>
        /// <returns></returns>
        public bool SceneIsUnload(string sceneAssetName)
        {
            return m_UnloadingSceneAssetNames.Contains(sceneAssetName);
        }

        private void LoadSceneSuccessCallback(string sceneAssetName)
        {
            m_LoadingSceneAssetNames.Remove(sceneAssetName);
            m_LoadedSceneAssetNames.Add(sceneAssetName);
            if (m_LoadSceneSuccessEventHandler != null)
            {
                m_LoadSceneSuccessEventHandler(this, new LoadSceneSuccessEventArgs(sceneAssetName));
            }
        }

        private void LoadSceneFailureCallback(string sceneAssetName)
        {
            m_LoadingSceneAssetNames.Remove(sceneAssetName);
            string appendErrorMessage = string.Format("Load scene failure, scene asset name '{0}'", sceneAssetName);
            if (m_LoadSceneFailureEventHandler != null)
            {
                m_LoadSceneFailureEventHandler(this, new LoadSceneFailureEventArgs(sceneAssetName));
                return;
            }
        }

        private void UnloadSceneSuccessCallback(string sceneAssetName)
        {
            m_UnloadingSceneAssetNames.Remove(sceneAssetName);
            m_LoadedSceneAssetNames.Remove(sceneAssetName);
            if (m_UnloadSceneSuccessEventHandler != null)
            {
                m_UnloadSceneSuccessEventHandler(this, new UnloadSceneSuccessEventArgs(sceneAssetName));
            }
        }

        private void UnloadSceneFailureCallback(string sceneAssetName)
        {
            m_UnloadingSceneAssetNames.Remove(sceneAssetName);
            if (m_UnloadSceneFailureEventHandler != null)
            {
                m_UnloadSceneFailureEventHandler(this, new UnloadSceneFailureEventArgs(sceneAssetName));
                return;
            }
        }

        public void Load()
        {
            
        }
    }
}
