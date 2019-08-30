using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBuy.Domain.Contracts;
using QuickBuy.Domain.Entities;
using QuickBuy.Repository.Context;

namespace QuickBuy.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository //Herda e implementa
    {
        public UserRepository(QuickBuyContext quickBuyContext) : base(quickBuyContext)
        {
        }

        public User GetEmailPassword(string email, string password)
        {
            return QuickBuyContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
