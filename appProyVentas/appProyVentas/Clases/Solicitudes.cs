using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appProyVentas.Clases
{
    public class Solicitudes
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private string _PV_TIPO_OPERACION = "";
        private string _PV_SOLICITUD = "";
        private Int64 _PV_CLI_ID_CLIENTE = 0;
        private string _PV_CONTACTO = "";
        private string _PV_TELEFONO = "";
        private string _PV_CORREOELECTRONICO = "";
        private string _PV_UBICACION = "";
        private string _PV_COMENTARIOS = "";
        private string _PV_cadena = "";

        private string _PV_USUARIO = "";
        private string _PV_ESTADOPR = "";
        private string _PV_DESCRIPCIONPR = "";
        private string _PV_ERROR = "";
        //Propiedades públicas
        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_SOLICITUD { get { return _PV_SOLICITUD; } set { _PV_SOLICITUD = value; } }
        public Int64 PV_CLI_ID_CLIENTE { get { return _PV_CLI_ID_CLIENTE; } set { _PV_CLI_ID_CLIENTE = value; } }
        public string PV_CONTACTO { get { return _PV_CONTACTO; } set { _PV_CONTACTO = value; } }
        public string PV_TELEFONO { get { return _PV_TELEFONO; } set { _PV_TELEFONO = value; } }
        public string PV_CORREOELECTRONICO { get { return _PV_CORREOELECTRONICO; } set { _PV_CORREOELECTRONICO = value; } }
        public string PV_UBICACION { get { return _PV_UBICACION; } set { _PV_UBICACION = value; } }
        public string PV_COMENTARIOS { get { return _PV_COMENTARIOS; } set { _PV_COMENTARIOS = value; } }
        public string PV_cadena { get { return _PV_cadena; } set { _PV_cadena = value; } }

        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        #endregion

        #region Constructores
        public Solicitudes(string pV_SOLICITUD)
        {
            _PV_SOLICITUD = pV_SOLICITUD;
            RecuperarDatos();
        }
        public Solicitudes(string pV_TIPO_OPERACION, string pV_SOLICITUD, Int64 pV_CLI_ID_CLIENTE,
         string pV_CONTACTO, string pV_TELEFONO, string pV_CORREOELECTRONICO,
         string pV_UBICACION, string pV_COMENTARIOS, string pV_CADENA, string pV_USUARIO)
        {
            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_SOLICITUD = pV_SOLICITUD;
            _PV_CLI_ID_CLIENTE = pV_CLI_ID_CLIENTE;
            _PV_CONTACTO = pV_CONTACTO;
            _PV_TELEFONO = pV_TELEFONO;
            _PV_UBICACION = pV_UBICACION;
            _PV_CORREOELECTRONICO = pV_CORREOELECTRONICO;
            _PV_COMENTARIOS = pV_COMENTARIOS;
            _PV_cadena = pV_CADENA;
            _PV_USUARIO = pV_USUARIO;
        }
        #endregion

        #region Métodos que NO requieren constructor

        
        public static DataTable PR_SEG_GET_SOLICITUD(string PV_OPERADOR)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_SOLICITUD");
                if(PV_OPERADOR=="")
                    db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, PV_OPERADOR);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_SEG_GET_SOLICITUD_HIST(string PV_OPERADOR)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_SOLICITUD_HIST");
                if (PV_OPERADOR=="")
                    db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_OPERADOR", DbType.String, PV_OPERADOR);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
        public static DataTable PR_SEG_GET_ETAPAS(string PV_SOLICITUD)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_ETAPAS");
                db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, PV_SOLICITUD);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }

        public static DataTable PR_SEG_GET_ETAPAS_DETALLE(Int64 PB_ID_ETAPA)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_ETAPAS_DETALLE");
                db1.AddInParameter(cmd, "PB_ID_ETAPA", DbType.Int64, PB_ID_ETAPA);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                return db1.ExecuteDataSet(cmd).Tables[0];
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_SOLICITUD_IND");
                db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, _PV_SOLICITUD);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                DataTable dt = new DataTable();
                dt = db1.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["CLI_ID_CLIENTE"].ToString()))
                        { _PV_CLI_ID_CLIENTE = 0; }
                        else
                        { _PV_CLI_ID_CLIENTE = Int64.Parse(dr["CLI_ID_CLIENTE"].ToString()); }


                        if (string.IsNullOrEmpty(dr["contacto"].ToString()))
                        { _PV_CONTACTO = ""; }
                        else
                        { _PV_CONTACTO = (string)dr["contacto"]; }

                        if (string.IsNullOrEmpty(dr["telefono"].ToString()))
                        { _PV_TELEFONO = ""; }
                        else
                        { _PV_TELEFONO = (string)dr["telefono"]; }

                        if (string.IsNullOrEmpty(dr["correoelectronico"].ToString()))
                        { _PV_CORREOELECTRONICO = ""; }
                        else
                        { _PV_CORREOELECTRONICO = (string)dr["correoelectronico"]; }

                        if (string.IsNullOrEmpty(dr["ubicacion"].ToString()))
                        { _PV_UBICACION = ""; }
                        else
                        { _PV_UBICACION = (string)dr["ubicacion"]; }



                    }

                }
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
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_ABM_SOLICITUDES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                if(_PV_SOLICITUD=="")
                    db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_SOLICITUD", DbType.String, _PV_SOLICITUD);
                db1.AddInParameter(cmd, "PD_CLI_ID_CLIENTE", DbType.Int64, _PV_CLI_ID_CLIENTE);
                db1.AddInParameter(cmd, "PV_CONTACTO", DbType.String, _PV_CONTACTO);
                db1.AddInParameter(cmd, "PV_TELEFONO", DbType.String, _PV_TELEFONO);
                db1.AddInParameter(cmd, "PV_CORREOELECTRONICO", DbType.String, _PV_CORREOELECTRONICO);
                db1.AddInParameter(cmd, "PV_UBICACION", DbType.String, _PV_UBICACION);
                db1.AddInParameter(cmd, "PV_COMENTARIOS", DbType.String, _PV_COMENTARIOS);
                db1.AddInParameter(cmd, "pv_cadena", DbType.String, _PV_cadena);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCIONPR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.ExecuteNonQuery(cmd);
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCIONPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");


                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR;
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