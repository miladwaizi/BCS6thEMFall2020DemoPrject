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
        public DataTable ExecuteProcedureSelect(string ProcedureName)
        {
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Closed)
                con.Open();
            dr=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }
        public DataTable ExecuteProcedureSelect(string[] spParameters,string[] spValues, string ProcedureName)
        {
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            for(int i=0;i<spParameters.Length;i++)
            {
                cmd.Parameters.AddWithValue(spParameters[i], spValues[i]);
            }
            if (con.State == ConnectionState.Closed)
                con.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }
        public string ExecuteProcedureDML(string[] spParameters,string[] spValues,string ProcedureName)
        {
            cmd = new SqlCommand(ProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for(int i=0;i<spParameters.Length;i++)
            {
                if(i==spParameters.Length-1)
                {
                    cmd.Parameters.Add(spParameters[i], SqlDbType.NVarChar, 500);
                    cmd.Parameters[spParameters[i]].Direction = ParameterDirection.Output;
                }
                else
                cmd.Parameters.AddWithValue(spParameters[i], spValues[i]);
            }
            
            if(con.State==ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            string Error = (string)cmd.Parameters[spParameters[spParameters.Length-1]].Value;
            con.Close();

            return Error;
        }
    }
}