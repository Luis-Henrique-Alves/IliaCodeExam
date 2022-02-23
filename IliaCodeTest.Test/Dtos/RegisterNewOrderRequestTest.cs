using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using IliaCodeTest.Borders.Enums;
using System;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class RegisterNewOrderRequestTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var id = Guid.NewGuid();
            var price = faker.Random.Decimal();
            var description = faker.Random.String();
       


            //Act
            var dto = new RegisterNewOrderRequest();
            dto.IdCostumer = id;
            dto.Description = description;
            dto.Price = price;
         

            //Assert
            Assert.Equal(id, dto.IdCostumer);
            Assert.Equal(price, dto.Price);
            Assert.Equal(description, dto.Description);

        }


    }
}
