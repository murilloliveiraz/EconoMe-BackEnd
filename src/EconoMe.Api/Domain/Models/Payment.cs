using System.ComponentModel.DataAnnotations;

namespace EconoMe.Api.Domain.Models
{
    public class Payment : Transaction
    {
        [Required(ErrorMessage = "O campo do valor pago é obrigatório")]
        public double AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }        
    }
}