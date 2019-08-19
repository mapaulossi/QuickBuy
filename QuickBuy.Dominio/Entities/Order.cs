using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Domain.ObjectOfValue;

namespace QuickBuy.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int UserId { get; set; }
        public DateTime DeliveryPredictionDate { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public int AddressNumber { get; set; }
        public int PaymentWayId { get; set; }
        public PaymentWay PaymentWay { get; set; }

        /// <summary>
        /// Order deve ter pelo menos um Item ou muitos
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
