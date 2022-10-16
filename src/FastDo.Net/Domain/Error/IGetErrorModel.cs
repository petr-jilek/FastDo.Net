namespace FastDo.Net.Domain.Error
{
    public interface IGetErrorModel
    {
        ErrorModel GetErrorModel(string? errorCode, string lang);
    }
}
