using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ganesh_tiles
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                string str = ConfigurationManager.ConnectionStrings["kishore"].ConnectionString;
                SqlConnection con = new SqlConnection(str);
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_gt_register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = txt_name.Text;
                SqlParameter p2 = new SqlParameter("@username", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = txt_uname.Text;
                SqlParameter p3 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = txt_pwd.Text;
                SqlParameter p4 = new SqlParameter("@cpassword", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = txt_cpwd.Text;
                SqlParameter p5 = new SqlParameter("@email", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = txt_email.Text;
                SqlParameter p6 = new SqlParameter("@phone", SqlDbType.VarChar);
                cmd.Parameters.Add(p6).Value = txt_phone.Text;
                SqlParameter p7 = new SqlParameter("@location", SqlDbType.VarChar);
                cmd.Parameters.Add(p7).Value = txt_location.Text;

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    Response.Write("Register Successfully");
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write("Register Failed");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        
    }
}