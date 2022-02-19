using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Shared;

namespace IliaCodeTest.Borders.UseCases
{
    public interface IGetConsumerWithOrdersUseCase : IUseCase<GetConsumerWithOrdersRequest,PagedResult<GetConsumerWithOrdersResponse>>
    {
    }
}
