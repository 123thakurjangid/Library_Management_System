using LibraryManagement.Business.Model;
using LibraryManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.IService
{
    public interface IUserService
    {
        bool AddUser(UserModel usermodel);
        Users? login(UserModel userModel);
    }
}
