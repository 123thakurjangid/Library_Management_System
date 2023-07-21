using LibraryManagement.Business.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.IService
{
    public interface IBookService
    {
        bool AddBook(BookModel bookModel);
        List<BookModel> GetAllBooksDetails();
        bool Delete(int  id);
    }
}
