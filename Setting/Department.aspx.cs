using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCS6thEMFall2020DemoPrject.Setting
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string DeleteRecord(int Code)
        {
            DBCommunicator db = new DBCommunicator();

            string[] p = { "@Code", "@Error" };
            string[] v = { Code.ToString() };

            string r = db.ExecuteProcedureDML(p, v, "spPageDepartmentDelete");

            return r;
        }
        [WebMethod]
        public static string UpdateRecord(DepartmentInfo obj)
        {
            DBCommunicator db = new DBCommunicator();

            string[] p = { "@Code","@Title", "@Abbreviation", "@FarsiTitle", "@User", "@Date", "@Error" };
            string[] v = { obj.ID, obj.Title, obj.Abbreviation, obj.FarsiTitle, "1", DateTime.Now.ToString() };

            string r = db.ExecuteProcedureDML(p, v, "spPageDepartmentUpdate");

            return r;
        }
        [WebMethod]
        public static string SaveRecord(DepartmentInfo obj)
        {
            DBCommunicator db = new DBCommunicator();

            string[] p = { "@Title", "@Abbreviation", "@FarsiTitle", "@User", "@Date", "@Error" };
            string[] v = {obj.Title,obj.Abbreviation,obj.FarsiTitle,"1",DateTime.Now.ToString() };

            string r=db.ExecuteProcedureDML(p, v, "spPageDepartmentSave");

            return r;
        }
        [WebMethod]
        public static List<DepartmentInfo> ShowRecord()
        {
            DBCommunicator db = new DBCommunicator();
            DataTable dt = db.ExecuteProcedureSelect("spPageDepartmentLoad");
            List<DepartmentInfo> lst = new List<DepartmentInfo>();

            foreach (DataRow row in dt.Rows)
            {
                DepartmentInfo d = new DepartmentInfo();
                d.ID = row[0].ToString();
                d.Title = row["Title"].ToString();
                d.Abbreviation = row["Abbreviation"].ToString();
                d.FarsiTitle = row["FarsiTitle"].ToString();
                d.Edit = true;
                d.Delete = true;

                lst.Add(d);
            }

            return lst;
        }

    }

    public class DepartmentInfo
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public string FarsiTitle { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }

    }
}