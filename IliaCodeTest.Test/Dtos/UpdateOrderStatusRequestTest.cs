using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using IliaCodeTest.Borders.Enums;
using System;
using Xunit;

namespace IliaCodeTest.Test.Dtos
{
    public class UpdateOrderStatusRequestTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var id = Guid.NewGuid();
            var orderStatus = faker.PickRandom<OrderStatus>();


            //Act
            var dto = new UpdateOrderStatusRequest();
            dto.IdOrder = id;
            dto.orderStatus = orderStatus;
           
         

            //Assert
            Assert.Equal(id, dto.IdOrder);
            Assert.Equal(orderStatus, dto.orderStatus);

        }


    }
}
