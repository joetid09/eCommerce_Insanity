using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class OrderAddress
    {
        private int _orderId;
        private int _addressId;
        private int _addressTypeId;

        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Order ID must be a positive integer.");
                }
                _orderId = value;
            }
        }

        [Required]
        public int AddressId
        {
            get { return _addressId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Address ID must be a positive integer.");
                }
                _addressId = value;
            }
        }

        [Required]
        public int AddressTypeId
        {
            get { return _addressTypeId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Address Type ID must be a positive integer.");
                }
                _addressTypeId = value;
            }
        }

        // Navigation Properties
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [ForeignKey("AddressTypeId")]
        public AddressType AddressType { get; set; }

        // Constructor
        public OrderAddress(int orderId, int addressId, int addressTypeId)
        {
            OrderId = orderId;
            AddressId = addressId;
            AddressTypeId = addressTypeId;
        }
    }
}
