using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class Cart
    {
        private string _userId;

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User ID cannot be empty.");
                }
                _userId = value;
            }
        }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public User User { get; set; }

        // Constructor
        public Cart(string userId)
        {
            UserId = userId;
        }
    }

    public class CartItem
    {
        private int _cartId;
        private int _productId;
        private int _quantity;

        [Key]
        public int Id { get; set; }

        [Required]
        public int CartId
        {
            get { return _cartId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cart ID must be a positive integer.");
                }
                _cartId = value;
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
                    throw new ArgumentException("Product ID must be a positive integer.");
                }
                _productId = value;
            }
        }

        public int? VariationId { get; set; }
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

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("VariationId")]
        public Variation Variation { get; set; }

        // Constructor
        public CartItem(int cartId, int productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
