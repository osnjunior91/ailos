namespace Questao5.Domain.Entities
{
    public class Account : Entity
    {
        public Account(string accountId, int number, string name, bool isActive, List<Operation> operations)
        {
            SetId(accountId);
            Number = number;
            Name = name;
            IsActive = isActive;
            operations = new List<Operation>(operations);
        }

        public Account(dynamic obj)
        {
            SetId(obj.idcontacorrente);
            Number = (int)obj.numero;
            Name = obj.nome;
            IsActive = obj.ativo == 1;
        }

        public int Number { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        private List<Operation> operations;
        public IReadOnlyList<Operation> Operations => operations;
        public void AddOperation(Operation operation)
        {
            operations.Add(operation);
        }
        public void SetOperations (List<Operation> operations) => this.operations = new List<Operation>(operations);
    }
}
