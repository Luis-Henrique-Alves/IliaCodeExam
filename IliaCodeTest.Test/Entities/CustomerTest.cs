using Bogus.Extensions.Brazil;
using IliaCodeTest.Test.Utils;
using IliaCodeTest.Borders.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace IliaCodeTest.Test.Entities
{
    public class CustomerTest
    {
    
        [Fact]

        public void Shout_Set_Propeties()
        {

            //arrange
            var faker = FakerPtBr.CreateFaker();
            var  id = Guid.NewGuid();
            var name = faker.Person.FirstName;
            var email = faker.Person.Email;
            var mainDocument = faker.Person.Cpf();
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
