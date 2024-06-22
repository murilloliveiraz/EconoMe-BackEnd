using System.ComponentModel.DataAnnotations;

namespace EconoMe.Api.Domain.Models
{
    public abstract class Transaction 
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
        [Required]
        public long TransactionCategoryId { get; set; }
        public TransactionCategory  TransactionCategory { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo do valor original é obrigatório")]
        public double OriginalAmount { get; set; }
        public string? Note { get; set; } = string.Empty;
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required(ErrorMessage = "A data de vencimento é obrigatório")]
        public DateTime ExpirationDate { get; set; }
        public DateTime? InactivationDate { get; set; }
        public DateTime? ReferenceDate  { get; set; }
        
    }
}