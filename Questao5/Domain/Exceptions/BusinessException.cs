using System;
using static Questao5.Domain.Enumerators.Erros;

public class BusinessException : Exception
{
    public ErrorType Error { get; }

    public BusinessException(ErrorType errorType)
    {
        Error = errorType;
    }

    public BusinessException(ErrorType errorType, string message) : base(message)
    {
        Error = errorType;
    }

    public BusinessException(ErrorType errorType, string message, Exception innerException) : base(message, innerException)
    {
        Error = errorType;
    }
}
