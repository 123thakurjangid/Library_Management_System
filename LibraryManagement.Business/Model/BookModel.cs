using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Model
{
    public class BookModel
    {
        [Key]
        public int Book_Id { get; set; }
        public string? Book_Title { get; set; }
        public string? Book_Author { get; set;}
        public String? Book_Category { get; set; }
        public string? Book_Description { get; set; }
        public String? Book_Prize { get; set; }
        public string? AttachmentUrl { get; set; }
        public IFormFile? Attachmentfile { get; set; }
        public string? Book_Pdf { get; set; }
        public IFormFile? Book_PdfFile { get; set; }
        
    }
}
