using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using IliaTestExam.Borders.Dtos;
using System.Threading.Tasks;

namespace IliaCodeTest.Borders.Repositories
{
    public interface IOrderRepository
    {
        Task RegisterNewOrderRequestAsync(RegisterNewOrderRequest request);
        Task<PagedResult<OrderDTO>> GetOrdersByConsumer(GetOrdersByConsumerRequest request);
        Task UpdateOrderStatus(UpdateOrderStatusRequest request);

    }
}
