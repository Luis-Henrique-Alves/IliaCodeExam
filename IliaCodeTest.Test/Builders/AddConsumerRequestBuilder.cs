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
    public class AddConsumerRequestBuilder

    {
        private readonly AddConsumerRequest _istance;
        private readonly Faker _faker;

        public AddConsumerRequestBuilder()
        {
            _faker = FakerPtBr.CreateFaker();


            _istance = new AddConsumerRequest()
            {
                Name = _faker.Person.FirstName,
                Email = _faker.Person.Email,
                MainDocument = _faker.Person.Cpf()
            };
        }

        public AddConsumerRequest Build()
        {
            return _istance;
        }

        public AddConsumerRequestBuilder WithNameIsEmpty()
        {
            _istance.Name = String.Empty;
            return this;
        }

        public AddConsumerRequestBuilder WithEmailInvalid()
        {
            _istance.Email = "EmailInvalidTest";
            return this;
        }

        public AddConsumerRequestBuilder WithMainDocumentInvalid()
        {
            _istance.Email = "1234567890";
            return this;
        }

    }


}
