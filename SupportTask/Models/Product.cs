using SupportTask.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTask.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="You must enter the name of the product")]
        [MaxLength(6)]
        [MinLength(1)]
        
        
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1000,10000)]
        [MaxPrice(5000)]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }
      
        public Boolean EnableSize { get; set; }
            
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? company { get; set; }
    }
}
