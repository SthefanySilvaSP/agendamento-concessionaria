using System;
using Newtonsoft;
using System.Linq;
using System.Collections.Generic;

namespace backend.Database
{
    public class AgendamentoDB
    {
        Models.db_concessionariaContext ctx = new Models.db_concessionariaContext();
        
        public Models.TbLogin Login (Models.TbLogin dados)
        {
            Models.TbLogin login = ctx.TbLogin.ToList().FirstOrDefault(x =>
                x.DsEmail == dados.DsEmail && 
                x.DsSenha == dados.DsSenha
            );

            return login;
        }

        public List<Models.TbCarro> ListarCarros ()
        {
            return ctx.TbCarro.ToList();
        }

        public void AgendarTestDrive(int idLogin, Models.TbAgendamento tb)
        {
            Models.TbCliente cliente = this.ConsultarCliente(idLogin);

            tb.IdCliente = cliente.IdCliente;
            tb.DsSituacao = "aguardando";

            ctx.Add(tb);
            ctx.SaveChanges();
        }
        
        public List<Models.TbAgendamento> ConsultarAgendamentos(int idLogin)
        {
            List<Models.TbAgendamento> agendamentos = ctx.TbAgendamento.Where(x =>
                x.IdCliente == this.ConsultarCliente(idLogin).IdCliente)
            .ToList();

            return agendamentos;
        }

        public string NomeUsuario (Models.TbLogin login)
        {
            
            if (string.IsNullOrEmpty(login.DsPerfil) && login.IdLogin > 0)
            {
                login = ctx.TbLogin.FirstOrDefault(x => x.IdLogin == login.IdLogin);
            }

            if (login.DsPerfil == "cliente")
            {
                Models.TbCliente pessoa = ctx.TbCliente.ToList().FirstOrDefault(x =>
                    x.IdLogin == login.IdLogin 
                );

                return pessoa.NmCliente;
            }
            else if (login.DsPerfil == "funcionario") 
            {
                Models.TbFuncionario pessoa = ctx.TbFuncionario.ToList().FirstOrDefault(x =>
                    x.IdLogin == login.IdLogin
                );
                
                return pessoa.NmFuncionario;

            }
            else 
            {
                return "Usuário não encontrado.";
            }
        }

        private Models.TbCliente ConsultarCliente (int idLogin)
        {
            Models.TbCliente cliente = ctx.TbCliente.ToList().FirstOrDefault(x =>
                x.IdLogin == idLogin
            );

            return cliente;
        }

        public Models.TbCarro ConsultarCarro(int id)
        {
            Models.TbCarro carro = ctx.TbCarro.ToList().FirstOrDefault(x =>
                                   x.IdCarro == id);   
        
            return carro;
        }

    }
}