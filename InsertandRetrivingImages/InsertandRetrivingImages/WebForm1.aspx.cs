using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace InsertandRetrivingImages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string path = Server.MapPath("images/");
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string extension = Path.GetExtension(fileName);
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                int length = postedFile.ContentLength;
                if (extension.ToLower() == " .jpg" || extension.ToLower() == " .png " || extension.ToLower() == " .jpeg")
                {
                    if (length <= 1000000)//1000000 meanuce 1 mb
                    {
                        FileUpload1.SaveAs(path + fileName);
                        string name = "images/" + fileName;
                        string query = "insert into img values(@img)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@img", name);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            Label1.Text = "Inserted Successfully !! ";
                            Label1.ForeColor = System.Drawing.Color.Green;
                            Label1.Visible = true;
                        }
                        else
                        {
                            Label1.Text = "Insertion Failed !! ";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                        }
                        con.Close();
                    }
                    else
                    {
                        Label1.Text = "Image file should not be  greater than 1 mb !! ";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Visible = true;
                    }
                }
                else
                {
                    Label1.Text = "Image Format is not supported !! ";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Visible = true;
                }

            }
            else
            {
                Label1.Text = "Please Upload an IMAGE !!";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
            }
        }


    }
 }
