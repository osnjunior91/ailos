namespace Questao5.Application.Commands.Responses
{
    public class WithdrawCommandResponse
    {
        public WithdrawCommandResponse(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
