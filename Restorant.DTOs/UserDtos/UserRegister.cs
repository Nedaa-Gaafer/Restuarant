using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.UserDtos
{
    public class UserRegister
    {
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password")]
        [Display(Name = " Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set;}

        public string Address { get; set; }
        public string Email { get; set; }
       

    }
}
