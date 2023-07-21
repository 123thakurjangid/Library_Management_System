using LibraryManagement.Business.IService;
using LibraryManagement.Business.Model;
using LibraryManagement.Data.Entities;
using LibraryManagement.Data.Interface;
using LibraryManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService()
        {
            bookRepository = new BookRepository();
        }
        public bool AddBook(BookModel bookModel)
        {
            bool result = false;

            Books book = new Books();
            book.BOOK_ID = bookModel.Book_Id;
            book.BOOK_TITLE = bookModel.Book_Title;
            book.BOOK_AUTHOR = bookModel.Book_Author;
            book.BOOK_CATEGORY = bookModel.Book_Category;
            book.BOOK_DESCRIPTION = bookModel.Book_Description;
            book.BOOK_PRIZE = bookModel.Book_Prize;
            book.ATTACHMENTURL = bookModel.AttachmentUrl;
            book.BOOK_PDF = bookModel.Book_Pdf;

            result = bookRepository.SaveBook(book);

            return result;
        }
        public List<BookModel> GetAllBooksDetails()
        {
            return bookRepository.GetBook().Select(x => new BookModel
            {
                Book_Id = x.BOOK_ID,
                Book_Title = x.BOOK_TITLE,
                Book_Author = x.BOOK_AUTHOR,
                Book_Category = x.BOOK_CATEGORY,
                Book_Prize = x.BOOK_PRIZE,
                Book_Description = x.BOOK_DESCRIPTION,
                Book_Pdf = x.BOOK_PDF,
                AttachmentUrl = x.ATTACHMENTURL
            }).ToList();
        }
        public bool Delete(int id)
        {
            return bookRepository.Delete(id);
        }
    }
}
