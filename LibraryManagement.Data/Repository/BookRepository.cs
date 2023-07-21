using LibraryManagement.Data.DbContexts;
using LibraryManagement.Data.Entities;
using LibraryManagement.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContexts bookDbContexts;

        public BookRepository()
        {
            bookDbContexts = new BookDbContexts();
        }

        public bool SaveBook(Books books)
        {
            bookDbContexts.Books.Add(books);
            return bookDbContexts.SaveChanges() > 0 ? true : false;
        }
        public List<Books> GetBook()
        {
            return bookDbContexts.Books.ToList();
        }

        public bool Delete(int id)
        {
            var Book = bookDbContexts.Books.Find(id);
            if(Book != null)
            {
                bookDbContexts.Books.Remove(Book);
                return bookDbContexts.SaveChanges() > 0 ? true : false;
            }
            else
            {
                  return false;
            }
        }
    }
}
