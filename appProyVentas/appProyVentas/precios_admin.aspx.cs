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
    public partial class precios_admin : System.Web.UI.Page
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

        protected void btnVerMatriz_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void ddlTipoCortina_DataBound(object sender, EventArgs e)
        {
            ddlTipoCortina.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoTelaCortina_DataBound(object sender, EventArgs e)
        {
            ddlTipoTelaCortina.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoCenefa_DataBound(object sender, EventArgs e)
        {
            ddlTipoCenefa.Items.Insert(0, "SELECCIONAR");
        }
        public void limpiar_controles()
        {
            ddlTipoCenefa.DataBind();
            ddlTipoCortina.DataBind();
            ddlTipoTelaCortina.DataBind();
            txtPrecio.Text = "0";

            lblAviso.Text = "";

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar_controles();
            MultiView1.ActiveViewIndex = 1;
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
                lblCodPrecio.Text = id;
                Clases.Precios cli = new Clases.Precios(Int64.Parse(lblCodPrecio.Text));
                txtPrecio.Text = cli.PB_ID_PRECIO.ToString();
                ddlTipoCortina.SelectedValue = cli.PV_TIPO_CORTINA;
                ddlTipoTelaCortina.SelectedValue = cli.PV_TIPO_TELA_CORTINA;
                ddlTipoCenefa.SelectedValue = cli.PV_TIPO_CENEFA;
                MultiView1.ActiveViewIndex = 1;

            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_precios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                lblCodPrecio.Text = datos[0];
                string estado = "";
                estado = datos[1];
                if (estado == "A")
                {
                    Clases.Precios cli = new Clases.Precios("D", Int64.Parse(lblCodPrecio.Text), "", "", "",0, lblUsuario.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {
                    Clases.Precios cli = new Clases.Precios("A", Int64.Parse(lblCodPrecio.Text), "", "", "", 0, lblUsuario.Text);
                    lblAviso.Text = cli.ABM().Replace("|", "").Replace("0", "").Replace("null", "");
                }

                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_precios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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
                if (lblCodPrecio.Text == "")
                {

                    Clases.Precios  cli = new Clases.Precios("I",0, ddlTipoCortina.SelectedValue, ddlTipoTelaCortina.SelectedValue, ddlTipoCenefa.SelectedValue, decimal.Parse(txtPrecio.Text),lblUsuario.Text);
                    string res = cli.ABM();
                    string[] aux = res.Split('|');
                    lblAviso.Text = res.Replace("|", "").Replace("0", "").Replace("null", "");
                }
                else
                {

                    Clases.Precios cli = new Clases.Precios("U", Int64.Parse(lblCodPrecio.Text), ddlTipoCortina.SelectedValue, ddlTipoTelaCortina.SelectedValue, ddlTipoCenefa.SelectedValue, decimal.Parse(txtPrecio.Text), lblUsuario.Text);
                    string res = cli.ABM();
                    string[] aux = res.Split('|');
                    lblAviso.Text = res.Replace("|", "").Replace("0", "").Replace("null", "");
                }
                MultiView1.ActiveViewIndex = 0;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                string nombre_archivo = "error_precios_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".txt";
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

        protected void btnVolverMatriz_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            limpiar_controles();
        }
        protected void GridView_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody>
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody>
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#0a3147");
                foreach (TableCell celda in e.Row.Cells)
                {
                    celda.Font.Size = 9;
                    celda.ForeColor = System.Drawing.Color.White;
                }
            }
        }
        protected void btnExportarPDF_Click(object sender, EventArgs e)
        {
            string nombreReporte = "matriz_precios.pdf";

            //Clases.Clientes cli = new Clases.Clientes(ddlClientes.SelectedValue);
            //if (cli.PV_LOGO == "")
            //{
            //    logoCliente = Server.MapPath("~") + "/ClienteLogos/sin_logo.png";
            //}
            //else
            //{
            //    logoCliente = Server.MapPath("~") + "/ClienteLogos/" + cli.PV_COD_CLIENTE + "/" + cli.PV_LOGO;
            //}

            byte[] buffer = Clases.Reportes.ExportarPDF(GridView1, "Matriz de precios");

            Response.Clear();
            Response.Charset = "";
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreReporte);
            Response.BinaryWrite(buffer);
            Response.Flush();
            Response.End();
            Response.ClearContent();
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            string nombreReporte = "matriz_precios.xlsx";

            //Clases.Clientes cli = new Clases.Clientes(ddlClientes.SelectedValue);
            //if (cli.PV_LOGO == "")
            //{
            //    logoCliente = Server.MapPath("~") + "/ClienteLogos/sin_logo.png";
            //}
            //else
            //{
            //    logoCliente = Server.MapPath("~") + "/ClienteLogos/" + cli.PV_COD_CLIENTE + "/" + cli.PV_LOGO;
            //}

            //FileInfo infoLogo = new FileInfo(logoCliente);
            byte[] buffer = Clases.Reportes.ExportarExcel(GridView1, "Matriz de precios");

            Response.Clear();
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreReporte);
            Response.BinaryWrite(buffer);
            Response.Flush();
            Response.End();
            Response.ClearContent();
        }

    }
}