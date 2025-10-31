using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.DTOs.UserDtos
{
    public class Role
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
