using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace aventuras.idata.User
{
    public interface IUserRepository
    {
        Task<int> AddUser(aventuras.domain.User.User user);
        Task<aventuras.domain.User.User> GetUser(int userId);
        Task<aventuras.domain.User.User> GetUser(string name);
        Task EditUser(domain.User.User user);
    }
}
