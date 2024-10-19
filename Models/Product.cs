using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eCommerce_Insanity.Models
{
    public class Product
    {
        private string _name = "";
        private decimal _price = 0;
        private int _categoryId = 0;
        private string _sku = "";

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be empty");
                }
                _name = value;
            }
        }
        public string? Description { get; set; }

        [Required]
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Product price must be greater than zero.");
                }
                _price = value;
            }
        }

        [Required]
        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Category ID must be a positive integer.");
                }
                _categoryId = value;
            }
        }

        public string? ImageUrl { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        [Column("SKU")]
        public string SKU
        {
            get { return _sku; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("SKU cannot be empty.");
                }
                _sku = value;
            }
        }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public ICollection<Variation>? Variations { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

        public Product() { }

        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public Product(string name, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }
#pragma warning restore CS8618
    }
}
