using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appProyVentas.Clases
{
    public class Precios
    { 
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        // JURIDICA
        private string _PV_TIPO_OPERACION = "";
        private string _PV_TIPO_CORTINA = "";
        private Int64 _PB_ID_PRECIO = 0;
        private string _PV_TIPO_TELA_CORTINA = "";
        private string _PV_TIPO_CENEFA = "";
        public decimal _PV_PRECIO = 0;

        public string _PV_USUARIO = "";
        public string _PV_ESTADOPR = "";
        public string _PV_DESCRIPCIONPR = "";
        public string _PV_ERROR = "";
        public Int64 _PB_ID_PRECIOOUT = 0;
        // SITUACION LABORAL

        //Propiedades públicas

        public string PV_TIPO_OPERACION { get { return _PV_TIPO_OPERACION; } set { _PV_TIPO_OPERACION = value; } }
        public string PV_TIPO_CORTINA { get { return _PV_TIPO_CORTINA; } set { _PV_TIPO_CORTINA = value; } }
        public Int64 PB_ID_PRECIO { get { return _PB_ID_PRECIO; } set { _PB_ID_PRECIO = value; } }
        public string PV_TIPO_TELA_CORTINA { get { return _PV_TIPO_TELA_CORTINA; } set { _PV_TIPO_TELA_CORTINA = value; } }
        public string PV_TIPO_CENEFA { get { return _PV_TIPO_CENEFA; } set { _PV_TIPO_CENEFA = value; } }
        public decimal PV_PRECIO { get { return _PV_PRECIO; } set { _PV_PRECIO = value; } }


        public string PV_USUARIO { get { return _PV_USUARIO; } set { _PV_USUARIO = value; } }
        public string PV_ESTADOPR { get { return _PV_ESTADOPR; } set { _PV_ESTADOPR = value; } }
        public string PV_DESCRIPCIONPR { get { return _PV_DESCRIPCIONPR; } set { _PV_DESCRIPCIONPR = value; } }
        public string PV_ERROR { get { return _PV_ERROR; } set { _PV_ERROR = value; } }
        public Int64 PB_ID_PRECIOOUT { get { return _PB_ID_PRECIOOUT; } set { _PB_ID_PRECIOOUT = value; } }
        #endregion

        #region Constructores
        public Precios(Int64 pB_CLI_ID_PRECIO)
        {
            _PB_ID_PRECIO = pB_CLI_ID_PRECIO;
            RecuperarDatos();
        }
        public Precios(string pV_TIPO_OPERACION, Int64 pB_ID_PRECIO, string pV_TIPO_CORTINA, 
            string pV_TIPO_TELA_CORTINA, string pV_TIPO_CENEFA, decimal pV_PRECIO, string pV_USUARIO)
        {

            _PV_TIPO_OPERACION = pV_TIPO_OPERACION;
            _PV_TIPO_CORTINA = pV_TIPO_CORTINA;
            _PB_ID_PRECIO = pB_ID_PRECIO;
            _PV_TIPO_TELA_CORTINA = pV_TIPO_TELA_CORTINA;
            _PV_TIPO_CENEFA = pV_TIPO_CENEFA;
            _PV_PRECIO = pV_PRECIO;
            _PV_USUARIO = pV_USUARIO;

        }

        #endregion

        #region Métodos que NO requieren constructor


        public static DataTable PR_PAR_GET_PRECIOS()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_PRECIOS");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable PR_PAR_GET_PRECIOS_MATRIZ()
        {
            DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_PRECIOS_MATRIZ");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }


        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_GET_PRECIOS_IND");
                db1.AddInParameter(cmd, "PB_ID_PRECIO", DbType.Int64, _PB_ID_PRECIO);
                DataTable dt = db1.ExecuteDataSet(cmd).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                      
                        if (String.IsNullOrEmpty(dr["CLI_TIPO_TELA_CORTINA"].ToString()))
                            _PV_TIPO_TELA_CORTINA = "";
                        else
                            _PV_TIPO_TELA_CORTINA = (string)dr["CLI_TIPO_TELA_CORTINA"];
                        if (String.IsNullOrEmpty(dr["CLI_PRECIO"].ToString()))
                            _PV_PRECIO = 0;
                        else
                            _PV_PRECIO = (decimal)dr["CLI_PRECIO"];
                        if (String.IsNullOrEmpty(dr["CLI_TIPO_CENEFA"].ToString()))
                            _PV_TIPO_CENEFA = "";
                        else
                            _PV_TIPO_CENEFA = (string)dr["CLI_TIPO_CENEFA"];
                        if (String.IsNullOrEmpty(dr["CLI_TIPO_CORTINA"].ToString()))
                            _PV_TIPO_CORTINA = "";
                        else
                            _PV_TIPO_CORTINA = (string)dr["CLI_TIPO_CORTINA"];
                    }
                }



            }
            catch (Exception ex) { }
        }



        public string ABM()
        {
            string resultado = "";
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_PAR_ABM_PRECION");
                db1.AddInParameter(cmd, "PV_TIPO_OPERACION", DbType.String, _PV_TIPO_OPERACION);
                db1.AddInParameter(cmd, "PB_ID_PRECIO", DbType.String, _PB_ID_PRECIO);
                db1.AddInParameter(cmd, "PV_TIPO_CORTINA", DbType.String, _PV_TIPO_CORTINA);
                db1.AddInParameter(cmd, "PV_TIPO_TELA_CORTINA", DbType.String, _PV_TIPO_TELA_CORTINA);
                db1.AddInParameter(cmd, "PV_TIPO_CENEFA", DbType.String, _PV_TIPO_CENEFA);
                db1.AddInParameter(cmd, "PV_PRECIO", DbType.String, _PV_PRECIO);
                
                

                db1.AddInParameter(cmd, "PV_USUARIO", DbType.String, _PV_USUARIO);
                db1.AddOutParameter(cmd, "PV_ESTADOPR", DbType.String, 30);
                db1.AddOutParameter(cmd, "PV_DESCRIPCION", DbType.String, 250);
                db1.AddOutParameter(cmd, "PV_ERROR", DbType.String, 250);
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
              

                resultado = PV_ESTADOPR + "|" + PV_DESCRIPCIONPR + "|" + PV_ERROR ;
                //resultado = (string)db1.GetParameterValue(cmd, "PV_DESCRIPCION")+"|"+ (string)db1.GetParameterValue(cmd, "PB_ID_PRECIO_RET");
                //_id_cliente = (int)db1.GetParameterValue(cmd, "@PV_DESCRIPCIONPR");
                //_error = (string)db1.GetParameterValue(cmd, "error");
                return resultado;
            }
            catch (Exception ex)
            {
                //_error = ex.Message;
                //resultado = "Se produjo un error al registrar";
                resultado = ex.ToString() + "||";
                return resultado;
            }
        }

        #endregion
    }
}