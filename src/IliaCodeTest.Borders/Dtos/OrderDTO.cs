﻿using IliaTestExam.Borders.Enums;
using System;

namespace IliaTestExam.Borders.Dtos
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        

    }
}
