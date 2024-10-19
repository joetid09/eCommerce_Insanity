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

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<OrderAddress> OrderAddresses { get; set; } = new List<OrderAddress>();

        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public Order(string userId, decimal totalAmount)
        {
            UserId = userId;
            TotalAmount = totalAmount;
        }
#pragma warning restore CS8618
    }
}
