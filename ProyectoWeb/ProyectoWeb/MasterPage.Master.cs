﻿using Microsoft.Win32;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
  
namespace ProyectoWeb
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         //   if(!(Page is Login || Page is Default))
           
        //    {

         //        if (!Seguridad.sesionActiva(Session["usuario"]))
         //            Response.Redirect("Login.aspx", false);
         //        }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}