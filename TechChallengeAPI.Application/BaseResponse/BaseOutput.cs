namespace RCLocacoes.Application.BaseResponse
{
    public class BaseOutput<T> : Response
    {
        public BaseOutput()
        {
            Response = default!;
        }

        public BaseOutput(T response)
        {
            Response = response;
        }

        public T Response { get; set; }
    }
}
