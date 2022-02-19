using IliaTestExam.Borders.Entities;
using System.Collections.Generic;

namespace IliaCodeTest.Borders.Dtos
{
    public class GetOrdersByConsumerResponse
    {
          public ICollection<Order> orders { get; set; }

    }
}
