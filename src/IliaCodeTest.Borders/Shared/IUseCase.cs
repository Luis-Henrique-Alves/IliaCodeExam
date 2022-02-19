using System.Threading.Tasks;

namespace IliaCodeTest.Borders.Shared
{
    public interface IUseCase<TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }
}