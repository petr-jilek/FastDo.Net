using FastDo.Net.Application.Core;

namespace FastDo.Net.Application.Repositories.CsvRepo
{
    public interface ICsvRepository
    {
        Task<Result<byte[]>> GetCsvAllItems<T>();
    }
}
