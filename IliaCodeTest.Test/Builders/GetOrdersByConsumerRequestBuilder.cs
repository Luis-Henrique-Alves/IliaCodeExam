using Bogus;
using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;


namespace IliaCodeTest.Test.Builders
{
    public class GetOrdersByConsumerRequestBuilder

    {
        private readonly GetOrdersByConsumerRequest _istance;
        private readonly Faker _faker;

        public GetOrdersByConsumerRequestBuilder()
        {
            _faker = FakerPtBr.CreateFaker();


            _istance = new GetOrdersByConsumerRequest()
            {
                CPF = _faker.Person.Cpf()

            };
        }

        public GetOrdersByConsumerRequest Build()
        {
            return _istance;
        }
    }

 
}
