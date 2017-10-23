using System;
using DDD.Core.Domain;
using System.Collections.Generic;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Core.Messages;

namespace OrderService
{
    public class PurchaseOrder : Entity<int>
    {
        private readonly IMediator _Mediator;

        private PurchaseOrder(IMediator mediator)
            : base()
        {
            _Mediator = mediator;
        }

        public static PurchaseOrder Create(int orderId, decimal total, int customerId, IEnumerable<ItemLine> items, IMediator mediator)
        {

            return new PurchaseOrder(mediator)
            {
                Id = orderId,
                Total = total,
                CustomerId = customerId,
                ItemLines = items
            };
        }

        public decimal Total { get; private set; }
        public int CustomerId { get; private set; }
        public IEnumerable<ItemLine> ItemLines { get; private set; }
        public bool Accepted { get; private set; }


        public async Task Accept()
        {
            AcceptPurchaseOrder acceptPurchase = new AcceptPurchaseOrder
            {
                CustomerId = CustomerId,
                PurchaseOrderId = Id,
                Items = ItemLines.Select(il => new ItemLineRequest { Description = il.Description, Type = il.Type }).ToList()
            };
            AcceptedPurchaseOrder response = await _Mediator.Send(acceptPurchase);
            Accepted = response.Accepted;
            if (response.Accepted)
            {
                ProcessedPurchaseOrder processedPurchaseOrder = new ProcessedPurchaseOrder
                {
                    CustomerId = CustomerId,
                    PurchaseOrderId = Id,
                    Items = ItemLines.Select(il => new ItemLineRequest { Description = il.Description, Type = il.Type }).ToList()
                };
                await _Mediator.Publish(processedPurchaseOrder);
            }
        }
    }
}
