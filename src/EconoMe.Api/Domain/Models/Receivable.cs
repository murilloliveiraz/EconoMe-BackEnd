using System.ComponentModel.DataAnnotations;

namespace EconoMe.Api.Domain.Models
{
    public class Receivable : Transaction 
    {
        
        [Required(ErrorMessage = "O campo do valor recebido é obrigatório")]
        public double AmountReceived { get; set; }
        public DateTime? ReceiptDate { get; set; }    
    }
}