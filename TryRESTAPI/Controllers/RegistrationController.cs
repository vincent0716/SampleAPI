using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using TryRESTAPI.WebConfig;

namespace TryRESTAPI.Controllers
{



    [ApiController]
    public class HomeController : Controller
    {


        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/Register")]
        public IActionResult Post(Register register)
        {
            HttpContext.Request.Headers["Content-Type"] = "text/json";

            string username = register.username;
            MySqlConnection conn = HttpDBConnection.Conn();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Username FROM personalinfomation WHERE Username = @username";
            cmd.Parameters.AddWithValue("Username", username);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    conn.Close();
                    return BadRequest("Username is already taken");

                }
                else
                {
                    MySqlConnection conn1 = HttpDBConnection.Conn();

                    try
                    {
                        conn1.Open();
                        MySqlCommand insert = conn1.CreateCommand();
                        insert.CommandText = "INSERT INTO personalinfomation(Username,Password,Name,Birthdate,MobileNumber,EmailAddress) VALUES (@username,@password,@name,@birthday,@contact,@email)";
                        insert.Parameters.AddWithValue("?username", username);
                        insert.Parameters.AddWithValue("?password", register.password);
                        insert.Parameters.AddWithValue("?name", register.Name);
                        insert.Parameters.AddWithValue("?birthday", register.Birthday);
                        insert.Parameters.AddWithValue("?contact", register.contactnumber);
                        insert.Parameters.AddWithValue("?email", register.email);
                        long id = insert.ExecuteNonQuery();

                        if (id > 0)
                        {
                            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(register);

                            conn1.Close();
                            return Ok(jsonString);
                        }
                        else
                        {
                            conn1.Close();
                            return BadRequest("bad yarn");
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

    }
}
