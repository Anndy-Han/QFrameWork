using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    /// <summary>
    /// 场景管理器接口
    /// </summary>
    public interface ISceneManager
    {
        /// <summary>
        /// 加载场景成功事件。
        /// </summary>
        event EventHandler<LoadSceneSuccessEventArgs> LoadSceneSuccess;

        /// <summary>
        /// 加载场景失败事件。
        /// </summary>
        event EventHandler<LoadSceneFailureEventArgs> LoadSceneFailure;

        /// <summary>
        /// 加载场景更新事件。
        /// </summary>
        event EventHandler<LoadSceneUpdateEventArgs> LoadSceneUpdate;

        /// <summary>
        /// 卸载场景成功事件。
        /// </summary>
        event EventHandler<UnloadSceneSuccessEventArgs> UnloadSceneSuccess;

        /// <summary>
        /// 卸载场景失败事件。
        /// </summary>
        event EventHandler<UnloadSceneFailureEventArgs> UnloadSceneFailure;

        /// <summary>
        /// 获取场景是否已加载。
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称。</param>
        /// <returns>场景是否已加载。</returns>
        bool SceneIsLoaded(string sceneAssetName);

        /// <summary>
        /// 获取场景是否正在加载。
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称。</param>
        /// <returns>场景是否正在加载。</returns>
        bool SceneIsLoading(string sceneAssetName);

        /// <summary>
        /// 获取场景是否已被卸载
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称。</param>
        /// <returns>场景是否已经卸载。</returns>
        bool SceneIsUnload(string sceneAssetName);

        /// <summary>
        /// 加载场景。
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称。</param>
        void LoadScene(string sceneAssetName);

        /// <summary>
        /// 卸载场景。
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称。</param>
        void UnloadScene(string sceneAssetName);
    }
}
