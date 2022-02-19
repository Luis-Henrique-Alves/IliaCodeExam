using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Shared;

namespace IliaCodeTest.Borders.UseCases
{
    public interface IGetOrdersByConsumerUseCase : IUseCase<GetOrdersByConsumerRequest,PagedResult<GetOrdersByConsumerResponse>>
    {
    }
}
