using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Assignment1.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:cloud-dev-server.database.windows.net,1433;Initial Catalog=CLOUD_DEV;Persist Security Info=False;User ID=CalebVoskuil;Password=##LenovoSilver!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int select_User(string Password, string name)
        {
            int userID = -1;
            using (SqlConnection con = new SqlConnection(con_string))
            {

                string sql = "SELECT UserID FROM UserTable WHERE UserPassword = @Password AND UserName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userID;


        }
    }
}
