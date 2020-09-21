namespace backend.Models.Response
{
    public class MensagemResponse
    {
        public MensagemResponse(string msg)
        {
            this.mensagem = msg;
        }
        
        public string mensagem { get; set; }
    }
}