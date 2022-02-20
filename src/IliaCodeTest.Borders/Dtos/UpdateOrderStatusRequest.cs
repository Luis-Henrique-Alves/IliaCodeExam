using System;
using System.ComponentModel.DataAnnotations;

namespace IliaCodeTest.Borders.Dtos
{
    public class RegisterNewOrderRequest
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid IdCostumer { get; set; }
    }
}
