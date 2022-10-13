using FastDo.Net.Application.Core;
using FastDo.Net.MongoDatabase.Abstractions;

namespace FastDo.Net.Application.Repositories.IdRepo
{
    public interface IIdRepository
    {
        Task<Result<EmptyClass>> Delete<T>(string id) where T : IId;
    }
}
