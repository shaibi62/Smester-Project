using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Reviews_Website
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Session["LoginFirst"] = "Please Login as Admin first to access the page!";
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var _ProductName = ProductName.Text;
            var _ProductDescription = ProductDescription.Text;
            var _ProductImage = image.HasFile;
            if (string.IsNullOrEmpty(_ProductName) && string.IsNullOrEmpty(_ProductDescription) && _ProductImage)
            {
                lblProductName.Text = "Product Name Can't be empty";
                lblProductName.ForeColor = System.Drawing.Color.Red;
                lblProductDescription.Text = "Product Description Can't be empty";
                lblProductDescription.ForeColor = System.Drawing.Color.Red;
                lblProductImage.Text = "Product Image Can't be empty";
                lblProductImage.ForeColor = System.Drawing.Color.Red;
            }

            else if (string.IsNullOrEmpty(_ProductName))
            {
                lblProductName.Text = "Product Name Can't be empty";
                lblProductName.ForeColor = System.Drawing.Color.Red;
                lblProductDescription.Text = "";
                lblProductDescription.ForeColor = System.Drawing.Color.Red;
                lblProductImage.Text = "";
                lblProductImage.ForeColor = System.Drawing.Color.Red;
            }
            else if (string.IsNullOrEmpty(_ProductDescription))
            {
                lblProductName.Text = "";
                lblProductName.ForeColor = System.Drawing.Color.Red;
                lblProductDescription.Text = "Product Description Can't be empty";
                lblProductDescription.ForeColor = System.Drawing.Color.Red;
                lblProductImage.Text = "";
                lblProductImage.ForeColor = System.Drawing.Color.Red;
            }
            else if (!_ProductImage)
            {
                lblProductName.Text = "";
                lblProductName.ForeColor = System.Drawing.Color.Red;
                lblProductDescription.Text = "";
                lblProductDescription.ForeColor = System.Drawing.Color.Red;
                lblProductImage.Text = "Product Image Can't be empty";
                lblProductImage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblProductName.Text = "";
                lblProductDescription.Text = "";
                lblProductImage.Text = "";
                /*----------------------------------------------------------------*/

                // Define the directory to store the uploaded images
                string uploadDir = Server.MapPath("~/uploads/");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                // Get the uploaded file details
                string fileName = Path.GetFileName(image.FileName);
                string uniqueName = Guid.NewGuid() + "_" + fileName;

                // Save the file to the server
                string filePath = Path.Combine(uploadDir, uniqueName);
                image.SaveAs(filePath);

                /*----------------------------------------------------------------*/
                SqlConnection sqlConnection = new SqlConnection();
                SqlCommand sqlCommand = new SqlCommand();

                sqlConnection.ConnectionString = @"Data Source=DESKTOP-N5TBIAG\SQLEXPRESS;Initial Catalog=ReviewsWeb;Integrated Security=True";
                sqlCommand.Connection = sqlConnection;
                try
                {
                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT * FROM tblProduct where clmProductName='" + _ProductName + "'";
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
                        sqlConnection.Open();

                        sqlCommand.CommandText = "SELECT * FROM tblProduct where clmProductName='" + _ProductName + "'";
                        reader = sqlCommand.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string id = reader["clmProductId"].ToString();
                                sqlConnection.Close();
                                sqlConnection.Open();
                                sqlCommand.CommandText = "INSERT INTO tblReview(clmProductId) VALUES('" + id + "')";
                                sqlCommand.ExecuteNonQuery();
                                lblShow.ForeColor = System.Drawing.Color.Green;
                                lblShow.Text = "Added Successfully!";
                                break;
                            }
                        }

                        

                    }
                    sqlConnection.Close();
                }
                catch (Exception ex) 
                {
                    lblShow.ForeColor = System.Drawing.Color.Red;
                    lblShow.Text = ex.Message;
                }
            }

        }

    }
}