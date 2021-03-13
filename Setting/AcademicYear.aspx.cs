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
            string[] v = { txtTitle.Text, txtAbbreviation.Text, txtFarsiTitle.Text, "1", DateTime.Now.ToString() };

            string Error = db.ExecuteProcedureDML(p, v, "spPageAcademicYearSave");

            if (Error == "0")
            {
                FillGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "SuccessMsg();", true);
                
            }
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label Code = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGvCode");

            string[] p = { "@Code", "@Error"};
            string[] v = { Code.Text};

            string Error=db.ExecuteProcedureDML(p, v, "spPageAcademicYearDelete");

            if (Error == "0")
            {
                GridView1.EditIndex = -1;
                FillGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('Record deleted....!');", true);

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('" + Error + "');", true);

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow && e.Row.RowIndex!=GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes.Add("onclick", "return confirm('Are you sure to delte this record???');");
            }
        }

        protected void imgEdit_Command(object sender, CommandEventArgs e)
        {
            string[] p = {"@Code" };
            string[] v = { e.CommandArgument.ToString()};

            DataTable dt= db.ExecuteProcedureSelect(p, v, "spPageAcademicYearLoadByID");

            if(dt.Rows.Count>0)
            {
                hfCode.Value = dt.Rows[0][0].ToString();
                txtTitle.Text = dt.Rows[0][1].ToString();
                txtAbbreviation.Text = dt.Rows[0]["Abbreviation"].ToString();
                txtFarsiTitle.Text = dt.Rows[0]["FarsiTitle"].ToString();

                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] p = { "@Code", "@Title", "@Abbreviation", "@FarsiTitle", "@User", "@Date", "@Error" };
            string[] v = { hfCode.Value, txtTitle.Text, txtAbbreviation.Text, txtFarsiTitle.Text, "1", DateTime.Now.ToString() };

            string Error = db.ExecuteProcedureDML(p, v, "spPageAcademicYearUpdate");

            if (Error == "0")
            {
                GridView1.EditIndex = -1;
                FillGrid();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('Record Updated....!');", true);

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('" + Error + "');", true);

        }

        protected void imgDelete_Command(object sender, CommandEventArgs e)
        {
            string[] p = { "@Code", "@Error" };
            string[] v = { e.CommandArgument.ToString() };

            string Error = db.ExecuteProcedureDML(p, v, "spPageAcademicYearDelete");

            if (Error == "0")
            {
                FillGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('Record deleted....!');", true);

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "alert('" + Error + "');", true);

        }
    }
}