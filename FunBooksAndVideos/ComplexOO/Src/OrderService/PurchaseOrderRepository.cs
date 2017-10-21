using System;
using System.Linq;
using DDD.Core.Repository;

namespace OrderService
{
    public class PurchaseOrderRepository : IRepository<PurchaseOrder, int>
    {
        private static readonly Random _Random;

        static PurchaseOrderRepository()
        {
            _Random = new Random();
        }

        public static int GetNextId() => _Random.Next(0, int.MaxValue);

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PurchaseOrder Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PurchaseOrder> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(PurchaseOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
