using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace D2R.Helpers
{
    public static class DBHelper
    {
        // Chuoi ket noi den CSDL:
        //          IP server: 100.94.158.29
        //          Database: disasterrelief
        //          Uid: aceofspades
        //          Pwd: AceofSpades123!
        //          Port: 3306
        //          connectionString = "Server=localhost;Database=ten_database;Uid=ten_user;Pwd=mat_khau;";
        private static readonly string connectionString = @"Server=100.94.158.29;Database=disasterrelief;Uid=aceofspades;Pwd=AceofSpades123!; Port=3306";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static MySqlCommand CreateCommand(string query, MySqlConnection conn, params MySqlParameter[] parameters)
        {
            var cmd = new MySqlCommand(query, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd;
        }

        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(query, conn, parameters);
            return cmd.ExecuteNonQuery();
        }

        public static MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
        {
            var conn = GetConnection();
            var cmd = CreateCommand(query, conn, parameters);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = CreateCommand(query, conn, parameters);
            return cmd.ExecuteScalar();
        }
    }
}

