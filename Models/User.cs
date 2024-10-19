using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace eCommerce_Insanity.Models
{
    public class User : IdentityUser
    {
        private string _firstName;
        private string _lastName;

        [Required]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User must have a first name.");
                }
                _firstName = value;
            }
        }

        [Required]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User must have a last name.");
                }
                _lastName = value;
            }
        }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }

        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
#pragma warning restore CS8618
    }
}
