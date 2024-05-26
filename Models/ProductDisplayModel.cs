using System.Collections.Generic;
using Assignment1.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Models
{
    public class ProductDisplayModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public ProductDisplayModel() { }

        public ProductDisplayModel(int productID, string productName, decimal productPrice, string productCategory, bool productAvailability)
        {
            ProductID = productID;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
            ProductAvailability = productAvailability;
        }

        public static List<ProductDisplayModel> select_Products()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:cloud-dev-server.database.windows.net,1433;Initial Catalog=CLOUD_DEV;Persist Security Info=False;User ID=CalebVoskuil;Password=##LenovoSilver!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    ProductDisplayModel product = new ProductDisplayModel();
                    product.ProductID = Convert.ToInt32(reader1["ProductID"]);
                    product.ProductName = Convert.ToString(reader1["ProductName"]);
                    product.ProductPrice = Convert.ToDecimal(reader1["ProductPrice"]);
                    product.ProductCategory = Convert.ToString(reader1["ProductCategory"]);
                    product.ProductAvailability = Convert.ToBoolean(reader1["ProductAvailability"]);
                    products.Add(product);
                }
                reader1.Close();
            }
                    
            return products;
        }
    }
}
