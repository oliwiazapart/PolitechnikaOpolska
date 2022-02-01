using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.Validation;
using aventuras.ViewModels;
using aventuras.BindingModels;
using aventuras.data.sql;
using aventuras.data.sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aventuras.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class UserController : Controller
    {
        private readonly AventurasDbContext _context;

        public UserController(AventurasDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    Gender = user.Gender,
                    PostNumber = user.PostNumber,
                    BirthDate = user.BirthDate,
                    RegistrationDate = user.RegistrationDate,
                    ActiveStatus = user.ActiveStatus,
                    AvatarHref = user.AvatarHref
                });
            }

            return NotFound();
        }

        [HttpGet("name/{userName}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Name == userName);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    Gender = user.Gender,
                    PostNumber = user.PostNumber,
                    BirthDate = user.BirthDate,
                    RegistrationDate = user.RegistrationDate,
                    ActiveStatus = user.ActiveStatus,
                    AvatarHref = user.AvatarHref
                });
            }

            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new User
            {
                Name = createUser.Name,
                Email = createUser.Email,
                Gender = createUser.Gender,
                BirthDate = createUser.BirthDate,
                PostNumber = 0,
                RegistrationDate = DateTime.UtcNow,
                ActiveStatus = true
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created(user.UserId.ToString(), new UserViewModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                PostNumber = user.PostNumber,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
                ActiveStatus = user.ActiveStatus,
                AvatarHref = user.AvatarHref
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            user.Name = editUser.Name;
            user.Email = editUser.Email;
            user.BirthDate = editUser.BirthDate;
            user.Gender = editUser.Gender;
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new UserViewModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                PostNumber = user.PostNumber,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
                ActiveStatus = user.ActiveStatus,
                AvatarHref = user.AvatarHref
            });
        }

        [HttpDelete("{userId:min(1)}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound();

        }
    }
}
