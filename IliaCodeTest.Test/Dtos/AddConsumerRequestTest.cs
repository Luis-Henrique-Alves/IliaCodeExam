using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class AddConsumerRequestTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var name = faker.Person.FirstName;
            var email = faker.Person.Email;
            var mainDocument = faker.Person.Cpf();
        
            //Act
            var dto = new AddConsumerRequest();
            dto.Name = name;
            dto.Email = email;
            dto.MainDocument = mainDocument;

            //Assert
            Assert.Equal(name, dto.Name);
            Assert.Equal(email, dto.Email);
            Assert.Equal(mainDocument, dto.MainDocument);

        }


    }
}
