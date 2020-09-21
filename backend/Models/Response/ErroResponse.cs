using System;

namespace backend.Models.Response
{
    public class ErroResponse
    {
        public ErroResponse(Exception ex, int codigo)
        {
            this.erro = ex.Message;
            this.codigo = codigo;

        }

        public string erro { get; set; }
        public int codigo { get; set; } 
    }
}