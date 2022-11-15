using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appProyVentas
{
    public partial class clientes_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    lblUsuario.Text = Session["usuario"].ToString();
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    MultiView1.ActiveViewIndex = 0;
                }
                //lblUsuario.Text = "admin";
                //MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;
        }
        public void limpiar_controles()
        {
            lblCodCliente.Text = "";
            txtRazonSocial.Text = "";
            txtTelefono.Text = "";
            ddlTipoSociedad.DataBind();

            lblAviso.Text = "";

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                lblCodCliente.Text = id;
                Clases.Clientes cli = new Clases.Clientes(Int64.Parse(lblCodCliente.Text));
                txtTelefono.Text = cli.PV_TELEFONO;
                txtRazonSocial.Text = cli.PV_RAZON_SOCIAL;
                txtNIT.Text = cli.PV_NIT;
                ddlTipoSociedad.SelectedValue= cli.PV_TIPO_SOCIEDAD;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                limpiar_controles();
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                string[] datos = id.Split('|');
                lblCodCliente.Text = datos[0];
                string estado = "";
                estado = datos[1];
                if (estado == "A")
                {
                    Clases.Clientes cli = new Clases.Clientes("D","",Int64.Parse(lblCodCliente.Text),"","","", lblUsuario.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {
                    Clases.Clientes cli = new Clases.Clientes("A", "", Int64.Parse(lblCodCliente.Text), "", "", "", lblUsuario.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                }
               
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }


    

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCodCliente.Text == "")
                {
                    
                    Clases.Clientes cli = new Clases.Clientes("I",ddlTipoSociedad.SelectedValue,Int64.Parse(lblCodCliente.Text),txtRazonSocial.Text,
                       txtNIT.Text,txtTelefono.Text,lblUsuario.Text);
                    string res = cli.ABM();
                    string[] aux = res.Split('|');
                    lblAviso.Text = res.Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {

                    Clases.Clientes cli = new Clases.Clientes("U", ddlTipoSociedad.SelectedValue, Int64.Parse(lblCodCliente.Text), txtRazonSocial.Text,
                       txtNIT.Text, txtTelefono.Text, lblUsuario.Text);
                    string res = cli.ABM();
                    string[] aux = res.Split('|');
                    lblAviso.Text = res.Replace("|", "").Replace("0", "").Replace("null", "");
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_clientes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar_controles();
        }

        



        protected void ddlTipoSociedad_DataBound(object sender, EventArgs e)
        {
            ddlTipoSociedad.Items.Insert(0, "SELECCIONAR");
        }
    }
}