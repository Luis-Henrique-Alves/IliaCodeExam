using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using System;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class GetConsumerResponseTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var pkConsumer = Guid.NewGuid();
            var name = faker.Person.FirstName;
            var email = faker.Person.Email;
            var mainDocument = faker.Person.Cpf();
        
            //Act
            var dto = new GetConsumerResponse();
            dto.PKCosumer = pkConsumer;
            dto.Name = name;
            dto.Email = email;
            dto.MainDocument = mainDocument;

            //Assert
            Assert.Equal(pkConsumer, dto.PKCosumer);
            Assert.Equal(name, dto.Name);
            Assert.Equal(email, dto.Email);
            Assert.Equal(mainDocument, dto.MainDocument);

        }


    }
}
