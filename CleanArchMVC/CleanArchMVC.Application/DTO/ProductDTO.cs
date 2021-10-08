using CleanArchMVC.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMVC.Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; private set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName="decimal(18,2)")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; private set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; private set; }

        public int CategoryId { get; set; }

        [DisplayName("Categories")]
        public Category Category { get; set; }
    }
}
