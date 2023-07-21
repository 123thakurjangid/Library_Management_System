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
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContexts userDbContexts;

        public UserRepository()
        {
            userDbContexts = new UserDbContexts();
        }

        public bool SaveUser(Users users)
        {
            userDbContexts.Users.Add(users);
            return userDbContexts.SaveChanges() > 0 ? true : false;
        }

        public Users? login(Users User)
        {
            if (User == null || string.IsNullOrEmpty(User.USER_EMAIL) || string.IsNullOrEmpty(User.USER_PASSWORD))
            {
                return null;
            }

            var data = userDbContexts.Users.Where(x => x.USER_EMAIL == User.USER_EMAIL && x.USER_PASSWORD == User.USER_PASSWORD).FirstOrDefault();

            return data;
        }

    }
}
