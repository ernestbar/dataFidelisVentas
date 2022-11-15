using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appProyVentas.Clases
{
    public class Clientes
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        // JURIDICA
        private string _PV_TIPO_OPERACION = "";
        private string _PV_TIPO_SOCIEDAD = "";
        private Int64 _PB_ID_CLIENTE =0;
        private string _PV_RAZON_SOCIAL = "";
        private string _PV_NIT = "";
        public string _PV_TELEFONO="";

        public string _PV_USUARIO="";
        public string _PV_ESTADOPR = "";
        public string _PV_DESCRIPCIONPR = "";
        public string _PV_ERROR = "";
        public Int64 _PB_ID_CLIENTEOUT = 0;
        // SITUACION LABORAL

        //Propiedades públicas

        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_TIPO_SOCIEDAD { get { return _PV_TIPO_SOCIEDAD; } set { _PV_TIPO_SOCIEDAD = value; } }
        public Int64 PB_ID_CLIENTE { get { return _PB_ID_CLIENTE; } set { _PB_ID_CLIENTE = value; } }
        public string PV_RAZON_SOCIAL { get { return _PV_RAZON_SOCIAL; } set { _PV_RAZON_SOCIAL = value; } }
        public string PV_NIT { get { return _PV_NIT; } set { _PV_NIT = value; } }
        public string PV_TELEFONO { get { return _PV_TELEFONO; } set { _PV_TELEFONO = value; } }
       
       
        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public Int64 PB_ID_CLIENTEOUT { get { return _PB_ID_CLIENTEOUT; } set { _PB_ID_CLIENTEOUT = value; } }
        #endregion

        #region Constructores
        public Clientes(Int64 pB_CLI_ID_CLIENTE)
        {
            _PB_ID_CLIENTE = pB_CLI_ID_CLIENTE;
            RecuperarDatos();
        }
        public Clientes(string pV_TIPO_OPERACION, string pV_TIPO_SOCIEDAD, Int64 pB_ID_CLIENTE,
            string pV_RAZON_SOCIAL, string pV_NIT, string pV_TELEFONO, string pV_USUARIO)
        {

            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_TIPO_SOCIEDAD = pV_TIPO_SOCIEDAD;
            _PB_ID_CLIENTE = pB_ID_CLIENTE;
            _PV_RAZON_SOCIAL = pV_RAZON_SOCIAL;
            _PV_NIT = pV_NIT;
            _PV_TELEFONO = pV_TELEFONO;
            _PV_USUARIO = pV_USUARIO;

        }      
    
        #endregion

        #region Métodos que NO requieren constructor
        
      
        public static DataTable PR_SEG_GET_CLIENTES()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CLIENTES");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }



        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_CLIENTES_IND");
                db1.AddInParameter(cmd, "PB_CLI_ID_CLIENTE", DbType.Int64, _PB_ID_CLIENTE);
                DataTable dt = db1.ExecuteDataSet(cmd).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if(String.IsNullOrEmpty(dr["CLI_RAZON_SOCIAL"].ToString()))
                            _PV_RAZON_SOCIAL = "";
                        else
                            _PV_RAZON_SOCIAL = (string)dr["CLI_RAZON_SOCIAL"];
                        if (String.IsNullOrEmpty(dr["CLI_TELEFONO"].ToString()))
                            _PV_TELEFONO = "";
                        else
                            _PV_TELEFONO = (string)dr["CLI_TELEFONO"];
                        if (String.IsNullOrEmpty(dr["CLI_NIT"].ToString()))
                            _PV_NIT = "";
                        else
                            _PV_NIT = (string)dr["CLI_NIT"];
                        if (String.IsNullOrEmpty(dr["CLI_TIPO_SOCIEDAD"].ToString()))
                            _PV_TIPO_SOCIEDAD = "";
                        else
                            _PV_TIPO_SOCIEDAD = (string)dr["CLI_TIPO_SOCIEDAD"];
                    }
                }


                
            }
            catch (Exception  ex) { }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {
                
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_CLIENTES");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_CLIENTE", DbType.String, _PB_ID_CLIENTE);
                db1.AddInParameter(cmd, "PV_TELEFONO", DbType.String, _PV_TELEFONO);
                db1.AddInParameter(cmd, "PV_RAZON_SOCIAL", DbType.String, _PV_RAZON_SOCIAL);
                db1.AddInParameter(cmd, "PV_NIT", DbType.String, _PV_NIT);
                db1.AddInParameter(cmd, "PV_TIPO_SOCIEDAD", DbType.String, _PV_TIPO_SOCIEDAD);

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
                db1.AddOutParameter(cmd, "PB_ID_CLIENTEOUT", DbType.Int64, 30);
                db1.ExecuteNonQuery(cmd);
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ESTADOPR").ToString()))
                    PV_ESTADOPR = "";
                else
                    PV_ESTADOPR = (string)db1.GetParameterValue(cmd, "PV_ESTADOPR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_DESCRIPCION").ToString()))
                    PV_DESCRIPCIONPR = "";
                else
                    PV_DESCRIPCIONPR = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PV_ERROR").ToString()))
                    PV_ERROR = "";
                else
                    PV_ERROR = (string)db1.GetParameterValue(cmd, "PV_ERROR");
                if (String.IsNullOrEmpty(db1.GetParameterValue(cmd, "PB_ID_CLIENTEOUT").ToString()))
                    PB_ID_CLIENTEOUT = 0;
                else
                    PB_ID_CLIENTEOUT = Int64.Parse(db1.GetParameterValue(cmd, "PB_ID_CLIENTEOUT").ToString());

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR +"| ID:"+ PB_ID_CLIENTEOUT;
                //resultado = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION")+"|"+ (string)db1.GetParameterValue(cmd, "PB_ID_CLIENTE_RET");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                //resultado = "Se produjo un error al registrar";
                resultado = ex.ToString() + "|||";
                return resultado;
            }
        }
       
        #endregion
    }
}