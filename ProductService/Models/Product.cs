using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Description { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El stock debe ser al menos 1.")]
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deactivated { get; set; }
        public bool Deleted { get; set; }
    }
}
