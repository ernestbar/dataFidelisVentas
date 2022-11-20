using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appProyVentas.Clases
{
    public class Cotizaciones
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_SOLICITUD = "";
        private Int64 _PV_ID_ETAPA = 0;
        private string _PV_cliente = "";
        private string _PV_nit = "";
        private string _PV_celular = "";
        private string _PV_CORREOELECTRONICO = "";
        private string _PV_nro = "";
        private string _PV_fecha_cotizacion = "";
        private string _PV_fecha_validez_cotizacion = "";
        private string _PV_tiempo_produccion = "";
        private string _PV_monto_total = "";
        private string _PV_descuento_mes = "";
        private string _PV_total_pagar = "";
        private string _PV_anticipo = "";
        private string _PV_instalacion = "";
        private string _PV_banco = "";
        private string _PV_tipo_cuenta = "";
        private string _PV_cta_bs = "";
        private string _PV_cta_usd = "";
        private string _PV_contacto_lec = "";
        private string _PV_telefono_contacto_lec = "";
        //Propiedades públicas
        public string PV_SOLICITUD { get { return _PV_SOLICITUD; } set { _PV_SOLICITUD = value; } }
        public Int64 PV_ID_ETAPA { get { return _PV_ID_ETAPA; } set { _PV_ID_ETAPA = value; } }
        public string PV_cliente { get { return _PV_cliente; } set { _PV_cliente = value; } }
        public string PV_nit { get { return _PV_nit; } set { _PV_nit = value; } }
        public string PV_celular { get { return _PV_celular; } set { _PV_celular = value; } }
        public string PV_CORREOELECTRONICO { get { return _PV_CORREOELECTRONICO; } set { _PV_CORREOELECTRONICO = value; } }
        public string PV_nro { get { return _PV_nro; } set { _PV_nro = value; } }
        public string PV_fecha_cotizacion { get { return _PV_fecha_cotizacion; } set { _PV_fecha_cotizacion = value; } }
        public string PV_fecha_validez_cotizacion { get { return _PV_fecha_validez_cotizacion; } set { _PV_fecha_validez_cotizacion = value; } }
        public string PV_tiempo_produccion { get { return _PV_tiempo_produccion; } set { _PV_tiempo_produccion = value; } }
        public string PV_monto_total { get { return _PV_monto_total; } set { _PV_monto_total = value; } }
        public string PV_descuento_mes { get { return _PV_descuento_mes; } set { _PV_descuento_mes = value; } }
        public string PV_total_pagar { get { return _PV_total_pagar; } set { _PV_total_pagar = value; } }
        public string PV_anticipo { get { return _PV_anticipo; } set { _PV_anticipo = value; } }
        public string PV_instalacion { get { return _PV_instalacion; } set { _PV_instalacion = value; } }
        public string PV_banco { get { return _PV_banco; } set { _PV_banco = value; } }
        public string PV_tipo_cuenta { get { return _PV_tipo_cuenta; } set { _PV_tipo_cuenta = value; } }
        public string PV_cta_bs { get { return _PV_cta_bs; } set { _PV_cta_bs = value; } }
        public string PV_cta_usd { get { return _PV_cta_usd; } set { _PV_cta_usd = value; } }
        public string PV_contacto_lec { get { return _PV_contacto_lec; } set { _PV_contacto_lec = value; } }
        public string PV_telefono_contacto_lec { get { return _PV_telefono_contacto_lec; } set { _PV_telefono_contacto_lec = value; } }

        #endregion

        #region Constructores
        public Cotizaciones(string pV_SOLICITUD,Int64 pV_ID_ETAPA)
        {
            _PV_SOLICITUD = pV_SOLICITUD;
            _PV_ID_ETAPA = pV_ID_ETAPA;
            RecuperarDatos();
        }
        
        #endregion

        #region Métodos que NO requieren constructor


        public static DataTable PR_SEG_GET_COTIZACION(string pV_SOLICITUD,Int64 pV_ID_ETAPA)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_COTIZACION");

                db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, pV_SOLICITUD);
                db1.AddInParameter(cmd, "PV_ID_ETAPA", DbType.Int64, pV_ID_ETAPA);
                db1.AddOutParameter(cmd, "PV_cliente", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_nit", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_celular", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_CORREOELECTRONICO", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_nro", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_fecha_cotizacion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_fecha_validez_cotizacion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_tiempo_produccion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_monto_total", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_descuento_mes", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_total_pagar", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_anticipo", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_instalacion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_banco", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_tipo_cuenta", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_cta_bs", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_cta_usd", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_contacto_lec", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_telefono_contacto_lec", DbType.String, 30);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_cliente").ToString()))
                //    PV_cliente = "";
                //else
                //    PV_cliente = (string)db1.GetParameterValue(cmd, "PV_cliente");
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_COTIZACION");
                db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, _PV_SOLICITUD);
                db1.AddInParameter(cmd, "PV_ID_ETAPA", DbType.String, _PV_ID_ETAPA);
                db1.AddOutParameter(cmd, "PV_cliente", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_nit", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_celular", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_CORREOELECTRONICO", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_nro", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_fecha_cotizacion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_fecha_validez_cotizacion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_tiempo_produccion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_monto_total", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_descuento_mes", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_total_pagar", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_anticipo", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_instalacion", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_banco", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_tipo_cuenta", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_cta_bs", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_cta_usd", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_contacto_lec", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_telefono_contacto_lec", DbType.String, 30);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.ExecuteNonQuery(cmd);
                //DataTable dt = new DataTable();
                //dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_cliente").ToString()))
                    PV_cliente = "";
                else
                    PV_cliente = (string)db1.GetParameterValue(cmd, "PV_cliente");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_nit").ToString()))
                    PV_nit = "";
                else
                    PV_nit = (string)db1.GetParameterValue(cmd, "PV_nit");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_celular").ToString()))
                    PV_celular = "";
                else
                    PV_celular = (string)db1.GetParameterValue(cmd, "PV_celular");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_CORREOELECTRONICO").ToString()))
                    PV_CORREOELECTRONICO = "";
                else
                    PV_CORREOELECTRONICO = (string)db1.GetParameterValue(cmd, "PV_CORREOELECTRONICO");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_nro").ToString()))
                    PV_nro = "";
                else
                    PV_nro = (string)db1.GetParameterValue(cmd, "PV_nro");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_fecha_cotizacion").ToString()))
                    PV_fecha_cotizacion = "";
                else
                    PV_fecha_cotizacion = (string)db1.GetParameterValue(cmd, "PV_fecha_cotizacion");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_fecha_validez_cotizacion").ToString()))
                    PV_fecha_validez_cotizacion = "";
                else
                    PV_fecha_validez_cotizacion = (string)db1.GetParameterValue(cmd, "PV_fecha_validez_cotizacion");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_tiempo_produccion").ToString()))
                    PV_tiempo_produccion = "";
                else
                    PV_tiempo_produccion = (string)db1.GetParameterValue(cmd, "PV_tiempo_produccion");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_monto_total").ToString()))
                    PV_monto_total = "";
                else
                    PV_monto_total = (string)db1.GetParameterValue(cmd, "PV_monto_total");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_descuento_mes").ToString()))
                    PV_descuento_mes = "";
                else
                    PV_descuento_mes = (string)db1.GetParameterValue(cmd, "PV_descuento_mes");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_total_pagar").ToString()))
                    PV_total_pagar = "";
                else
                    PV_total_pagar = (string)db1.GetParameterValue(cmd, "PV_total_pagar");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_anticipo").ToString()))
                    PV_anticipo = "";
                else
                    PV_anticipo = (string)db1.GetParameterValue(cmd, "PV_anticipo");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_instalacion").ToString()))
                    PV_instalacion = "";
                else
                    PV_instalacion = (string)db1.GetParameterValue(cmd, "PV_instalacion");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_banco").ToString()))
                    PV_banco = "";
                else
                    PV_banco = (string)db1.GetParameterValue(cmd, "PV_banco");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_tipo_cuenta").ToString()))
                    PV_tipo_cuenta = "";
                else
                    PV_tipo_cuenta = (string)db1.GetParameterValue(cmd, "PV_tipo_cuenta");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_cta_bs").ToString()))
                    PV_cta_bs = "";
                else
                    PV_cta_bs = (string)db1.GetParameterValue(cmd, "PV_cta_bs");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_cta_usd").ToString()))
                    PV_cta_usd = "";
                else
                    PV_cta_usd = (string)db1.GetParameterValue(cmd, "PV_cta_usd");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_contacto_lec").ToString()))
                    PV_contacto_lec = "";
                else
                    PV_contacto_lec = (string)db1.GetParameterValue(cmd, "PV_contacto_lec");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_telefono_contacto_lec").ToString()))
                    PV_telefono_contacto_lec = "";
                else
                    PV_telefono_contacto_lec = (string)db1.GetParameterValue(cmd, "PV_telefono_contacto_lec");


            }
            catch (Exception ex)
            {

            }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                // verificar_vacios();
                //DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_ABM_SOLICITUDES");
                //db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                //if (_PV_SOLICITUD == "")
                //    db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, null);
                //else
                //    db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, _PV_SOLICITUD);
                //db1.AddInParameter(cmd, "PD_ID_ETAPA", DbType.Int64, _PV_ID_ETAPA);
                //db1.AddInParameter(cmd, "PV_cliente", DbType.String, _PV_cliente);
                //db1.AddInParameter(cmd, "PV_nit", DbType.String, _PV_nit);
                //db1.AddInParameter(cmd, "PV_celular", DbType.String, _PV_celular);
                //db1.AddInParameter(cmd, "PV_CORREOELECTRONICO", DbType.String, _PV_CORREOELECTRONICO);
                //db1.AddInParameter(cmd, "PV_nro", DbType.String, _PV_nro);
                //db1.AddInParameter(cmd, "pv_fecha_cotizacion", DbType.String, _PV_fecha_cotizacion);

                //db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                //db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                //db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                //db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                //db1.ExecuteNonQuery(cmd);
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                //    PV_ESTADOPR = "";
                //else
                //    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                //    PV_DESCRIPCIONPR = "";
                //else
                //    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                //if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                //    PV_ERROR = "";
                //else
                //    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");


                //resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                resultado = "|Se produjo un error al registrar|";
                return resultado;
            }
        }

        #endregion
    }
}