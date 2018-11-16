using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    /// <summary>
    /// 卸载场景成功事件
    /// </summary>
    public class UnloadSceneSuccessEventArgs:EventArgs
    {
        public UnloadSceneSuccessEventArgs(string sceneAssetName)
        {
            SceneAssetName = sceneAssetName;
        }

        public string SceneAssetName
        {
            get; private set;
        }

    }
}
