using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace APPEmpresa.DAL
{
    public class DapperContext
    {
        private static string Conn = Environment.GetEnvironmentVariable("PROD");

        public static DataTable Funcion_StoreDB(String P_Sentencia, object P_Parametro)
        {
            DataTable Dt = new();

            try
            {
                using (SqlConnection conn = new SqlConnection(Conn))
                {
                    var lst = conn.ExecuteReader(P_Sentencia, P_Parametro, commandType: CommandType.StoredProcedure);
                    Dt.Load(lst);
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return Dt;
        }

        public static void Procedimiento_StoreDB(String P_Sentencia, object P_Parametro)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conn))
                {
                    var lst = conn.ExecuteReader(P_Sentencia, P_Parametro, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
