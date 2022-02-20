using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Repository.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IliaCodeTest.Repository.Queries;
using IliaCodeTest.Borders.Repositories;
using IliaCodeTest.Borders.Models.Pagination;
using IliaTestExam.Borders.Entities;
using IliaTestExam.Borders.Dtos;

namespace IliaCodeTest.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IIliaCodeTestDbContext _dbContext;

        public OrderRepository(IIliaCodeTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task RegisterNewOrderRequestAsync (RegisterNewOrderRequest request)
        {
            var parameter = new
            {
                Id = Guid.NewGuid(),
                Price = request.Price,
                Description = request.Description,
                IdConsumer = request.IdCostumer
            };

            await using var connection = _dbContext.OpenConnection();
            await connection.ExecuteAsync(OrderRepositoryQueries.RegisterNewOrderRequest, parameter);

        }

        public async Task<PagedResult<OrderDTO>> GetOrdersByConsumer(GetOrdersByConsumerRequest request)
        {
            var result = new PagedResult<OrderDTO>();

            var parameter = new
            {
                CPF = request.CPF,
                PageNumber = request.PageSettings.PageNumber,
                PageSize = request.PageSettings.PageSize


            };

            await using var connection = _dbContext.OpenConnection();
            var query = await connection.QueryAsync<OrderDTO>(sql: string.Format(OrderRepositoryQueries.GetOrdersByConsumer), param: parameter);
            result.Data = query;
            result.Total = query.Count();

            return result;

        }


        public async Task UpdateOrderStatus(UpdateOrderStatusRequest request)
        {
            var parameter = new
            {
                IdOrder = request.IdOrder,
                OrderStatus = request.orderStatus,

            };

            await using var connection = _dbContext.OpenConnection();
            await connection.ExecuteAsync(OrderRepositoryQueries.UpdateOrderStatus, parameter);

        }
    }
}
