using LibraryManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Interface
{
    public interface IUserRepository
    {
        Users? login(Users user);
        public bool SaveUser(Users users);
    }
}
