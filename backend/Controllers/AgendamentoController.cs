using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AgendamentoController : ControllerBase
    {
        Business.AgendamentoBusiness business = new Business.AgendamentoBusiness();
        Utils.AgendamentoConversor.Login conversorLogin = new Utils.AgendamentoConversor.Login();
        Utils.AgendamentoConversor.CarrosConversor conversorCarros = new Utils.AgendamentoConversor.CarrosConversor();
        Utils.AgendamentoConversor.AgendamentoConversor conversorAgendar = new Utils.AgendamentoConversor.AgendamentoConversor();

        [HttpPost("login")]
        public ActionResult<Models.Response.LoginResponse> FazerLogin (Models.Request.LoginRequest req)
        {
            try 
            {
                Models.TbLogin tb = business.Login(conversorLogin.ParaTbLogin(req));
                string nome = business.NomeUsuario(tb);

                return conversorLogin.ParaLoginResponse(tb, nome);

            }
            catch(Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(ex, 400));
            }
        }

        [HttpGet("carros")]
        public ActionResult<List<Models.Response.CarrosAgendarResponse>> ListarCarros ()
        {
            try 
            {
                List<Models.TbCarro> carros = business.ListarCarros();
                return conversorCarros.ParaResponse(carros);

            }
            catch(Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(ex, 400));

            }
        } 

        [HttpPost("agendar")]
        public ActionResult<Models.Response.MensagemResponse> AgendarTestDrive(Models.Request.AgendarTestDriveRequest req)
        {
            try 
            {
                business.AgendarTestDrive( req.IdLogin, 
                    conversorAgendar.ParaTbAgendamento(req));

                return new Models.Response.MensagemResponse("Agendamento concluído com sucesso");

            }
            catch(Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(ex, 400));

            }
        }

        [HttpGet("agendamentos/{id}")]
        public ActionResult<List<Models.Response.AgendamentoResponse>> ConsultarAgendamentos (int id)
        {
            try 
            {
                List<Models.TbAgendamento> agendamentos = business.ConsultarAgendamentos(id);
                return conversorAgendar.ParaResponse(agendamentos);

            }
            catch(Exception ex)
            {
                return BadRequest(new Models.Response.ErroResponse(ex, 400));
            }

        }

        
    }
}