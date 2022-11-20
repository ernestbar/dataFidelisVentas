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
    }
}