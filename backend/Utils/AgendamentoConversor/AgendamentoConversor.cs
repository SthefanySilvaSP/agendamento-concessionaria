using System.Collections.Generic;

namespace backend.Utils.AgendamentoConversor
{
    public class AgendamentoConversor
    {
        Database.AgendamentoDB db = new Database.AgendamentoDB();

        public List<Models.Response.AgendamentoResponse> ParaResponse (List<Models.TbAgendamento> req)
        {
            List<Models.Response.AgendamentoResponse> resp = new List<Models.Response.AgendamentoResponse>();

            foreach(Models.TbAgendamento item in req)
            {        
                resp.Add(
                    new Models.Response.AgendamentoResponse() {
                        ID = item.IdAgendamento,
                        Carro = item.IdCarroNavigation.NmModelo + " " + item.IdCarroNavigation.DsPlaca,
                        Funcionario = item.IdFuncionarioNavigation.NmFuncionario,
                        Data = item.DtAgendamento,
                        Situacao = item.DsSituacao,
                        Estrelas = item.QtEstrelas,
                        Feedback = item.DsFeedback
                    }
                );
            }

            return resp;
        }

        public Models.TbAgendamento ParaTbAgendamento (Models.Request.AgendarTestDriveRequest req)
        {
            Models.TbAgendamento tb = new Models.TbAgendamento();

            tb.DtAgendamento = req.data;
            tb.IdCarro = req.IdCarro;

            return tb;
        }
        
    }
}