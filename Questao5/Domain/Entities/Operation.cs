using static Questao5.Domain.Enumerators.Operation;

namespace Questao5.Domain.Entities
{
    public class Operation : Entity
    {
        public string AccountId { get; set; }
        public string MovementDate { get; set; }
        public FinancialOperationType OperationType { get; set; }
        public decimal Value { get; set; }
    }
}
