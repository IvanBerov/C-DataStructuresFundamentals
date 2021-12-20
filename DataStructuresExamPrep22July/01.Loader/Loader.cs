namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Clear()
        {
            this.entities.Clear();
        }

        public bool Contains(IEntity entity)
        {
            return this.entities.Contains(entity);
        }

        public IEntity Extract(int id)
        {
            IEntity entity = FindById(id);

            if (entity != null)
            {
                this.entities.Remove(entity);
            }

            return entity;
        }

        private IEntity FindById(int id)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Id == id)
                {
                    return entities[i];
                }
            }

            return null;
        }

        public IEntity Find(IEntity entity)
        {
            return FindByEntity(entity);
        }

        private IEntity FindByEntity(IEntity entity)
        {
            int index = entities.IndexOf(entity);

            if (index >= 0)
            {
                return entities[index];
            }

            return null;
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(entities);
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public void RemoveSold()
        {
            List<IEntity> withoutSold = new List<IEntity>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status != BaseEntityStatus.Sold)
                {
                    withoutSold.Add(entities[i]);
                }
            }

            entities = withoutSold;
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int oldIndex = entities.IndexOf(oldEntity);

            VadilIndex(oldIndex);

            entities[oldIndex] = newEntity;
        }

        private void VadilIndex(int index)
        {
            if (index < 0)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            List<IEntity> inBounds = new List<IEntity>();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status >= lowerBound && entities[i].Status <= upperBound)
                {
                    inBounds.Add(entities[i]);
                }
            }

            return inBounds;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var indexOfFirst = this.entities.IndexOf(first);
            var indexOfSecond = this.entities.IndexOf(second);

            VadilIndex(indexOfFirst);
            VadilIndex(indexOfSecond);

            var temp = first;
            this.entities[indexOfFirst] = second;
            this.entities[indexOfSecond] = temp;
        }

        private int IndexOf(int searchedId, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            if (start == end && end == entities.Count || end == -1)
            {
                return -1;
            }

            var middle = (start + end) / 2;


            if (entities[middle].Id == searchedId)
            {
                return middle;
            }

            if (entities[middle].Id > searchedId)
            {
                return IndexOf(searchedId, start, middle - 1);
            }
            else
            {
                return IndexOf(searchedId, middle + 1, end);
            }
        }

        public IEntity[] ToArray()
        {
            return entities.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status == oldStatus)
                {
                    entities[i].Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }
    }
}
