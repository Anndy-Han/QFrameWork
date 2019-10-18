using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    public interface IEntityGroup
    {
        //
        // 摘要:
        //     获取实体组名称。
        string Name { get; set; }
        //
        // 摘要:
        //     获取实体组中实体数量。
        int EntityCount { get; }
        //
        // 摘要:
        //     从实体组中获取所有实体。
        //
        // 返回结果:
        //     实体组中的所有实体。
        List<Entity> GetAllEntities();
        //
        // 摘要:
        //     从实体组中获取实体。
        //
        // 参数:
        //   entityId:
        //     实体序列编号。
        //
        // 返回结果:
        //     要获取的实体。
        Entity GetEntity(int entityId);

        //
        // 摘要:
        //     实体组中是否存在实体。
        //
        // 参数:
        //   entityId:
        //     实体序列编号。
        //
        // 返回结果:
        //     实体组中是否存在实体。
        bool HasEntity(int entityId);

        //
        // 摘要:
        //     实体组中加入实体。
        //
        // 参数:
        //   entity:
        //     实体。
        //
        // 返回结果:
        //     实体是否加入成功。
        bool AddEntity(Entity entity);
    }
}
