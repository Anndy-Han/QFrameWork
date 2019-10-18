using UnityEngine;

namespace QFrameWork
{
    public interface IEntityManager
    {
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        Entity CreateEntity(GameObject gameObject, EntityLogic entityLogic, object entityInfo, IEntityGroup entityGroup);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Entity GetEntity(int id);

        /// <summary>
        /// 是否有这个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool HasEntity(int id);

        /// <summary>
        /// 增加一个实体组
        /// </summary>
        /// <param name="entityGroupName"></param>
        /// <param name="entityGroup"></param>
        /// <returns></returns>
        bool AddEntityGroup(string entityGroupName, IEntityGroup entityGroup);

        /// <summary>
        /// 是否有这个实体组
        /// </summary>
        /// <param name="entityGroupName"></param>
        /// <returns></returns>
        bool HasEntityGroup(string entityGroupName);

        /// <summary>
        /// 获取实体数量
        /// </summary>
        /// <returns></returns>
        int EntityCount { get; }
    }
}
