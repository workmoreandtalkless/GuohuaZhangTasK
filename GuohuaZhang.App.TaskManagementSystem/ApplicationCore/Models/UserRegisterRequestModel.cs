using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The passowrd should be minimum of 8 characters", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$",
    ErrorMessage = "Password should have minimun og 8 characters and should include one upper, lower, number and a special char " +
            "and maximum 10 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullname { get; set; }
        [Required]
        [StringLength(50)]
        public string Mobileno { get; set; }
       
    }
}
