using System;
using System.Collections.Generic;
using System.Linq;
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
                }
            }
        }

        protected void rblTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTipoSolicitud.SelectedValue == "ACTUALES")
            {
                Repeater1.DataSource = Clases.Solicitudes.PR_SEG_GET_SOLICITUD(lblUsuario.Text);
            }
            else
            {
                Repeater1.DataSource = Clases.Solicitudes.PR_SEG_GET_SOLICITUD_HIST("");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnEtapas_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            ddlCliente.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlTipoTelaCortina_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlTipoCortina_DataBound(object sender, EventArgs e)
        {

        }
    }
}