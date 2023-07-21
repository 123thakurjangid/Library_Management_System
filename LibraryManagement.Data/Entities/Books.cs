using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Entities
{
    public class Books
    {
        [Key]
        public int BOOK_ID { get; set; }
        public string? BOOK_TITLE { get; set; }
        public string? BOOK_AUTHOR { get; set; }
        public String? BOOK_CATEGORY { get; set; }
        public string? BOOK_DESCRIPTION { get; set; }
        public String? BOOK_PRIZE { get; set; }
        public string? ATTACHMENTURL { get; set; }
        public string? BOOK_PDF { get; set; }
    }
}
