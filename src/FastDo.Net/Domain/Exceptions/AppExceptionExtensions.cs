using FastDo.Net.Domain.Consts;
using FastDo.Net.Domain.Errors.ErrorMessages;
using FastDo.Net.Domain.Errors.Models;
using FastDo.Net.Domain.Errors;

namespace FastDo.Net.Domain.Exceptions
{
    public static class AppExceptionExtensions
    {
        public static ErrorModel GetErrorModel(this AppException appException, IGetErrorMessage getErrorMessage, string languageCode = GlobalConsts.DefaultLanguage)
        {
            if (appException.ErrorCode is null)
            {
                var errorCodeUnknown = (ErrorCode)FastDoErrorCodes.UnknownError;
                var errorModelUnknown = new ErrorModel(getErrorMessage.GetErrorMessage(errorCodeUnknown, languageCode), errorCodeUnknown);
                return errorModelUnknown;
            }

            var errorModel = new ErrorModel(getErrorMessage.GetErrorMessage((ErrorCode)appException.ErrorCode, languageCode), (ErrorCode)appException.ErrorCode, appException.ErrorDetail);
            return errorModel;
        }
    }
}
