using System;
using System.Collections.Generic;
using System.Text;
using aventuras.idata.User;
using aventuras.iservices.Requests;
using aventuras.iservices.User;
using System.Threading.Tasks;

namespace aventuras.services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<domain.User.User> GetUserByUserId(int userId)
        {
            return _userRepository.GetUser(userId);
        }

        public Task<domain.User.User> GetUserByUserName(string userName)
        {
            return _userRepository.GetUser(userName);
        }

        public async Task<domain.User.User> CreateUser(CreateUser createUser)
        {
            var user = new domain.User.User(createUser.Name, createUser.Gender, createUser.Email, createUser.BirthDate);
            user.UserId = await _userRepository.AddUser(user);
            return user;
        }

        public async Task EditUser(EditUser createUser, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            user.EditUser(createUser.Name, createUser.Gender, createUser.Email, createUser.BirthDate);
            await _userRepository.EditUser(user);
        }
    }
}
