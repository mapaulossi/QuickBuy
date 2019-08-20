using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public override void Validate()
        {
            if (ProductId == 0)
                AddValidationsMessage("Product reference was not identified");

            if (Quantity == 0)
                AddValidationsMessage("Quantity not reported");
            ;
        }
    }
}
