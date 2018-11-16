using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace QFrameWork
{
    public class ResourcesManager : Object, IResourcesManager,IPlugin
    {
        /// <summary>
        /// 已加载的ab
        /// </summary>
        private Dictionary<string, AssetBundle> loadedAssetBundles = new Dictionary<string, AssetBundle>();

        /// <summary>
        /// AssetBundleManifest
        /// </summary>
        private AssetBundleManifest manifest;

        public void Load()
        {
            
        }

        private void LoadAssetBundleManifest()
        {

        }

        private IEnumerator LoadAssetBundlesAsync(Action onSuccess,Action<string> onFail ,Action<float> onUpdate)
        {
            while(!Caching.ready)
            {

            }
            for (int i = 0; i < manifest.GetAllAssetBundles().Length; i++)
            {
                onUpdate(i/manifest.GetAllAssetBundles().Length);

                string uri = "";

                var request = UnityWebRequest.GetAssetBundle(uri);

                yield return request.Send();

                var handler = (DownloadHandlerAssetBundle)request.downloadHandler;

                AssetBundle asset = handler.assetBundle;

                if (asset == null)
                {
                    onFail(string.Format("Load {0} assrtbundle fail", asset.name));

                    throw new SystemException(string.Format("Load {0} assrtbundle fail",asset.name));
                }
                else
                {
                    loadedAssetBundles.Add(asset.name, asset);
                }
                request.Dispose();
            }
            onSuccess();
        }

        private void LoadAssetBundleFail(object obj)
        {
            throw new SystemException(obj.ToString());
        }

        /// <summary>
        /// 获取资源组准备进度。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public float GetResourceGroupProgress(string resourceGroupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取资源组是否准备完毕。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public bool GetResourceGroupReady(string resourceGroupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取资源组已准备完成资源数量。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupReadyResourceCount(string resourceGroupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取资源组资源数量。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupResourceCount(string resourceGroupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取资源组总大小。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupTotalLength(string resourceGroupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取资源组已准备完成总大小。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        public int GetResourceGroupTotalReadyLength(string resourceGroupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <param name="assetName"></param>
        public T LoadAsset<T>(string assetName)
        {
            throw new NotImplementedException();
        }
    }
}
