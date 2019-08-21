using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBuy.Domain.ObjectOfValue;

namespace QuickBuy.Domain.Entities
{
    public class Order : Entity
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } //retorno da virtual de User (Mapeamento)
        public DateTime DeliveryPredictionDate { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public int AddressNumber { get; set; }
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Order deve ter pelo menos um Item ou muitos
        /// </summary>
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public override void Validate()
        {
            CleanValidationsMessage();

            if (!OrderItems.Any())
                AddValidationsMessage("Warning - Order Item cannot be empty");

            if (string.IsNullOrEmpty(CEP))
                AddValidationsMessage("Warning - CEP cannot be empty");

            if (PaymentMethodId == 0)
                AddValidationsMessage("Warning - No payment method entered");

        }
    }
}
