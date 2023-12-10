namespace Questao5.Domain.Entities
{
    public class Idempotence : Entity
    {
        public Idempotence(string requestData, string resultData)
        {
            RequestData = requestData;
            ResultData = resultData;
        }

        public string RequestData { get; private set; }
        public string ResultData { get; private set; }
    }
}
