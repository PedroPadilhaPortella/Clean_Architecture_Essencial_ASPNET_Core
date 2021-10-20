using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            this.Id = id;
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name, the value is required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, Too Short, Minimal is 3 characters!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description, the value is required!");
            DomainExceptionValidation.When(description.Length < 5, "Invalid Description, Too Short, Minimal is 5 characters!");
            DomainExceptionValidation.When(price < 0, "Invalid Price value");
            DomainExceptionValidation.When(stock < 0, "Invalid Stock value");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid Image Name, Too Long, maximun 250 characters");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
    }
}
