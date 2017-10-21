using System;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;

namespace OrderProcessorService.Items
{
    public class ItemProcessorBuilder : IItemProcessorBuilder
    {
        private readonly IMediator _Mediator;

        public ItemProcessorBuilder(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public IItemProcessor GetItemProcessor(ItemLineRequest itemLine)
        {
            IItemProcessor itemProcessor = null;;

            switch (itemLine.Type)
            {
                case ItemLineType.Product:
                    itemProcessor = GetProductItemProcessor(itemLine);
                    break;
                case ItemLineType.Membership:
                    itemProcessor = GetMembershipItemProcessor(itemLine);
                    break;
                default:
                    throw new Exception("Invalid Line Item Type. Could not get item processor");
                    break;
            }
            return itemProcessor;
        }

        private IItemProcessor GetMembershipItemProcessor(ItemLineRequest item)
        {
            return new MembershipItemProcessor(_Mediator);
        }

        private IItemProcessor GetProductItemProcessor(ItemLineRequest itemLine)
        {
            if (itemLine.Description == "Comprehensive First Aid Training")
            {
                return new FirstAidVideoProcessor(_Mediator);
            }
            else
            {
                return new ProductItemProcessor(_Mediator);
            }
        }
    }
}