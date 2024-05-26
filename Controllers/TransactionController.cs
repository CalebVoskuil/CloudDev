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
                            return RedirectToAction("Home","Home");
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

    }
}
