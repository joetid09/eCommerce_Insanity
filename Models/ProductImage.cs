using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class ProductImage
    {
        private int _productId;
        private string _imageFileName;

        [Key]
        public int Id { get; set; }

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

        [Required]
        public string ImageFileName
        {
            get { return _imageFileName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Image file name cannot be empty.");
                }
                _imageFileName = value;
            }
        }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public ProductImage(int productId, string imageFileName)
        {
            ProductId = productId;
            ImageFileName = imageFileName;
        }
    }
}
