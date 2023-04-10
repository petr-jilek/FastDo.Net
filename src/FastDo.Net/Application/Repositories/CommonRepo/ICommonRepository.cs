using FastDo.Net.Application.Core;

namespace FastDo.Net.Application.Repositories.CommonRepo
{
    public interface ICommonRepository
    {
        Task<Result<EmptyClass>> DeleteAll<T>();
    }
}
