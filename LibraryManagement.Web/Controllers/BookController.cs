using LibraryManagement.Business.IService;
using LibraryManagement.Business.Model;
using LibraryManagement.Business.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting.Internal;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace LibraryManagement.Web.Controllers
{
    public class BookController : Controller
    {
        private IHostingEnvironment hostingEnv;
        private readonly IBookService bookService;
        public BookController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
            bookService = new BookService();
        }
        public IActionResult AllBooks()
        {
            string? UserName = HttpContext.Session.GetString("UserEmail");
            string? UserId = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserId))
            {
                return RedirectToAction("Login","User");
            }

            List<BookModel> ShowBooks = new List<BookModel>();
            ShowBooks = bookService.GetAllBooksDetails();
            return View(ShowBooks);
        }
        public IActionResult HomePage()
        {
            string? UserName = HttpContext.Session.GetString("UserEmail");
            string? UserId = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserId))
            {
                return RedirectToAction("Login", "User");
            }

            List<BookModel> ShowBooks = new List<BookModel>();
            ShowBooks = bookService.GetAllBooksDetails();
            return View(ShowBooks);
        }
        [HttpGet]
        public IActionResult BooksAddForm()
        {
            string? UserName = HttpContext.Session.GetString("UserEmail");
            string? UserId = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserId))
            {
                return RedirectToAction("Login", "User");
            }

            BookModel model = new BookModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBook(BookModel bookModel)
        {
            if (bookModel != null && bookModel.Attachmentfile != null && bookModel.Book_PdfFile != null)
            {
                var filePath = "/image/";

                bookModel.AttachmentUrl = filePath + bookModel.Attachmentfile.FileName;
                filePath = @"D:\\Upload\\" + bookModel.Attachmentfile.FileName;
                using (var stream = System.IO.File.Create(filePath))
                {
                    await bookModel.Attachmentfile.CopyToAsync(stream);
                }
                filePath = "/image/";
                bookModel.Book_Pdf = filePath + bookModel.Book_PdfFile.FileName;
                filePath = @"D:\\Upload\\" + bookModel.Book_PdfFile.FileName;
                using (var stream = System.IO.File.Create(filePath))
                {
                    await bookModel.Book_PdfFile.CopyToAsync(stream);
                }
            }

            if (bookModel != null && bookModel.Attachmentfile != null)
            {
                var FileDic = "Image";
                string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);
                var fileName = bookModel.Attachmentfile.FileName;
                var filePath = Path.Combine(FilePath, fileName);

                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    bookModel.Attachmentfile.CopyTo(fs);
                }
            }
            if (bookModel != null && bookModel.Book_PdfFile != null)
            {
                var FileDic = "Image";
                string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);
                var fileName = bookModel.Book_PdfFile.FileName;
                var filePath = Path.Combine(FilePath, fileName);

                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    bookModel.Book_PdfFile.CopyTo(fs);
                }
            }

            bool result = bookService.AddBook(bookModel);
            return RedirectToAction("Homepage");
        }

        [HttpGet]
        public IActionResult SearchBook(string searchBy, string Search)
        {
            List<BookModel> SearchBooks = new List<BookModel>();
            SearchBooks = bookService.GetAllBooksDetails();

            if (searchBy == "BookCategory")
            {
                var Search_data = SearchBooks.Where(Model => Model.Book_Category.StartsWith(Search)).ToList();
                return View(Search_data);
            }
            else if (searchBy == "BookTitle")
            {
                var Search_data = SearchBooks.Where(Model => Model.Book_Title.StartsWith(Search)).ToList();
                return View(Search_data);
            }
            else
            {
                Search = " ";
                var Search_data = SearchBooks.Where(Model => Model.Book_Category.StartsWith(Search)).ToList();
                return View(Search_data);

            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if(Id == 0)
            {
                TempData["Message"] = "Record not found to delete";
                return RedirectToAction("AllBooks", "Book");
            }
            if (bookService.Delete(Id))
            {
                TempData["Message"] = "Record deleted successfully";
            }
            else
            {
                TempData["Message"] = "Record not deleted";
            }
            return RedirectToAction("AllBooks", "Book");
        }
        
    }
}
