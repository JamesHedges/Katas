using System;
using DDD.Shared.Repository;
using DDD.Shared.Domain;

namespace FunBooksAndVideo.Order.Repository
{
    public class PurchaseOrderRepository : IRepository<PurchaseOrder, int>
    {
        private static int _LastId;

        public PurchaseOrderRepository()
        {
            Random random = new Random();
            _LastId = random.Next(0, 5000000);
        }

        public void Delete(int entityId)
        {
        }

        public void Save(PurchaseOrder entity)
        {
            entity.State = EntityState.Unchanged;
        }

        public static int NextId()
        {
            return ++_LastId;
        }
    }
}
