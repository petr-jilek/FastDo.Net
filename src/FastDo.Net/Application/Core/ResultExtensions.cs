using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors.ErrorMessages;
using FastDo.Net.Domain.Errors;
using FastDo.Net.Domain.Errors.Models;

namespace FastDo.Net.Application.Core
{
    public static class ResultExtensions
    {
        public static ErrorModel GetErrorModel<T>(this Result<T> result, IGetErrorMessage getErrorMessage, string languageCode = GlobalConsts.DefaultLanguage)
        {
            if (result.ErrorCode is null)
            {
                var errorCodeUnknown = (ErrorCode)FastDoErrorCodes.UnknownError;
                var errorModelUnknown = new ErrorModel(getErrorMessage.GetErrorMessage(errorCodeUnknown, languageCode), errorCodeUnknown);
                return errorModelUnknown;
            }

            var errorModel = new ErrorModel(getErrorMessage.GetErrorMessage((ErrorCode)result.ErrorCode, languageCode), (ErrorCode)result.ErrorCode, result.ErrorDetail);
            return errorModel;
        }
    }
}
