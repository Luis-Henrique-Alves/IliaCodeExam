using System;

namespace IliaCodeTest.Borders.Dtos
{
    public class RegisterNewOrderRequest
    {
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid IdCostumer { get; set; }
    }
}
