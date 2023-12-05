using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class UserDto
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [MinLength(2),MaxLength(20)]
        public string FirstName { get; set; } = null!;
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; } = null!;
        [MinLength(2)]
        public string Password { get; set; } = null!;
    }
}
