using Questao5.Domain.Enumerators;
namespace Questao5.Domain.Entities
{
    public class Operation : Entity
    {
        public Operation(dynamic obj) 
        {
            AccountId = obj.idcontacorrente;
            MovementDate = obj.datamovimento;
            Value = Convert.ToDecimal(obj.valor);
            OperationType = ((string)obj.tipomovimento).ToFinancialOperationType();
        }

        public string AccountId { get; set; }
        public string MovementDate { get; set; }
        public Enumerators.Operation.FinancialOperationType OperationType { get; set; }
        public decimal Value { get; set; }
    }
}
