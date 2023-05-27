using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBaybars.Helpers;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    public class ExcellController : Controller
    {
       BarkodcuboEntities db = new BarkodcuboEntities();

       // GET: Excell
        public ActionResult Index()
        {
            string record;
            string connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("select Barkod from [ibrahimbarkod].[Bay_SatisTarihi] group by Barkod ", sqlConnection);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                record = reader["Barkod"].ToString();
                sqlConnection.Close();
                List<string> model = new List<string>();
                while (reader.Read())
                {
                    model.Add(reader["Barkod"].ToString());
                }
            }

            //ViewBag.Demo = model;
            return View();
        }
        //public void GridExportToExcel()
        //{


        //    DataTable dt = new DataTable();
        //    dt.Columns.AddRange(new DataColumn[3] {
        //              new DataColumn("Barkod"),
        //             new DataColumn("ÜrünAdi"),
        //                new DataColumn("Adet")});
        //    foreach (var item in db.Bay_SatisTarihi.Select(x => x.Barkod).Distinct())
        //    {
        //        dt.Rows.Add(item, GetData.ProductName(item.Trim()), Stoklar.KalanToplam(item));
        //    }
        //    string dosyaAdi = "KuranlarSatislari";
        //    var grid = new GridView();
        //    grid.DataSource = dt;
        //    grid.DataBind();

        //    Response.ClearContent();
        //    Response.Charset = "utf-8";
        //    Response.AddHeader("content-disposition", "attachment; filename=" + dosyaAdi + ".xls");

        //    Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);

        //    grid.RenderControl(htw);

        //    Response.Write(sw.ToString());
        //    Response.End();
        //}
        //public ActionResult UserDetails(DashBoard dash)
        //{

        //    using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        String sql = "SELECT DU.UserRMN, MU.Name, DeptName, MgrID, TLeadID FROM Details_Users DU, Master_Users MU where DU.UserRMN=MU.UserRMN";
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //        cn.Open();
        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        List<DashBoard> model = new List<DashBoard>();
        //        while (rdr.Read())
        //        {
        //            var details = new DashBoard();
        //            details.UserRMN = rdr["UserRMN"].ToString();
        //            details.Name = rdr["Name"].ToString();
        //            details.DeptID = rdr["DeptID"].ToString();
        //            details.MgrID = rdr["MgrID"].ToString();
        //            details.TLeadID = rdr["TLeadID"].ToString();
        //            model.Add(details);
        //        }
        //        return View("ViewName", model);
        //    }
        //} 

    }
}