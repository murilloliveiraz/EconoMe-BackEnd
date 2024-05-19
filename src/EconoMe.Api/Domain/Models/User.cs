using System.ComponentModel.DataAnnotations;

namespace EconoMe.Api.Domain.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo de Senha é obrigatório")]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime RegistrationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
        
    }
}