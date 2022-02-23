using Bogus;
using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliaCodeTest.Test.Builders
{
    public class GetConsumerWithOrderRequestBuilder

    {
        private readonly GetConsumerWithOrdersRequest _istance;
        private readonly Faker _faker;

        public GetConsumerWithOrderRequestBuilder()
        {
            _faker = FakerPtBr.CreateFaker();


            _istance = new GetConsumerWithOrdersRequest()
            {
                Name = _faker.Person.FirstName,
                Email = _faker.Person.Email,
                MainDocument = _faker.Person.Cpf(),

            };
        }

        public GetConsumerWithOrdersRequest Build()
        {
            return _istance;
        }

    }


}
