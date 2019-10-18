using System;
using UnityEngine;
using System.Collections.Generic;

namespace QFrameWork
{
    public class EntityGroup : IEntityGroup
    {
        private Transform transform;

        private Dictionary<int, Entity> entities;

        public EntityGroup(Transform transform, string name)
        {
            this.transform = transform;

            this.Name = name;

            this.transform.gameObject.Name(name);

            this.entities = new Dictionary<int, Entity>();
        }

        public bool AddEntity(Entity entity)
        {
            if (HasEntity(entity.Id))
            {
                return false;
            }
            this.entities.Add(entity.Id , entity);

            entity.Transform.SetParent(this.transform, false);

            entity.Transform.localPosition = Vector3.zero;

            entity.Transform.localScale = Vector3.one;

            entity.Transform.localRotation = Quaternion.Euler(0,0,0);

            return true;
        }

        public int EntityCount {
            get {
                return this.entities.Count;
            }
        }

        public string Name {
            get;set;
        }

        public List<Entity> GetAllEntities()
        {
            List<Entity> entities = new List<Entity>();

            foreach (var item in this.entities)
            {
                entities.Add(item.Value);
            }

            return entities;
        }

        public Entity GetEntity(int entityId)
        {
            if (HasEntity(entityId))
            {
                return this.entities[entityId];
            }
            return null;
        }

        public bool HasEntity(int entityId)
        {
            return this.entities.ContainsKey(entityId);
        }
    }
}
