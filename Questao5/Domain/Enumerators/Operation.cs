using System.ComponentModel;
using static Questao5.Domain.Enumerators.Operation;

namespace Questao5.Domain.Enumerators
{
    public class Operation
    {
        public enum FinancialOperationType
        {
            [Description("C")]
            Credit,

            [Description("D")]
            Debit
        }
    }

    public static class FinancialOperationTypeExtensions
    {
        public static string ToValue(this FinancialOperationType type)
        {
            var memInfo = typeof(FinancialOperationType).GetMember(type.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }

        public static FinancialOperationType ToFinancialOperationType(this string value)
        {
            foreach (FinancialOperationType type in Enum.GetValues(typeof(FinancialOperationType)))
            {
                if (type.ToValue() == value)
                {
                    return type;
                }
            }
            throw new BusinessException(Erros.ErrorType.INVALID_TYPE);
        }
    }
}
