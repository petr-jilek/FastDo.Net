using FastDo.Net.Domain.Errors.Models;

namespace FastDo.Net.Domain.Errors.ErrorMessages
{
    public interface IGetErrorMessage
    {
        string GetErrorMessage(ErrorCode errorCode, string lang);
    }
}
