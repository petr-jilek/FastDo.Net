using FastDo.Net.Api.Application.Core;

namespace FastDo.Net.Api.Application.Repositories.CsvRepo
{
    public interface ICsvRepository
    {
        Task<Result<byte[]>> GetCsvAllItems<T>();
    }
}
