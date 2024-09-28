using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class Review
    {
        private string _userId;
        private int _productId;
        private int _rating;

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
                    throw new ArgumentException("UserID is required for reviews.");
                }
                _userId = value;
            }
        }

        [Required]
        [ForeignKey("Product")]
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ProductId is required for reviews.");
                }
                _productId = value;
            }
        }

        [Required]
        [Range(1, 5)]
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Rating must be between 1 and 5.");
                }
                _rating = value;
            }
        }

        public string? Comment { get; set; }
        public ICollection<ReviewImage> Images { get; set; } = new List<ReviewImage>(); // For multiple images

        public User User { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Constructor
        public Review(string userId, int productId, int rating)
        {
            UserId = userId;
            ProductId = productId;
            Rating = rating;
        }
    }
}
