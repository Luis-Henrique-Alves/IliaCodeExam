using IliaCodeTest.Borders.Dtos;
using IliaCodeTest.Borders.Models.Pagination;
using System.Threading.Tasks;

namespace IliaCodeTest.Borders.Repositories
{
    public interface IConsumerRepository
    {
        Task AddConsumerAsync(AddConsumerRequest request);
        Task<PagedResult<GetConsumerResponse>> GetConsumersAsync(GetConsumerRequest request);
        Task<PagedResult<GetConsumerWithOrdersResponse>> GetConsumersWithOrdersAsync(GetConsumerWithOrdersRequest request);

    }
}
