using System.ComponentModel.DataAnnotations;

namespace IliaCodeTest.Borders.Dtos
{
    public class AddConsumerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MainDocument { get; set; }
    }
}
