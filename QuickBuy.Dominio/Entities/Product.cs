using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.Entities
{
    public class Product : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string FileName { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddValidationsMessage("Name was not entered!");

            }

            if (string.IsNullOrEmpty(Description))
            {
                AddValidationsMessage("Description was not entered!");
            }
        }
    }
}
