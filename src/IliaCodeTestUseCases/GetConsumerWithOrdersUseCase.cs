﻿using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.UseCases;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IliaCodeTest.UseCases
{
    public class GetConsumerWithOrdersUseCase : IGetConsumerWithOrdersUseCase
    {
        private readonly ILogger<GetConsumerWithOrdersUseCase> _logger;

        public GetConsumerWithOrdersUseCase(
            ILogger<GetConsumerWithOrdersUseCase> logger
        )
        {
            _logger = logger;

        }

        public async Task<UseCaseResponse<PagedResult<GetConsumerWithOrdersResponse>>> Execute (GetConsumerWithOrdersRequest getConsumerWithRequest)
        {

            var response = new UseCaseResponse<PagedResult<GetConsumerWithOrdersResponse>>();

            try
            {
                return response.SetResult(new PagedResult<GetConsumerWithOrdersResponse>());
            }

            catch (Exception ex)
            {

                _logger.LogError(ex, "teste");
                return response.SetInternalServerError("error");

            }


        }
    }
}