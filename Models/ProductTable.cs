using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Assignment1.Models
{
    public class ProductTable
    {
        public static string con_string = "Server=tcp:cloud-dev-server.database.windows.net,1433;Initial Catalog=CLOUD_DEV;Persist Security Info=False;User ID=CalebVoskuil;Password=##LenovoSilver!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool Availability { get; set; }
        

        public int insert_Product(ProductTable p)
        {
            try
            {
                string sql = "INSERT INTO ProductTable (ProductName, ProductPrice, ProductCategory, ProductAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ProductTable> select_Products()
        {
            List<ProductTable> products = new List<ProductTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT (ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability) FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    ProductTable product = new ProductTable();
                    product.ProductID = Convert.ToInt32(reader1["ProductID"]);
                    product.Name = Convert.ToString(reader1["ProductName"]);
                    product.Price = Convert.ToDecimal(reader1["ProductPrice"]);
                    product.Category = Convert.ToString(reader1["ProductCategory"]);
                    product.Availability = Convert.ToBoolean(reader1["ProductAvailability"]);
                    products.Add(product);
                }
                reader1.Close();
            }
                    
            return products;
        }

    }
}
