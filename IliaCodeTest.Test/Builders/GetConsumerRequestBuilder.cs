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
    public class GetConsumerRequestBuilder

    {
        private readonly GetConsumerRequest _istance;
        private readonly Faker _faker;

        public GetConsumerRequestBuilder()
        {
            _faker = FakerPtBr.CreateFaker();


            _istance = new GetConsumerRequest()
            {
                Name = _faker.Person.FirstName,
                Email = _faker.Person.Email,
                MainDocument = _faker.Person.Cpf(),

            };
        }

        public GetConsumerRequest Build()
        {
            return _istance;
        }

    }


}
