using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    public class LoadSceneCallbacks
    {
        private readonly LoadSceneSuccessCallback m_LoadSceneSuccessCallback;
        private readonly LoadSceneFailureCallback m_LoadSceneFailureCallback;

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback)
            : this(loadSceneSuccessCallback, null)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback)
        {
            m_LoadSceneSuccessCallback = loadSceneSuccessCallback;
            m_LoadSceneFailureCallback = loadSceneFailureCallback;
        }
    }

    /// <summary>
    /// 加载场景成功回调
    /// </summary>
    /// <param name="sceneAssetName">场景名字</param>
    public delegate void LoadSceneSuccessCallback(string sceneAssetName);

    /// <summary>
    /// 加载场景失败回调
    /// </summary>
    /// <param name="sceneAssetName">场景名字</param>
    public delegate void LoadSceneFailureCallback(string sceneAssetName);

}
