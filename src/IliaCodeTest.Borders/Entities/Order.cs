using IliaTestExam.Borders.Enums;
using System;

namespace IliaTestExam.Borders.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }
        

    }
}
