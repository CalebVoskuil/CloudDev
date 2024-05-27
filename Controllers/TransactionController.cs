using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using System.Data.SqlClient;

namespace Assignment1.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ProductTable.con_string))
                {
                    string sql = "INSERT INTO TransactionTable (UserID, ProductID) VALUES (@userID, @productID)";


                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("MyOrders");
                        }
                        else
                        {
                            return View("Order Failed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public ActionResult MyOrders(int userID)
        {
            try
            {
                List<OrderViewModel> orders = new List<OrderViewModel>();

                // Fetch orders from the database and map them to OrderViewModel objects
                using (SqlConnection con = new SqlConnection(ProductTable.con_string))
                {
                    string sql = "SELECT TransactionID, ProductName, ProductPrice FROM TransactionTable JOIN ProductTable ON TransactionTable.ProductID = ProductTable.ProductID WHERE UserID = @userID";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderViewModel order = new OrderViewModel
                                {
                                    TransactionID = (int)reader["TransactionID"],
                                    ProductName = reader["ProductName"].ToString(),
                                    ProductPrice = (decimal)reader["ProductPrice"],
                                    
                                };
                                orders.Add(order);
                            }
                        }
                    }
                }

                return View(orders);
            }
            catch (Exception ex)
            {
                // Log the error and return an error view
                return View("Error");
            }
        }


    }
    }
