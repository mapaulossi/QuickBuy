using System;
using System.Collections.Generic;
using System.Text;
using QuickBuy.Domain.Contracts;
using QuickBuy.Domain.Entities;

namespace QuickBuy.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository //Herda e implementa
    {
        public UserRepository()
        {

        }
    }
}
