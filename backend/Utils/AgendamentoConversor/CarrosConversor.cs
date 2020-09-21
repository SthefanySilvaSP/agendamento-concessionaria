using System.Collections.Generic;


namespace backend.Utils.AgendamentoConversor
{
    public class CarrosConversor
    {
        public List<Models.Response.CarrosAgendarResponse> ParaResponse (List<Models.TbCarro> tbs)
        {
            List<Models.Response.CarrosAgendarResponse> resp = new List<Models.Response.CarrosAgendarResponse>();
            
            foreach(Models.TbCarro item in tbs)
            {
                Models.Response.CarrosAgendarResponse carro = new Models.Response.CarrosAgendarResponse();
                carro.ID = item.IdCarro;
                carro.Nome = item.NmModelo + " " + item.DsPlaca;

                resp.Add(carro);
            }

            return resp;
        } 
    }
}