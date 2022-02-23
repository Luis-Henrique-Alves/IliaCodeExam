using System;
using System.Collections.Generic;

namespace IliaCodeTest.Borders.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MainDocument { get; set; }
        public IEnumerable<Order> Orders { get; set; }
}
}
