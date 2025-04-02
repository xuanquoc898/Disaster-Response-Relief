using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace D2R.Helpers
{
    public static class DBHelper
    {
        private static readonly string connectionString = @"Server=LENOVO-HOANGHA\SQLEXPRESS;Database=DisasterRelief;Trusted_Connection=True;Encrypt=False;";

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static SqlCommand CreateCommand(string query, SqlConnection conn, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd;
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(query, conn, parameters);
            return cmd.ExecuteNonQuery();
        }

        public static SqlDataReader ExecuteReader(string query, params SqlParameter[] parameters)
        {
            var conn = GetConnection();
            var cmd = CreateCommand(query, conn, parameters);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(query, conn, parameters);
            return cmd.ExecuteScalar();
        }
    }
}
