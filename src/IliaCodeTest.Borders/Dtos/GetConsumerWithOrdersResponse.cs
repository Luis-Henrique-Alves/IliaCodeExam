using IliaTestExam.Borders.Dtos;
using System.Collections.Generic;

namespace IliaCodeTest.Borders.Dtos
{
    public class GetConsumerWithOrdersResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MainDocument { get; set; }
        public List<OrderDTO> orders { get; set; }

        public GetConsumerWithOrdersResponse()
        {
            orders = new List<OrderDTO>();
        }

    }
}
