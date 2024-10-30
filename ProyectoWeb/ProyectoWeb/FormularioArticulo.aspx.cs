using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace ProyectoWeb
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {    
                // Configuracion inicial de la pantalla
                if (!IsPostBack)
                {
                    CategoriasNegocio negocio = new CategoriasNegocio();
                    List<Categorias> lista = negocio.listar();

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                if (!IsPostBack)
                {
                    MarcasNegocio negocio = new MarcasNegocio();
                    List<Marcas> lista = negocio.listar();

                    ddlMarca.DataSource = lista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                // Configuracion si estamos modificando
                  string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";



                    if (id != "" && !IsPostBack)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        // List<Articulo> lista = negocio.listar(id);
                        // Articulo seleccionado = lista[0];
                        Articulo seleccionado = (negocio.listar(id))[0];

                        // pre cargar todos los campos.
                        txtId.Text = id;
                        txtCodigo.Text = seleccionado.Codigo;
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;

                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();

                        txtPrecio.Text = seleccionado.Precio.ToString();
                        txtImagenUrl.Text = seleccionado.ImagenUrl;
                        txtImagenUrl_TextChanged(sender, e);

                    }
                

            }
            catch (Exception ex)
            {

                Session.Add("Error",ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
          
            try
            {
                
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;    
                
                nuevo.Categoria = new Categorias();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.ImagenUrl = txtImagenUrl.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                    negocio.agregar(nuevo);

                Response.Redirect("ArticuloLista.aspx", false);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            ImgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmar.Checked) 
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ArticuloLista.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }
    }
}