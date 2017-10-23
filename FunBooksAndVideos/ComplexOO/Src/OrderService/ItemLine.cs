using DDD.Core.Domain;
using System;
using System.Collections.Generic;
using OrderService.Core;

namespace OrderService
{
    public class ItemLine : ValueObject<ItemLine>
    {
        public ItemLine(string description, ItemLineType type)
        {
            Description = description;
            Type = type;
        }

        public string Description { get; }
        public ItemLineType Type { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new List<object> { Description, Type };
        }
    }
}
