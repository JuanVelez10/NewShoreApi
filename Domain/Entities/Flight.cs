using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Flight
    {
        [Required]
        [DataType(DataType.Text)]
        public string? Origin { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? Destination { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public virtual Transport? Transport { get; set; }
    }
}
