using System;
using Shipping;

namespace Order.Tests
{
    public class FakeShippingService : IShippingService
    {
        public void GenerateShippingLabel(int customerId, string itemLine)
        {
            throw new NotImplementedException();
        }
    }
}
