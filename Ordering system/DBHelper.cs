using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ordering_system
{
    internal class DBHelper
    {
        public static string ConnString = "server=.;database=Ordering system;uid=sa;pwd=1234;";


        private static SqlConnection Conn = null;

        private static void InitConnection()
        {
            if (Conn == null)
                Conn = new SqlConnection(ConnString);
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Open();
            }
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            if (Conn.State == ConnectionState.Broken)
            {
                Conn.Close();
                Conn.Open();
            }

        }

        public static SqlDataReader GetDataReader(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static DataSet GetDataSet(string sqlStr)
        {
            InitConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, Conn);
            dap.Fill(ds);
            Conn.Close();
            return ds;
        }

        public static DataTable GetDataTable(string sqlStr)
        {
            return GetDataSet(sqlStr).Tables[0];
        }

        public static bool ExecuteNonQuery(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            return result > 0;
        }


        public static object ExecuteScalar(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            object result = cmd.ExecuteScalar();
            Conn.Close();
            return result;
        }

    }
}
