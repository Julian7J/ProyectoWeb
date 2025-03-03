using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ProyectoWeb
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetallesArticulos();
            }

        }

        private void CargarDetallesArticulos()
        {
            string connectionString = ConfigurationManager.AppSettings["cadenaConexion"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select Codigo, Nombre, A.Descripcion, C.Descripcion as Categoria, M.Descripcion as Marca, ImagenUrl, Precio, A.IdCategoria, A.IdMarca, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria and M.Id = A.IdMarca ";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Crear un DataTable para almacenar los resultados  
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Asumimos que tienes un control GridView (o un control similar) en tu asp:Content  
                    Detalle.DataSource = dt;
                    Detalle.DataBind();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones (logging, mostrar mensaje, etc.)  
                    Console.WriteLine(ex.Message);
                }
            }

        }
        }
}