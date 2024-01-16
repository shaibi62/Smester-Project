using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reviews_Website
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginFirst"] != null)
            {
                lblFirstLogin.ForeColor = System.Drawing.Color.Red;

                lblFirstLogin.Text = Session["LoginFirst"].ToString();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            lblFirstLogin.Text = "";
            var _uname = u_name.Text;
            var _password = password.Text;
            if (string.IsNullOrEmpty(_uname) && string.IsNullOrEmpty(_password))
            {
                lblUser.Text = "User Name Can't be empty";
                lblUser.ForeColor = System.Drawing.Color.Red;
                lblPass.Text = "Password Can't be empty";
                lblPass.ForeColor = System.Drawing.Color.Red;
            }
            else if (string.IsNullOrEmpty(_uname))
            {
                lblUser.Text = "User Name Can't be empty";
                lblUser.ForeColor = System.Drawing.Color.Red;
                lblPass.Text = "";
            }
            else if (string.IsNullOrEmpty(_password))
            {
                lblPass.Text = "Password Can't be empty";
                lblUser.Text = "";
                lblPass.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblPass.ForeColor = System.Drawing.Color.Green;
                lblUser.ForeColor = System.Drawing.Color.Green;

                SqlConnection sqlConnection = new SqlConnection();
                SqlCommand sqlCommand = new SqlCommand();

                sqlConnection.ConnectionString = @"Data Source=DESKTOP-N5TBIAG\SQLEXPRESS;Initial Catalog=ReviewsWeb;Integrated Security=True";
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT * FROM tblLogin where clmUsername='" + _uname + "' AND clmPassword='" + _password + "'";
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {

                    Session["UserName"] = _uname;
                    Response.Redirect("/Reviews");

                }
                else
                {
                    lblUser.Text = "Wrong Input!";
                    lblUser.ForeColor = System.Drawing.Color.Red;
                    lblPass.Text = "Wrong Input!";
                    lblPass.ForeColor = System.Drawing.Color.Red;
                }

                sqlConnection.Close();
            }
        }

    }
}