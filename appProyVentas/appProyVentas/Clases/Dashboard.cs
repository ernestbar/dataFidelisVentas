using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace appProyVentas.Clases
{
    public class Dashboard
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        public static DataTable PR_GET_DASHBOARD(string PV_ESTADO)
        {
            try
            {

                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_DASHBOARD");
                if(PV_ESTADO == "TODOS")
                    db1.AddInParameter(cmd, "PV_ESTADO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_ESTADO", DbType.String, PV_ESTADO);
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

        public static DataTable PR_GET_DASHBOARD2(string PV_ESTADO)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ventas_mes");
                dt.Columns.Add("ventas_mes_anterior");
                dt.Columns.Add("mensaje");
                dt.Columns.Add("estilo");
                DbCommand cmd = db1.GetStoredProcCommand("PR_SEG_GET_DASHBOARD");
                if (PV_ESTADO == "TODOS")
                    db1.AddInParameter(cmd, "PV_ESTADO", DbType.String, null);
                else
                    db1.AddInParameter(cmd, "PV_ESTADO", DbType.String, PV_ESTADO);
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                int x = 0;
                int ventas_mes = 0;
                int ventas_mes_anterior = 0;
                string mensaje = "";
                string estilo = "";
                foreach (DataRow dr in db1.ExecuteDataSet(cmd).Tables[0].Rows)
                {
                    if (db1.ExecuteDataSet(cmd).Tables[0].Rows.Count == 1)
                    {
                        ventas_mes = int.Parse(dr["cantidad"].ToString());
                        ventas_mes_anterior = int.Parse(dr["cantidad"].ToString()); ;
                    }
                    else
                    {
                        if (x == 0)
                        {
                            if (String.IsNullOrEmpty(dr["cantidad"].ToString()))
                                ventas_mes_anterior = 0;
                            else
                                ventas_mes_anterior = int.Parse(dr["cantidad"].ToString());
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(dr["cantidad"].ToString()))
                                ventas_mes = 0;
                            else
                                ventas_mes = int.Parse(dr["cantidad"].ToString());
                        }
                        x++;
                    }
                    
                }
                DataRow row1 = dt.NewRow();
                row1["ventas_mes"] = ventas_mes;
                row1["ventas_mes_anterior"] = ventas_mes_anterior;
                decimal por = Math.Round((decimal.Parse(ventas_mes.ToString()) / decimal.Parse(ventas_mes_anterior.ToString())), 1)*100;
                if (por > 100)
                    por = por - 100;
                if (ventas_mes_anterior > ventas_mes)
                    mensaje = por.ToString().Replace(",", ".") + "% Mas solicitudes el anterior mes";
                else
                    mensaje = por.ToString().Replace(",", ".") + "% Mas solicitudes este mes";
                row1["mensaje"] = mensaje;
                
                estilo = "width: " + por.ToString().Replace(",",".") + "%;";
                row1["estilo"] = estilo;
                dt.Rows.Add(row1);
                return dt; 
            }
            catch (Exception ex)
            {
                ex.ToString();
                DataTable dt = new DataTable();
                return dt;
            }

        }
    }
}