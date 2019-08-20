using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Domain.Entities
{
    public abstract class Entity
    {
        private List<string> _validationMessage { get; set; }
        private List<string> validationMessage
        {
            get
            {
                return _validationMessage ?? (_validationMessage = new List<string>()); //Valida se está vazia (??)
            }
        }

        protected void CleanValidationsMessage()
        {
            validationMessage.Clear();
        }

        protected void AddValidationsMessage(string message)
        {
            validationMessage.Add(message);
        }

        public abstract void Validate(); //Abstract força filhos implementarem

        protected bool IsValid
        {
            get
            {
                return (!validationMessage.Any());
            }

        }
    }
}
