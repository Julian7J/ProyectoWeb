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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

 

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService(); 

                user.User = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = usuarioNegocio.insertarNuevo(user);
                Session.Add("usuario", user);
                //  emailService.armarCorreo(user.User, "Hola", "te damos la bienvenida a la aplicacion");
                //  emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}