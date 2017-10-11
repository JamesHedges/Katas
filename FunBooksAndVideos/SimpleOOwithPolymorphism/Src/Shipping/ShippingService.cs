using System;

namespace Shipping
{
 
    public interface IShippingService
    {
        void GenerateShippingLabel(int customerId, string itemLine);
    }

    public class ShippingService : IShippingService
    {
        public void GenerateShippingLabel(int customerId, string itemLine)
        {
            throw new NotImplementedException();
        }
    }
}
