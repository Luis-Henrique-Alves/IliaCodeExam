using IliaTestExam.Borders.Entities;
using IliaTestExam.Borders.Enums;
using System;
using Xunit;

namespace IliaTestExam.Test.Entities
{
    public class OrderTest
    {

        [Fact]

        public void Shout_Set_Propeties()
        {
            //arrange
            var Id = Guid.NewGuid();
            var Description = "Teste";
            var Status = OrderStatus.Send;
            var Customer = new Customer();
            var Price =10;
            var CreatedAt = System.DateTime.Now;

        //Act
            var order = new Order();
            order.Id = Id;
            order.Description = Description;
            order.Status = Status;
            order.Customer = Customer;
            order.Price = Price;
            order.CreatedAt = CreatedAt;

            //Assert

            Assert.Equal(Id, order.Id);
            Assert.Equal(Description, order.Description);
            Assert.Equal(Status, order.Status);
            Assert.Equal(Customer, order.Customer);
            Assert.Equal(Price, order.Price);
            Assert.Equal(CreatedAt, order.CreatedAt);
        }


    }
}
