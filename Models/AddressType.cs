using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce_Insanity.Models
{
    public class AddressType
    {
        private string _name;

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

        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public AddressType(string name)
        {
            Name = name;
        }
#pragma warning restore CS8618
    }
}
