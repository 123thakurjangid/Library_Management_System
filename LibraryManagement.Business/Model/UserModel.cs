using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Model
{
    public class UserModel
    {
        [Key]
        public int User_Id { get; set; }
        [Required(ErrorMessage = "Please fill the user email")]
        public string? User_email { get; set; }
        [Required(ErrorMessage = "Please fill the user password")]
        [DataType(DataType.Password)]
        public string? User_Password { get; set;}

    }
}
