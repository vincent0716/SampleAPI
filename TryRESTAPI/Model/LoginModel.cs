using System.ComponentModel.DataAnnotations;

namespace TryRESTAPI
{
    public class LoginModel
    {

        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }

        /*public String Name { get; set; }
        public String Birthday { get; set; }
        public String contactnumber { get; set; }
        public String email { get; set; }*/
    }
}
