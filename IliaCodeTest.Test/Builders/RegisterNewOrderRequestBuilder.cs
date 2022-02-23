using Bogus;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using System;


namespace IliaCodeTest.Test.Builders
{
    public class RegisterNewOrderRequestBuilder

    {
        private readonly RegisterNewOrderRequest _istance;
        private readonly Faker _faker;

        public RegisterNewOrderRequestBuilder()
        {
            _faker = FakerPtBr.CreateFaker();


            _istance = new RegisterNewOrderRequest()
            {
                Description = _faker.Random.String(),
                IdCostumer = Guid.NewGuid(),
                Price = _faker.Finance.Random.Decimal(),
            };
        }

        public RegisterNewOrderRequest Build()
        {
            return _istance;
        }

    }


}
