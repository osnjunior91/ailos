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

    public override string Message
    {
        get
        {
            string errorMessage = Error switch
            {
                ErrorType.INVALID_ACCOUNT => "Apenas contas correntes cadastradas podem receber movimentação.",
                ErrorType.INACTIVE_ACCOUNT => "Apenas contas correntes ativas podem receber movimentação.",
                ErrorType.INVALID_VALUE => "Apenas valores positivos podem ser recebidos.",
                ErrorType.INVALID_TYPE => "Apenas os tipos 'débito' ou 'crédito' podem ser aceitos.",
                _ => base.Message
            };

            return $"Erro: {Error}. Tipo: {errorMessage}";
        }
    }
}
