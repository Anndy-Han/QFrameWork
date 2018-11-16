using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    /// <summary>
    /// 卸载场景失败事件
    /// </summary>
    public class UnloadSceneFailureEventArgs:EventArgs
    {
        public UnloadSceneFailureEventArgs(string sceneAssetName)
        {
            SceneAssetName = sceneAssetName;
        }

        public string SceneAssetName
        {
            get; private set;
        }

    }
}
