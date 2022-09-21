using ApiCommon.API.Application.Core;
using ApiCommon.MongoDatabase.Abstractions;

namespace ApiCommon.API.Application.Repositories.OrderRepo
{
    public interface IOrderRepository
    {
        Task<Result<EmptyClass>> MoveUp<T>(string id) where T : IId, IOrder;
        Task<Result<EmptyClass>> MoveDown<T>(string id) where T : IId, IOrder;
    }
}
