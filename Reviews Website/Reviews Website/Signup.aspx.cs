using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reviews_Website
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            /***************************************************************************/

            var _uname = email.Value;
            var _password = password.Text;
            var _confirmpassword = ConfirmPassword.Text;
            if (string.IsNullOrEmpty(_uname) && string.IsNullOrEmpty(_password) && string.IsNullOrEmpty(_confirmpassword))
            {
                lblUser.Text = "User Name Can't be empty";
                lblUser.ForeColor = System.Drawing.Color.Red;
                lblPass.Text = "Password Can't be empty";
                lblPass.ForeColor = System.Drawing.Color.Red;
                lblConfirmPassword.ForeColor = System.Drawing.Color.Red;
                lblConfirmPassword.Text = "Confirm Password Can't be empty";

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

            else if (string.IsNullOrEmpty(_confirmpassword))
            {
                lblPass.Text = "Confirm Password Can't be empty";
                lblUser.Text = "";
                lblPass.ForeColor = System.Drawing.Color.Red;
            }
            else if (string.IsNullOrEmpty(_password) && string.IsNullOrEmpty(_confirmpassword))
            {
                lblPass.Text = "Password Donot Match";
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
                sqlCommand.CommandText = "SELECT * FROM tblUserLogin where clmUsername='" + _uname + "' AND clmPassword='" + _password + "'";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
                if (reader.HasRows)
                {
                    lblProductName.Text = "Product is already added!";
                    lblProductName.ForeColor = System.Drawing.Color.Red;
                    lblProductDescription.Text = "";
                    lblProductImage.Text = "";
                }
                else
                {
                    sqlConnection.Close();
                    sqlConnection.Open();

                    sqlCommand.CommandText = "INSERT INTO tblProduct(clmProductName, clmProductDescription, clmProductImage) VALUES(@ProductName, @ProductDescription, @ProductImage)";
                    sqlCommand.Parameters.AddWithValue("@ProductName", _ProductName);
                    sqlCommand.Parameters.AddWithValue("@ProductDescription", _ProductDescription);
                    sqlCommand.Parameters.AddWithValue("@ProductImage", uniqueName);
                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }

                sqlConnection.Close();
            }
        /********************************************************************************/
    }
    }
}