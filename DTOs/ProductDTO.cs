using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_Insanity.Models;

namespace eCommerce_Insanity.DTOs
{
    public class ProductDTO
    {
        private string _name = "";
        private decimal _price = 0;
        private int _categoryId = 0;
        private string _sku = "";

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

        public int StockQuantity { get; set; }

        [Required]
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
    }
}
