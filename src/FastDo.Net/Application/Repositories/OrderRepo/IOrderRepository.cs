using FastDo.Net.Application.Core;
using FastDo.Net.MongoDatabase.Abstractions;

namespace FastDo.Net.Application.Repositories.OrderRepo
{
    public interface IOrderRepository
    {
        Task<Result<EmptyClass>> Higher<T>(string id) where T : IId, IOrder;
        Task<Result<EmptyClass>> Lower<T>(string id) where T : IId, IOrder;
    }
}
