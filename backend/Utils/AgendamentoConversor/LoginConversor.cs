namespace backend.Utils.AgendamentoConversor
{
    public class Login
    {
        public Models.TbLogin ParaTbLogin (Models.Request.LoginRequest req)
        {
            Models.TbLogin tb = new Models.TbLogin();

            tb.DsEmail = req.email;
            tb.DsSenha = req.senha;
            
            return tb;
        }


        public Models.Response.LoginResponse ParaLoginResponse(Models.TbLogin login, string nome)
        {
            Models.Response.LoginResponse resp = new Models.Response.LoginResponse();

            resp.LoginID = login.IdLogin;
            resp.Nome = nome;
            resp.Perfil = login.DsPerfil;

            return resp;
        }

    }
}