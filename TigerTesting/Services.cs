using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TigerTesting
{

   
    public class Services: IDisposable
    {
        SqlConnection connect;
        public  Services()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            connect.Open();
            
        }
        public SqlDataReader ExecuteReader(string query)
        {
            SqlCommand command = new SqlCommand(query,connect);
            SqlDataReader result = command.ExecuteReader();
            return result;
        }

        public int ExecuteNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query,connect);
            int result = command.ExecuteNonQuery();
            return result;
        }
        public void Dispose()
        {
            if (connect != null && connect.State == ConnectionState.Open)
            {
                connect.Close();
            }
        }

         
    }
}
