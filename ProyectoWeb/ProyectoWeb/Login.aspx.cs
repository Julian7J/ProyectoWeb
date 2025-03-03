using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoWeb
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogearse_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.User = txtEmail.Text;
                usuario.Pass = txtPassword.Text;
                if (negocio.Login(usuario))
                {
                    Session.Add("user", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else 
                {
                    Session.Add("Error", "user o pass incorrectos");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}