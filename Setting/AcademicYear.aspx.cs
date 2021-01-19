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
            if(!IsPostBack)
            {
                FillGrid();
            }
        }
        private void FillGrid()
        {
            GridView1.DataSource = db.ExecuteProcedureSelect("spPageAcademicYearLoad");
            GridView1.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] p = { "@Title", "@Abbreviation", "@FarsiTitle", "@User", "@Date", "@Error" };
            string[] v = { txtTitle.Text,txtAbbreviation.Text,txtFarsiTitle.Text,"1",DateTime.Now.ToString()};

            string Error = db.ExecuteProcedureDML(p,v, "spPageAcademicYearSave");
            
            if (Error=="0")
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('Record Saved....!');", true);
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('"+Error+"');", true);

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label Code = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGvCode");
            TextBox Title = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGvTitle");
            TextBox Abb = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGvAbbreviation");
            TextBox FarsiTitle = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtGvFarsiTitle");

            string[] p = { "@Code", "@Title", "@Abbreviation", "@FarsiTitle", "@User", "@Date", "@Error" };
            string[] v = { Code.Text, Title.Text, Abb.Text, FarsiTitle.Text, "1", DateTime.Now.ToString() };

            string Error = db.ExecuteProcedureDML(p, v, "spPageAcademicYearUpdate");

            if (Error == "0")
            {
                GridView1.EditIndex = -1;
                FillGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('Record Updated....!');", true);

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('" + Error + "');", true);


        }
    }
}