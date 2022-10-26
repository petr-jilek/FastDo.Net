using ApiCommon.API.Application.Core;
using ApiCommon.MongoDatabase.Abstractions;

namespace ApiCommon.API.Application.Repositories.IdRepo
{
    public interface IIdRepository
    {
        Task<Result<EmptyClass>> Delete<T>(string id) where T : IId;
    }
}
