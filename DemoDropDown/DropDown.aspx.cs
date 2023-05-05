using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DemoDropDown
{
    public partial class DropDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shakti"].ConnectionString);

            ////2 Open  Connection
            if (con.State == ConnectionState.Closed)
                con.Open();

            //// 3 Create a Command

            SqlCommand cmd = new SqlCommand("Select * from UserDetail", con);
            //DataTable dt = new DataTable();
            GridView1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //1 Create Connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shakti"].ConnectionString);

            //2 Open  Connection
            if (con.State == ConnectionState.Closed)
                con.Open();

            // 3 Create a Command

           // SqlCommand cmd = new SqlCommand("select * from UserDetail where id = '" + DropDownList1.SelectedValue + "'", con);

            SqlCommand cmd = new SqlCommand("Select * from UserDetail", con);
            //4 Execute Command

            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            
            Label1.Text = "record found";

            // 5 Connection Close

            if (con.State == ConnectionState.Open)
                con.Close();

            //DataTable dt = new DataTable();
            //cmd.Fill(dt);
            //DropDownList1.DataSource = dt;
            //DropDownList1.DataBind();
            //DropDownList1.DataTextField = "Name";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataBind();

        }
    }
}