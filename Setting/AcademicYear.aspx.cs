using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCS6thEMFall2020DemoPrject.Setting
{
    public partial class AcademicYear : System.Web.UI.Page
    {
        DBCommunicator db = new DBCommunicator();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spPageAcademicYearSave", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@Abbreviation", txtAbbreviation.Text);
            SqlParameter p = new SqlParameter();
            p.ParameterName = "@FarsiTitle";
            p.Value = txtFarsiTitle.Text;
            cmd.Parameters.Add(p);
            cmd.Parameters.AddWithValue("@User", "1");
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
            cmd.Parameters.Add("@Error", SqlDbType.NVarChar);
            cmd.Parameters["@Error"].Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            string Error = (string) cmd.Parameters["@Error"].Value;
            con.Close();

            if (Error=="0")
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('Record Saved....!');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('"+Error+"');", true);

        }
    }
}