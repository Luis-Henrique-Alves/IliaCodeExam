using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaCodeTest.Borders.Shared;
using IliaCodeTest.Borders.Dtos;

namespace IliaCodeTest.Borders.UseCases
{
    public interface IGetOrdersByConsumerUseCase : IUseCase<GetOrdersByConsumerRequest,PagedResult<OrderDTO>>
    {
    }
}
