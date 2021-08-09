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

        public void Main(string[] args)
        {
            Queue<Order> ordersQueue = new Queue<Order>();

            foreach (Order o in ReceiveOrdersFromBranch1())
            {
                ordersQueue.Enqueue(o);
            }

            foreach (Order o in ReceiveOrdersFromBranch2())
            {
                ordersQueue.Enqueue(o);
            }

            while (ordersQueue.Count > 0)
            {

                Order currentOrder = ordersQueue.Dequeue();
                currentOrder.ProcessOrder();
            }
        }

        static Order[] ReceiveOrdersFromBranch1()
        {
            Order[] orders = new Order[]
            {
                new Order(1,5),
                new Order(2,4),
                new Order(6,10)
            };
            return orders;
        }

        static Order[] ReceiveOrdersFromBranch2()
        {
            Order[] orders = new Order[]
            {
                new Order(3,5),
                new Order(4,4),
                new Order(5,10)
            };
            return orders;
        }

        class Order
        {
            public int OrderId { get; set; }
            public int OrderQuantity { get; set; }
            public Order(int id, int orderQuantity)
            {
                this.OrderId = id;
                this.OrderQuantity = orderQuantity;
            }

            public void ProcessOrder()
            {
                Console.WriteLine($"Order {OrderId} processed!.");
            }
        }
    }
}
