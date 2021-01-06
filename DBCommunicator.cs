using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BCS6thEMFall2020DemoPrject
{
    public class DBCommunicator
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public DBCommunicator()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        }

        public void ExecuteDML(string Query)
        {
            cmd = new SqlCommand(Query,con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}