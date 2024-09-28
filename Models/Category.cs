using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce_Insanity.Models
{
    public class Category
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
                    throw new ArgumentException("Category name cannot be empty.");
                }
                _name = value;
            }
        }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public Category(string name)
        {
            Name = name;
        }
#pragma warning restore CS8618
    }
}
