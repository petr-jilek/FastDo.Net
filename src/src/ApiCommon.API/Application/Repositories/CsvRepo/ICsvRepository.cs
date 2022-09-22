using ApiCommon.API.Application.Core;

namespace ApiCommon.API.Application.Repositories.CsvRepo
{
    public interface ICsvRepository
    {
        Task<Result<byte[]>> GetCsvAllItems<T>();
    }
}
