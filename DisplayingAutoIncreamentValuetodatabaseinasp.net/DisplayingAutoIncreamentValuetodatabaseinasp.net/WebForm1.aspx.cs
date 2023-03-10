using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DisplayingAutoIncreamentValuetodatabaseinasp.net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
            {
                getId();
            }
        }
        void getId()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select id from tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data =new DataTable();
            sda.Fill(data);
            if(data.Rows.Count<1)
            {
                IdTextBox.Text = "1";
            }
            else
            {

                string query1 = "select max(id) from tbl";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
               int i=Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                i = i + 1;
                IdTextBox.Text = i.ToString();
            }

        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into tbl values(@id,@name,@age)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", IdTextBox.Text);
            cmd.Parameters.AddWithValue("@name", NameTextBox.Text);
            cmd.Parameters.AddWithValue("@age", AgeTextBox.Text);
            con.Open();
            con.Close();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                Response.Write("<script>alert('Insert !!')</script>");
            }
            else
            {
                Response.Write("<script>alert('not Insert !!')</script>");
            }

        }
    }
}