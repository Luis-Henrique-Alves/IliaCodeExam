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

namespace IliaCodeTest.Repository.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly IIliaCodeTestDbContext _dbContext;

        public ConsumerRepository (IIliaCodeTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddConsumerAsync(AddConsumerRequest request)
        {
            var parameter = new
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                MainDocument = request.MainDocument
            };

            await using var connection = _dbContext.OpenConnection();
            await connection.ExecuteAsync(ConsumerRepositoryQueries.AddConsumerQuery, parameter);
  
        }

        public async Task<PagedResult<GetConsumerResponse>> GetConsumersAsync(GetConsumerRequest request)
        {
            var result = new PagedResult<GetConsumerResponse>();

            var parameter = new
            {
                Name = request.Name,
                Email = request.Email,
                MainDocument = request.MainDocument,
                PageNumber = request.PageSettings.PageNumber,
                PageSize = request.PageSettings.PageSize


            };

            await using var connection = _dbContext.OpenConnection();
            var query = await connection.QueryAsync<GetConsumerResponse>(sql: string.Format(ConsumerRepositoryQueries.GetConsumers), param: parameter);
            result.Data = query;
            result.Total = query.Count();

            return result;

        }


        public async Task<PagedResult<GetConsumerWithOrdersResponse>> GetConsumersWithOrdersAsync(GetConsumerWithOrdersRequest request)
        {
            var result = new PagedResult<GetConsumerWithOrdersResponse>();

            var parameter = new
            {
                Name = request.Name,
                Email = request.Email,
                MainDocument = request.MainDocument,
                PageNumber = request.PageSettings.PageNumber,
                PageSize = request.PageSettings.PageSize


            };
            //await using var connection = _dbContext.OpenConnection();
            //var query = await connection
            //    .QueryAsync<GetConsumerWithOrdersResponse, Order>(
            //    sql: string.Format(ConsumerRepositoryQueries.GetConsumersWithOrders),
            //    map:(consumer,order) =>
            //    {
            //        if (order != default)
            //            consumer.orders.Add(order);

            //        return consumer;
            //    },
            //    splitOn: "pk-order,Id",
            //    param: parameter);
           
            //result.Data = query;
            //result.Total = query.Count();


            return result;

        }
    }
}
