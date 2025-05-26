using AuthService.Models;

namespace AuthService.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool Desactivated { get; set; }
        public bool Deleted { get; set; }
        public int IdRole { get; set; }
        public virtual Role RoleNavegation { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
