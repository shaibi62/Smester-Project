using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reviews_Website
{
    public partial class Reviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                h3.InnerText = "Welcome, " + Session["UserName"].ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int productId = 0;
            string _ProductName = ProductName.Text;

            if (string.IsNullOrEmpty(_ProductName))
            {
                lblProductName.Text = "Product Name Can't be empty";
                lblProductName.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblProductName.Text = "";
                SqlConnection sqlConnection = new SqlConnection();
                SqlCommand sqlCommand = new SqlCommand();

                sqlConnection.ConnectionString = @"Data Source=DESKTOP-N5TBIAG\SQLEXPRESS;Initial Catalog=ReviewsWeb;Integrated Security=True";
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT * FROM tblProduct WHERE clmProductName = @ProductName";
                sqlCommand.Parameters.AddWithValue("@ProductName", _ProductName);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblProductName.ForeColor = System.Drawing.Color.Green;
                        lblProductName.Text = "Product founded Successfully!";
                        string productName = reader.GetString(reader.GetOrdinal("clmProductName"));
                        string productDescription = reader.GetString(reader.GetOrdinal("clmProductDescription"));
                        string productImage = reader.GetString(reader.GetOrdinal("clmProductImage"));
                        productId = reader.GetInt32(reader.GetOrdinal("clmProductId"));

                        lblFetchedName.Text = "Product name is:";
                        FetchedName.InnerText = productName;
                        lblFetchedDescription.Text = "Product Description is:" + "Debug: Image Path - " + productImage;
                        FetchedDescription.InnerText = productDescription;
                        FetchedImage.Src = "~/uploads/" + productImage;
                        FetchedImage.Height = 250;
                        break;
                    }
                    sqlConnection.Close();

                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT * FROM tblReview WHERE clmProductId = @productId";
                    sqlCommand.Parameters.AddWithValue("@productId", productId);

                    reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string reviewMessage = reader.GetString(reader.GetOrdinal("clmReviewMessage"));
                            int ratingStars = reader.GetInt32(reader.GetOrdinal("clmRatingStars"));
                            string reviewInfo = $"Message: {reviewMessage}, Stars: {ratingStars}";

                            lblReviews.Text += reviewInfo + "<br />";
                        }
                    }
                    else
                    {
                        lblReviews.Text = "No reviews available for this product.";
                    }

                }
                else
                {
                    lblProductName.ForeColor = System.Drawing.Color.Red;
                    lblProductName.Text = "Product not found!";
                }
            }    
        }
    }
}