using System;

namespace QFrameWork
{
    /// <summary>
    /// 加载场景成功事件。
    /// </summary>
    public class LoadSceneSuccessEventArgs : EventArgs
    {
        public LoadSceneSuccessEventArgs(string sceneAssetName)
        {
            SceneAssetName = sceneAssetName;
        }

        public string SceneAssetName
        {
            get;private set;
        }
    }
}
