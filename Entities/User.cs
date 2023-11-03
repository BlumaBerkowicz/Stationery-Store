using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {

        public int userId { get; set; }
        [MaxLength(15)]
        [MinLength(2)]

        public string firstName { get; set; }
        [MaxLength(15)]
        [MinLength(2)]
        public string lastName { get; set; }

        [EmailAddress]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }

        public static int numOfUsers { get; set; }

    }
}
