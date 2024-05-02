namespace DomsGraphQL.Exceptions;

public class CustomExceptionHandler : IErrorFilter
{
    public IError OnError(IError error)
    {
        var customError = new CustomError
        {
            Message = error.Message,
            Code = error.Code
        };

        if (error.Exception != null)
        {
            customError.Message = error.Exception.Message;
            if (error.Exception.Data != null && error.Exception.Data.Contains("error"))
                customError = error.Exception.Data["error"] as CustomError;
        }

        error = error.WithCode(customError.Code);
        return error.WithMessage(customError.Message);
    }
}