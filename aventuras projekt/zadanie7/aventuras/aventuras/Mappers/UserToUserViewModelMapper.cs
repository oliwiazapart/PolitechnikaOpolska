using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.ViewModels;

namespace aventuras.Mappers
{
    public class UserToUserViewModelMapper
    {
        public static UserViewModel UserToUserViewModel(domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Gender = user.Gender,
                Email = user.Email,
                PostNumber = user.PostNumber,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate,
                ActiveStatus = user.ActiveStatus,
                AvatarHref = user.AvatarHref
               
            };
            return userViewModel;
        }

    }
}
