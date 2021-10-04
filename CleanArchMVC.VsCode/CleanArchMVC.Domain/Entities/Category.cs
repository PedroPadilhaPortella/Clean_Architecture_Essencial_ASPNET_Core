using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchMVC.Domain.Validation;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }
        public Category(int id, string name)
        {
            ValidateDomain(name);
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            this.Id = id;
        }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name, the value is required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, Too Short, Minimal is 3 characters!");
            this.Name = name;
        } 
    }
}