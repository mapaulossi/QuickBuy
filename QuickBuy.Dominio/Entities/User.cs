using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.Entities
{
    public class User : Entity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; } //virtual permite que FCore faça sobreposição da ICollection

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                AddValidationsMessage("Email is required");

            if (string.IsNullOrEmpty(Password))
                AddValidationsMessage("Password is required");
        }
    }
}
