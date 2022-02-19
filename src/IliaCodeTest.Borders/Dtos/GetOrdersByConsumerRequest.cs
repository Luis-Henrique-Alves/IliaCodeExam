using IliaCodeTest.Borders.Models.Pagination;
using System.ComponentModel.DataAnnotations;

namespace IliaCodeTest.Borders.Dtos
{
    public class GetOrdersByConsumerRequest
    {
        [Required]
        public string CPF { get; set; }
        public PageSettings PageSettings { get; set; }

        public GetOrdersByConsumerRequest()
        {
            PageSettings = new PageSettings();
        }
    }
}
