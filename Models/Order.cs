using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce_Insanity.Models
{
    public class Order
    {
        private string _userId;
        private decimal _totalAmount;
        private int _shippingAddressId;
        private int _billingAddressId;

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId
        {
            get { return _userId; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("UserId must be included on Orders.");
                }
                _userId = value;
            }
        }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total amount cannot be negative.");
                }
                _totalAmount = value;
            }
        }

        public string Status { get; set; } = "Pending";

        [Required]
        public int ShippingAddressId
        {
            get { return _shippingAddressId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Shipping ID must be included on Order");
                }
                _shippingAddressId = value;
            }
        }

        [Required]
        public int BillingAddressId
        {
            get { return _billingAddressId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Billing ID must be included on Order");
                }
                _billingAddressId = value;
            }
        }

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ShippingAddressId")]
        public Address ShippingAddress { get; set; }

        [ForeignKey("BillingAddressId")]
        public Address BillingAddress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // Constructor
        public Order(
            string userId,
            decimal totalAmount,
            int shippingAddressId,
            int billingAddressId
        )
        {
            UserId = userId;
            TotalAmount = totalAmount;
            ShippingAddressId = shippingAddressId;
            BillingAddressId = billingAddressId;
        }
    }
}
