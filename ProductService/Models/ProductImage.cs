using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class ProductImage
    {
        public int IdProductImage { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Image { get; set; }
        public int IdProduct { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deactivated { get; set; }
        public bool Deleted { get; set; }
        public virtual Product ProductNavegation { get; set; }
    }
}
