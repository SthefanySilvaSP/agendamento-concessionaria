using System;
using System.Collections.Generic;

namespace backend.Business
{
    public class AgendamentoBusiness
    {
        Database.AgendamentoDB db = new Database.AgendamentoDB();


        public Models.TbLogin Login (Models.TbLogin login)
        {
            if(string.IsNullOrEmpty(login.DsEmail))
                throw new Exception("Email inválido.");
            if(string.IsNullOrEmpty(login.DsSenha))
                throw new Exception("Senha inválida.");

            return db.Login(login); 
        }   

        public string NomeUsuario(Models.TbLogin login)
        {
            if(login.IdLogin <= 0)
                throw new Exception("ID inválido.");
            if(string.IsNullOrEmpty(login.DsEmail))
                throw new Exception("Email inválido.");
            if(string.IsNullOrEmpty(login.DsSenha))
                throw new Exception("Senha inválida.");
            if(string.IsNullOrEmpty(login.DsPerfil))
                throw new Exception("Perfil inválido.");

            return db.NomeUsuario(login);
        }

        public List<Models.TbCarro> ListarCarros ()
        {
            return db.ListarCarros();
        }

        public void AgendarTestDrive (int idLogin, Models.TbAgendamento tb)
        {
            if(tb.IdCarro <= 0)
                throw new Exception("ID inválido.");
            if(tb.DtAgendamento == null)
                throw new Exception("Data inválida.");
            
            db.AgendarTestDrive(idLogin, tb);
        }

        public List<Models.TbAgendamento> ConsultarAgendamentos(int idLogin)
        {
            if(idLogin <= 0)
                throw new Exception("ID inválido");

            return db.ConsultarAgendamentos(idLogin);

        }
    }
}