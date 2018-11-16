using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    /// <summary>
    /// 加载场景失败事件。
    /// </summary>
    public class LoadSceneFailureEventArgs:EventArgs
    {
        public LoadSceneFailureEventArgs(string sceneAssetName)
        {
            SceneAssetName = sceneAssetName;
        }

        public string SceneAssetName
        {
            get; private set;
        }

    }
}
