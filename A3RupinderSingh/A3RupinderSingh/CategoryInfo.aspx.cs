using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace A3RupinderSingh
{
    public partial class A3 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "Select CategoryID,CategoryName from Categories;";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    Category.DataSource = reader;
                    Category.DataTextField = "CategoryName";
                    Category.DataValueField = "CategoryID";
                    Category.DataBind();
                }
                ListItem liSelect = new ListItem("Select a Product", "-1");
                Product.Items.Insert(0, liSelect);
                Product.Enabled = false;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string query = "Select ProductID, ProductName from Products where CategoryID = "+ Category.SelectedValue + ";";
            Product.Enabled = true;
            order.DataSource = null;
            order.DataBind();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Product.DataSource = reader;
                Product.DataTextField = "ProductName";
                Product.DataValueField = "ProductID";
                Product.DataBind();
            }
            ListItem liSelect = new ListItem("Select a Product", "-1");
            Product.Items.Insert(0, liSelect);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select Orders.OrderID, OrderDate, ShippedDate, ShipName, ShipAddress, ShipCity, ShipCountry from Orders inner join [Order Details] on Orders.OrderID  = [Order Details].OrderID where [Order Details].ProductID = "+ Product.SelectedValue +";";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                order.DataSource = reader;
                order.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}