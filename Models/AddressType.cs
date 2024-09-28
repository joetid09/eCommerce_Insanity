using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce_Insanity.Models
{
    public class AddressType
    {
        private string _name; // Private field to back the Name property

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
                    throw new ArgumentException("Address type name cannot be empty.");
                }
                _name = value;
            }
        }

        // Constructor
        public AddressType(string name)
        {
            Name = name; // This will trigger the setter logic and perform validation
        }
    }
}
