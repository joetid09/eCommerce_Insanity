using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class OrderItem
    {
        private int _orderId;
        private int _productId;
        private int _quantity;
        private decimal _priceAtPurchase;

        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Order ID must be greater than zero.");
                }
                _orderId = value;
            }
        }

        [Required]
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Product ID must be greater than zero");
                }
                _productId = value;
            }
        }

        public int? VariationId { get; set; }

        [Required]
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity must be a positive integer.");
                }
                _quantity = value;
            }
        }

        [Required]
        public decimal PriceAtPurchase
        {
            get { return _priceAtPurchase; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price at purchase cannot be negative.");
                }
                _priceAtPurchase = value;
            }
        }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("VariationId")]
        public Variation Variation { get; set; }
        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public OrderItem(int orderId, int productId, int quantity, decimal priceAtPurchase)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            PriceAtPurchase = priceAtPurchase;
        }
#pragma warning restore CS8618
    }
}
