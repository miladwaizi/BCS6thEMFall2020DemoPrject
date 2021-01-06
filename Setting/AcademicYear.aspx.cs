using System;
using System.Collections.Generic;
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
            db.ExecuteDML(@"INSERT INTO [dbo].[tblSetup_AcademicYear]
                            ([Title]
                            ,[Abbreviation]
                            ,[FarsiTitle]
                            ,[InsertedBy]
                            ,[InsertedDate])
                             VALUES('"+txtTitle.Text+"','"+txtAbbreviation.Text+"',N'"+txtFarsiTitle.Text+"',1,'"+DateTime.Now.ToString()+"')");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ss", "SuccessMsg();", true);

        }
    }
}