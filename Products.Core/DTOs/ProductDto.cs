using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Price { get; set; }
        public DateTime? PurchaseDate { get; set; }
        [Required]
        public bool? Active { get; set; }
    }
}
