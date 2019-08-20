using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Domain.Contracts
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
