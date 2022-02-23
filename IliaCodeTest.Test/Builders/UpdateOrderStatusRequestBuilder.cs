using Bogus;
using Bogus.Extensions.Brazil;
using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Test.Utils;
using IliaCodeTest.Borders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliaCodeTest.Test.Builders
{
    public class UpdateOrderStatusRequestBuilder

    {
        private readonly UpdateOrderStatusRequest _istance;
        private readonly Faker _faker;

        public UpdateOrderStatusRequestBuilder()
        {
            _faker = FakerPtBr.CreateFaker();


            _istance = new UpdateOrderStatusRequest()
            {
                IdOrder = Guid.NewGuid(),
                orderStatus = _faker.PickRandom<OrderStatus>()

            };
        }

        public UpdateOrderStatusRequest Build()
        {
            return _istance;
        }

       

    }


}
