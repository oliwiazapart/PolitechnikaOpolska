using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.idata.User;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace aventuras.data.sql.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AventurasDbContext _context;

        public UserRepository(AventurasDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(domain.User.User user)
        {
            var userDAO = new DAO.User
            {
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                PostNumber = user.PostNumber,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
                ActiveStatus = user.ActiveStatus
            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }

        public async Task<domain.User.User> GetUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return new domain.User.User(user.UserId,
                user.Name,
                user.Gender,
                user.Email,
                user.PostNumber,
                user.BirthDate,
                user.RegistrationDate,
                user.ActiveStatus,
                user.AvatarHref);

        }

        public async Task<domain.User.User> GetUser(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Name == userName);
            return new domain.User.User(user.UserId,
                user.Name,
                user.Gender,
                user.Email,
                user.PostNumber,
                user.BirthDate,
                user.RegistrationDate,
                user.ActiveStatus,
                user.AvatarHref);
        }

        public async Task EditUser(domain.User.User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == user.UserId);
            editUser.Name = user.Name;
            editUser.Email = user.Email;
            editUser.Gender = user.Gender;
            editUser.BirthDate = user.BirthDate;
            await _context.SaveChangesAsync();
        }
    }
}
