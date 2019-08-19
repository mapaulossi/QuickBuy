using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Domain.Enumerables;

namespace QuickBuy.Domain.ObjectOfValue
{
    public class PaymentWay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsBillet
        {
            get { return Id == (int)TypePaymentWayEnum.Billet; }
        }

        public bool IsCreditCard
        {
            get { return Id == (int)TypePaymentWayEnum.CreditCard; }
        }

        public bool IsDeposit
        {
            get { return Id == (int)TypePaymentWayEnum.Deposit; }
        }

        public bool NotDefined
        {
            get { return Id == (int)TypePaymentWayEnum.NotDefined; }
        }
    }
}
