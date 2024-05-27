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
        public string Price { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }
        

        public int insert_Product(ProductTable p)
        {
            try
            {
                string sql = "INSERT INTO ProductTable (ProductName, ProductPrice, ProductCategory, ProductAvalability) VALUES (@Name, @Price, @Category, @Availability)";
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

        public static List<ProductTable> GetAllProducts()
        {
            List<ProductTable> products = new List<ProductTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductTable product = new ProductTable();
                    product.ProductID = Convert.ToInt32(rdr["ProductID"]);
                    product.Name = rdr["ProductName"].ToString();
                    product.Price = rdr["ProductPrice"].ToString();
                    product.Category = rdr["ProductCategory"].ToString();
                    product.Availability = rdr["ProductAvalability"].ToString();

                    products.Add(product);
                   
                }
            }
            
            return products;
        }

    }
}
