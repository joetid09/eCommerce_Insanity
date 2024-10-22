using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_Insanity.Models;

namespace eCommerce_Insanity.DTOs
{
    public class UpdateProductDTO
    {
        public string? Name;
        public string? Description { get; set; }

        public decimal? Price;

        public int? CategoryId;

        public string? ImageUrl { get; set; }

        public int? StockQuantity { get; set; }

        public string? SKU;
    }
}
