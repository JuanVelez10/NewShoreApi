using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Transport
    {
        [Required]
        [DataType(DataType.Text)]
        public string? FlightCarrier { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? FlightNumber { get; set; }

    }

}
