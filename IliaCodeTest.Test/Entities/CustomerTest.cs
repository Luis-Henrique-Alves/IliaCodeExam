using IliaTestExam.Borders.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace IliaTestExam.Test.Entities
{
    public class CustomerTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {
            //arrange
            var  id = Guid.NewGuid();
            var name = "Teste";
            var email = "teste@teste.com.br";
            var mainDocument = "456798132456";
            var Orders = new List<Order>();

            //Act
            var customer = new Customer();
            customer.Id = id;
            customer.Email = email;
            customer.Name = name;
            customer.MainDocument = mainDocument;
            customer.Orders = Orders;

            //Assert

            Assert.Equal(id, customer.Id);
            Assert.Equal(name, customer.Name);
            Assert.Equal(email, customer.Email);
            Assert.Equal(mainDocument, customer.MainDocument);
            Assert.Equal(Orders, customer.Orders);
        }


    }
}
