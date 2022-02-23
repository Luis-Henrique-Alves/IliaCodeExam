using Bogus.Extensions.Brazil;
using IliaCodeTest.Test.Utils;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Enums;
using System;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class OrdersDTOTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var id = Guid.NewGuid();
            var createdAt = DateTime.Now;
            var price = faker.Random.Decimal();
            var description = faker.Random.String();
            var orderStatus = faker.PickRandom<OrderStatus>();


            //Act
            var dto = new OrderDTO();
            dto.Id = id;
            dto.CreatedAt = createdAt;
            dto.Price = price;
            dto.Description = description;
            dto.Status = orderStatus;


            //Assert
            Assert.Equal(id, dto.Id);
            Assert.Equal(createdAt, dto.CreatedAt);
            Assert.Equal(price, dto.Price);
            Assert.Equal(description, dto.Description);
            Assert.Equal(orderStatus, dto.Status);

        }


    }
}
