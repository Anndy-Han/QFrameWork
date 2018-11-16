using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    public  class UnloadSceneCallbacks
    {
        private readonly UnloadSceneSuccessCallback m_UnloadSceneSuccessCallback;
        private readonly UnloadSceneFailureCallback m_UnloadSceneFailureCallback;

        /// <summary>
        /// 初始化卸载场景回调函数集的新实例。
        /// </summary>
        /// <param name="unloadSceneSuccessCallback">卸载场景成功回调函数。</param>
        public UnloadSceneCallbacks(UnloadSceneSuccessCallback unloadSceneSuccessCallback)
            : this(unloadSceneSuccessCallback, null)
        {

        }

        /// <summary>
        /// 初始化卸载场景回调函数集的新实例。
        /// </summary>
        /// <param name="unloadSceneSuccessCallback">卸载场景成功回调函数。</param>
        /// <param name="unloadSceneFailureCallback">卸载场景失败回调函数。</param>
        public UnloadSceneCallbacks(UnloadSceneSuccessCallback unloadSceneSuccessCallback, UnloadSceneFailureCallback unloadSceneFailureCallback)
        {
            m_UnloadSceneSuccessCallback = unloadSceneSuccessCallback;
            m_UnloadSceneFailureCallback = unloadSceneFailureCallback;
        }
    }

    /// <summary>
    /// 卸载场景成功的回调
    /// </summary>
    /// <param name="sceneAssetName">场景名字</param>
    public delegate void UnloadSceneSuccessCallback(string sceneAssetName);

    /// <summary>
    /// 卸载场景失败的回调
    /// </summary>
    /// <param name="sceneAssetName">场景名字</param>
    public delegate void UnloadSceneFailureCallback(string sceneAssetName);
}
