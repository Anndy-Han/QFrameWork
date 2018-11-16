
namespace QFrameWork
{
    public interface IResourcesManager
    {
        /// <summary>
        /// 获取资源组是否准备完毕。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        bool GetResourceGroupReady(string resourceGroupName);

        /// <summary>
        /// 获取资源组资源数量。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        int GetResourceGroupResourceCount(string resourceGroupName);

        /// <summary>
        /// 获取资源组已准备完成资源数量。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        int GetResourceGroupReadyResourceCount(string resourceGroupName);

        /// <summary>
        /// 获取资源组总大小。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        int GetResourceGroupTotalLength(string resourceGroupName);

        /// <summary>
        /// 获取资源组已准备完成总大小。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        int GetResourceGroupTotalReadyLength(string resourceGroupName);

        /// <summary>
        /// 获取资源组准备进度。
        /// </summary>
        /// <param name="resourceGroupName">要检查的资源组名称。</param>
        float GetResourceGroupProgress(string resourceGroupName);

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <param name="assetName"></param>
        T LoadAsset<T>(string assetName);

    }
}
