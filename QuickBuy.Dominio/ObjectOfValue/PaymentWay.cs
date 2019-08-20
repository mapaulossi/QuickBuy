using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Domain.Entities;
using QuickBuy.Domain.Enumerables;

namespace QuickBuy.Domain.ObjectOfValue
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsBillet
        {
            get { return Id == (int)TypePaymentMethodEnum.Billet; }
        }

        public bool IsCreditCard
        {
            get { return Id == (int)TypePaymentMethodEnum.CreditCard; }
        }

        public bool IsDeposit
        {
            get { return Id == (int)TypePaymentMethodEnum.Deposit; }
        }

        public bool NotDefined
        {
            get { return Id == (int)TypePaymentMethodEnum.NotDefined; }
        }
    }
}
