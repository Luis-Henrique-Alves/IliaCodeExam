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
using IliaCodeTest.Borders.Entities;
using IliaCodeTest.Borders.Dtos;

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

        public async Task<bool> CheckIfExist(string Email, string CPF)
        {
            var parameter = new
            {
                Email = Email,
                MainDocument = CPF
            };

            await using var connection = _dbContext.OpenConnection();

            return await connection.QueryFirstOrDefaultAsync<Customer>(ConsumerRepositoryQueries.CheckAlreadyExists, parameter).ContinueWith(x => x.Result != null);
             
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
            await using var connection = _dbContext.OpenConnection();
            var query = await connection
                .QueryAsync<GetConsumerWithOrdersResponse, OrderDTO, GetConsumerWithOrdersResponse>(
                sql: string.Format(ConsumerRepositoryQueries.GetConsumersWithOrders),
                map: (consumer, order) =>
                 {
                     if (order != default)
                         consumer.orders.Add(order);

                     return consumer;
                 },
                splitOn: "Id",
                param: parameter);

            var response = query.GroupBy(x => x.MainDocument).Select(group =>
            {
                var combinedConsumer = group.First();

                combinedConsumer.orders = query.Where(x => x.MainDocument == combinedConsumer.MainDocument).SelectMany(x => x.orders).GroupBy(x => x.Id).Select(g => g.First()).ToList();

                return combinedConsumer;
            });

            result.Data = response;

            result.Total = response.Count();


            return result;

        }
    }
}
