using LibraryManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Interface
{
    public interface IBookRepository
    {
        bool Delete(int id);
        List<Books> GetBook();
        public bool SaveBook(Books books);
    }
}
