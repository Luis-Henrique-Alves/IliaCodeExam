using IliaCodeTest.Borders.Models.Pagination;

namespace IliaCodeTest.Borders.Dtos
{
    public class GetConsumerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MainDocument { get; set; }
        public PageSettings PageSettings { get; set; }

        public GetConsumerRequest()
        {
            PageSettings = new PageSettings();
        }
    }
}
