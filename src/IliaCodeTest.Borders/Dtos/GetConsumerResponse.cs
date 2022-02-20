using System;

namespace IliaCodeTest.Borders.Dtos
{
    public class GetConsumerResponse
    {
        public Guid PKCosumer { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MainDocument { get; set; }
    }
}
