using System.ComponentModel.DataAnnotations;

namespace EconoMe.Api.Domain.Models
{
    public class ExpenseCategory
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        [Required]
        public DateTime RegistrationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
        
    }
}