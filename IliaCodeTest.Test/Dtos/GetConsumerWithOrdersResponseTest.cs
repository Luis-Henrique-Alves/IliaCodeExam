using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Entities;
using System.Collections.Generic;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class GetConsumerWithOrdersResponseTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var name = faker.Person.FirstName;
            var email = faker.Person.Email;
            var mainDocument = faker.Person.Cpf();
            var orders = new List<OrderDTO>();

            //Act
            var dto = new GetConsumerWithOrdersResponse();
            dto.orders = orders;
            dto.Name = name;
            dto.Email = email;
            dto.MainDocument = mainDocument;

            //Assert
            Assert.Equal(orders, dto.orders);
            Assert.Equal(name, dto.Name);
            Assert.Equal(email, dto.Email);
            Assert.Equal(mainDocument, dto.MainDocument);

        }


    }
}
