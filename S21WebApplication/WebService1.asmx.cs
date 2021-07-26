using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;


namespace S21WebApplication
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DataTable dtCountries = new DataTable();
        DBAccess objDBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Sum(int a, int b)
        {
            return a+b;
        }

        [WebMethod]
        public string Countries()
        {
            dtCountries.Columns.Add("Country Name");
            dtCountries.Columns.Add("Continent");

            dtCountries.Rows.Add("Indonesia", "Asia");
            dtCountries.Rows.Add("South Korea", "Asia");
            dtCountries.Rows.Add("Japan", "Asia");
            dtCountries.Rows.Add("England", "Europe");
            dtCountries.Rows.Add("Nigeria", "Africa");
            dtCountries.Rows.Add("Brazil", "South America");
            dtCountries.Rows.Add("USA", "North America");

            return JsonConvert.SerializeObject(dtCountries);
        }

        [WebMethod]
        public string dataTableForUsers(string id)
        {
            string query = "SELECT * FROM Users Where ID = '" + id +"'";
            objDBAccess.readDatathroughAdapter(query, dtUsers);

            string result = JsonConvert.SerializeObject(dtUsers);
            return result;
        }
    }
}
