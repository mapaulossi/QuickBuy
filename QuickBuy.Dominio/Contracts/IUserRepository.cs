using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Domain.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetEmailPassword(string email, string password);

        User GetRegister(string email);
    }
}
