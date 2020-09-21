using System;

namespace backend.Models.Response
{
    public class AgendamentoResponse
    {
        public int ID { get; set; }
        public string Carro { get; set; }
        public string Funcionario { get; set; }
        public DateTime? Data { get; set; } 
        public string Situacao { get; set; }
        public int? Estrelas { get; set; }
        public string Feedback { get; set; }
    }
}