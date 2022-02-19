using IliaTestExam.Borders.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IliaCodeTest.Borders.Dtos
{
    public class UpdateOrderStatusRequest
    {
     [Required]
     public Guid IdOrder { get; set; }

    [Required]
     public OrderStatus orderStatus { get; set; }
    }
}
