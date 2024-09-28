using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class Address
    {
        private string _userId;
        private string _addressLine1;
        private string _city;
        private string _state;
        private string _postalCode;

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
                    throw new ArgumentException("UserID must be included in Address.");
                }
                _userId = value;
            }
        }

        [Required]
        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address Line 1 cannot be empty.");
                }
                _addressLine1 = value;
            }
        }

        public string? AddressLine2 { get; set; }

        public string? UnitIdentifier { get; set; }

        [Required]
        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City cannot be empty.");
                }
                _city = value;
            }
        }

        [Required]
        public string State
        {
            get { return _state; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("State cannot be empty.");
                }
                _state = value;
            }
        }

        [Required]
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Postal Code cannot be empty.");
                }
                _postalCode = value;
            }
        }

        public User User { get; set; }
        public ICollection<Order> OrdersAsShippingAddress { get; set; } = new List<Order>();
        public ICollection<Order> OrdersAsBillingAddress { get; set; } = new List<Order>();

        // Constructor
        public Address(
            string userId,
            string addressLine1,
            string city,
            string state,
            string postalCode
        )
        {
            UserId = userId;
            AddressLine1 = addressLine1;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
    }
}
