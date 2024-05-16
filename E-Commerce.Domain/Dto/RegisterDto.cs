using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.DataTransfareObject_DTO_
{
    public class RegisterDto
    {
        public string DisplayName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage ="")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "The Password Not matched")]
        public string ConfirmPassword { get; set; }




    }
}
