using IliaTestExam.Borders.Entities;
using System.Collections.Generic;

namespace IliaCodeTest.Borders.Dtos
{
    public class GetConsumerWithOrdersResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MainDocument { get; set; }
        public ICollection<Order> orders { get; set; }

    }
}
