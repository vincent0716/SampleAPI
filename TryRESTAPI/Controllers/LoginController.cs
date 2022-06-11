using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TryRESTAPI.WebConfig;

namespace TryRESTAPI.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/Login")]
        public IActionResult Post(LoginModel loginModel)
        {

            Register register = new Register();
            string username = loginModel.UserName;
            string password = loginModel.Password;
            MySqlConnection conn = HttpDBConnection.Conn();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM personalinfomation WHERE Username = @username AND Password =@password";
            cmd.Parameters.AddWithValue("Username", username);
            cmd.Parameters.AddWithValue("Password", password);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    register.username = reader["Username"].ToString();
                    register.password = reader["Password"].ToString();
                    register.Name = reader["Name"].ToString();
                    register.contactnumber = reader["MobileNumber"].ToString();
                    register.Birthday = reader["Birthdate"].ToString();
                    register.email = reader["EmailAddress"].ToString();
                }

                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(register);
                conn.Close();
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return Ok(ex.Message);
            }



        }


    }

}
