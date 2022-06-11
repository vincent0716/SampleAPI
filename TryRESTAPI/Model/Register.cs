using System.ComponentModel.DataAnnotations;

namespace TryRESTAPI
{
    public class Register
    {

        [Required]
       public String Name { get; set; }
        [Required]
        public String Birthday { get; set; }

        /* public String gender { get; set; }*/

        [Required]
        public String contactnumber { get; set; }
        [Required]
        public String username { get; set; }
        [Required]
        public String password { get; set; }
        [Required]
        public String email { get; set; }
    }
}
