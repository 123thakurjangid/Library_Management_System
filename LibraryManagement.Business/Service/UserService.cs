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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService() 
        {
            userRepository = new UserRepository();
        }
        public bool AddUser(UserModel usermodel)
        {
            bool result = false;

            Users users = new Users();

            users.USER_ID = usermodel.User_Id;
            users.USER_EMAIL = usermodel.User_email;
            users.USER_PASSWORD = usermodel.User_Password;

            result = userRepository.SaveUser(users);

            return result;
        }
        public Users? login(UserModel userModel)
        {
            Users? result = null;

            Users User = new Users();

            User.USER_ID = userModel.User_Id;
            User.USER_EMAIL = userModel.User_email;
            User.USER_PASSWORD = userModel.User_Password;

            result = userRepository.login(User);

            return result;
        }
    }
}
