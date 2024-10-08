using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce_Insanity.Models
{
    public class ReviewImage
    {
        private int _reviewId;
        private string _imageFileName;

        [Key]
        public int Id { get; set; }

        [Required]
        public int ReviewId
        {
            get { return _reviewId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Review ID must be a positive integer.");
                }
                _reviewId = value;
            }
        }

        [ForeignKey("ReviewId")]
        public Review Review { get; set; }

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
        //suppressing warning that corresponding private fields cannot be null
        //validation/check dont on set
#pragma warning disable CS8618
        public ReviewImage(int reviewId, string imageFileName)
        {
            ReviewId = reviewId;
            ImageFileName = imageFileName;
        }
#pragma warning restore CS8618
    }
}
