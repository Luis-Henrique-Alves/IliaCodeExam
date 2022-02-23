using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class GetOrdersByConsumerRequestTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var cpf = faker.Person.Cpf();
        
            //Act
            var dto = new GetOrdersByConsumerRequest();
            dto.CPF = cpf;

            //Assert
            Assert.Equal(cpf, dto.CPF);


        }


    }
}
