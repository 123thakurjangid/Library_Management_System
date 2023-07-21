using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Entities
{
    public class Users
    {
        [Key]
        public int USER_ID { get; set; }
        public string? USER_EMAIL { get; set; }
        public string? USER_PASSWORD { get; set; }
    }
}
