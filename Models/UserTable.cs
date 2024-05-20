using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;


namespace Assignment1.Models
{
    public class UserTable
    {
        public static string con_string = "Server=tcp:cloud-dev-server.database.windows.net,1433;Initial Catalog=CLOUD_DEV;Persist Security Info=False;User ID=CalebVoskuil;Password=##LenovoSilver!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public int insert_User(UserTable m) 
        {
            string sql = " INSERT INTO UserTable (UserName, UserSurname, UserEmail, UserPassword) VALUES (@Name, @Surname, @Email, @Password)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Surname", m.Surname);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Password", m.Password);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            return rowsAffected;


        }

    }
}
