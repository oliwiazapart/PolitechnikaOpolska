using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.iservices.Requests;

namespace aventuras.iservices.User
{
    public interface IUserService
    {
        Task<aventuras.domain.User.User> GetUserByUserId(int userId);
        Task<aventuras.domain.User.User> GetUserByUserName(string name);
        Task<aventuras.domain.User.User> CreateUser(CreateUser createUser);
        Task EditUser(EditUser createUser, int userId);


    }
}
