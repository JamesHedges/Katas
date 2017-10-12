using System;
using System.Diagnostics;

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
            Debug.WriteLine($"Generating shipping label for customer ID: {customerId}, Item: {itemLine}");
        }
    }
}
