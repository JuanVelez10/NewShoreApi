using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Store
    {
        [Required]
        [DataType(DataType.Text)]
        public string? Origin { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? Destination { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? Response { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Create { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Update { get; set; }
    }
}
