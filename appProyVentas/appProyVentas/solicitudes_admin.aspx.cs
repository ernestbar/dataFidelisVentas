using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appProyVentas
{
    public partial class solicitudes_admin : System.Web.UI.Page
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
                    //btnNuevo.Visible = false;
                    lblCodMenuRol.Text = Request.QueryString["RME"].ToString();
                    //DataTable dt = Clases.Usuarios.PR_SEG_GET_OPCIONES_ROLES(lblUsuario.Text, Int64.Parse(lblCodMenuRol.Text));
                    //if (dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        if (dr["DESCRIPCION"].ToString().ToUpper() == "NUEVO")
                    //            btnNuevo.Visible = true;
                    //    }

                    //}
                    MultiView1.ActiveViewIndex = 0;
                    Repeater1.DataSource = Clases.Solicitudes.PR_SEG_GET_SOLICITUD(lblUsuario.Text);
                    Repeater1.DataBind();
                }
            }
        }

        protected void rblTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoSolicitud.SelectedValue == "ACTUALES")
            {
                Repeater1.DataSource = Clases.Solicitudes.PR_SEG_GET_SOLICITUD(lblUsuario.Text);
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = Clases.Solicitudes.PR_SEG_GET_SOLICITUD_HIST("");
                Repeater1.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

      

        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            ddlCliente.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoTelaCortina_DataBound(object sender, EventArgs e)
        {
            ddlTipoTelaCortina.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoCortina_DataBound(object sender, EventArgs e)
        {
            ddlTipoCortina.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoCenefa_DataBound(object sender, EventArgs e)
        {
            ddlTipoCenefa.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            ListItem item1 = new ListItem();
            item1.Text = txtUbicacionVentana.Text + " - " + ddlTipoCortina.SelectedItem.Text + " - " + ddlTipoTelaCortina.SelectedItem.Text + " - " + txtAlto.Text + " - " + txtAncho.Text + " - " + ddlTipoCenefa.SelectedItem.Text + " - " + ddlEsMadera.SelectedItem.Text + " - " + ddlEsEncajonada.SelectedItem.Text + " - " + txtCantidadPanos.Text + " - " +txtObservaciones.Text;
            item1.Value = txtUbicacionVentana.Text + ";" + ddlTipoCortina.SelectedValue + ";" + ddlTipoTelaCortina.SelectedValue + ";" + txtAlto.Text + ";" + txtAncho.Text + ";" + ddlTipoCenefa.SelectedValue + ";" + ddlEsMadera.SelectedValue + ";" + ddlEsEncajonada.SelectedValue + ";" + txtCantidadPanos.Text + ";" + txtObservaciones.Text;
            lbItems.Items.Add(item1);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string cadena = "";
            int x = 0;
            foreach (ListItem item1 in lbItems.Items)
            {
                if (x == 0)
                    cadena = item1.Value;
                else
                    cadena = cadena + "|" + item1.Value;
                x++;
            }
            Clases.Solicitudes obj = new Clases.Solicitudes("I", "",Int64.Parse(ddlCliente.SelectedValue), txtContacto.Text, txtTelefono.Text, txtEmail.Text, txtUbicacion.Text, txtComentarios.Text, cadena, lblUsuario.Text);
            lblAviso.Text = obj.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
            MultiView1.ActiveViewIndex = 0;
            Repeater1.DataBind();
        }

        protected void btnVolverAlta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string[] datos;
                Button obj = (Button)sender;
                datos = obj.CommandArgument.ToString().Split('|');
                Repeater4.DataSource = Clases.Cotizaciones.PR_SEG_GET_COTIZACION(datos[0],Int64.Parse(datos[1]));
                Repeater4.DataBind();
                MultiView1.ActiveViewIndex = 4;
                Clases.Cotizaciones obj1=new Clases.Cotizaciones(datos[0], Int64.Parse(datos[1]));
                lblID.Text = obj1.PV_ID_ETAPA.ToString();
                lblCliente.Text = obj1.PV_cliente;
                lblCelular.Text = obj1.PV_celular;
                lblNitCi.Text = obj1.PV_nit;
                lblNro.Text = obj1.PV_nro;
                lblFechaCot.Text = obj1.PV_fecha_cotizacion;
                lblFechaCotHasta.Text = obj1.PV_fecha_validez_cotizacion;
                lblTiempoProd.Text = obj1.PV_tiempo_produccion;


            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnEtapas_Click1(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Repeater2.DataSource= Clases.Solicitudes.PR_SEG_GET_ETAPAS(id);
                Repeater2.DataBind();
                MultiView1.ActiveViewIndex = 2;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverSolicitud_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnEtapasDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                lblAviso.Text = "";
                string id = "";
                Button obj = (Button)sender;
                id = obj.CommandArgument.ToString();
                Repeater3.DataSource = Clases.Solicitudes.PR_SEG_GET_ETAPAS_DETALLE(Int64.Parse( id));
                Repeater3.DataBind();
                MultiView1.ActiveViewIndex = 3;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_solicitudes_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
                string directorio2 = Server.MapPath("~/Logs");
                StreamWriter writer5 = new StreamWriter(directorio2 + "\\" + nombre_archivo, true, Encoding.Unicode);
                writer5.WriteLine(ex.ToString());
                writer5.Close();
                lblAviso.Text = "Tenemos algunos problemas consulte con el administrador.";
            }
        }

        protected void btnVolverEtapas_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            Clases.enviar_correo objC = new Clases.enviar_correo();
            string resp_email = objC.enviar("email???", "Confirmación de reserva StarzInfinite", hfDiv.Value, "");
            if (resp_email == "OK")
                lblAviso.Text = "Correo enviado correctamente a: " + "email????";
            else
                lblAviso.Text = "Hubo un problema al enviar el correo: " + resp_email;
        }

        protected void btnVolverEtapasCotizacion_Click(object sender, EventArgs e)
        {

        }
    }
}