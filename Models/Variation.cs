using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class Variation
    {
        private int _productId;
        private string _attributeName;
        private string _attributeValue;
        private int _stockQuantity;

        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Product ID must be a positive integer.");
                }
                _productId = value;
            }
        }

        [Required]
        public string AttributeName
        {
            get { return _attributeName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Attribute name cannot be empty.");
                }
                _attributeName = value;
            }
        }

        [Required]
        public string AttributeValue
        {
            get { return _attributeValue; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Attribute value cannot be empty.");
                }
                _attributeValue = value;
            }
        }

        public decimal? PriceAdjustment { get; set; }

        [Required]
        public int StockQuantity
        {
            get { return _stockQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Stock quantity cannot be negative.");
                }
                _stockQuantity = value;
            }
        }

        public string? SKU { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public Variation(
            int productId,
            string attributeName,
            string attributeValue,
            int stockQuantity
        )
        {
            ProductId = productId;
            AttributeName = attributeName;
            AttributeValue = attributeValue;
            StockQuantity = stockQuantity;
        }
#pragma warning restore CS8618
    }
}
