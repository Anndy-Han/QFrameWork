using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    /// <summary>
    /// 加载场景更新事件
    /// </summary>
    public class LoadSceneUpdateEventArgs:EventArgs
    {
        public LoadSceneUpdateEventArgs(string sceneAssetName)
        {
            SceneAssetName = sceneAssetName;
        }

        public string SceneAssetName
        {
            get; private set;
        }

    }
}
