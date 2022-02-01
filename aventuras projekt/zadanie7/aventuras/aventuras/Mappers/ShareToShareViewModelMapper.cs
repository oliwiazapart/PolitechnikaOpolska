using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aventuras.ViewModels;

namespace aventuras.Mappers
{
    public class ShareToShareViewModelMapper
    {
        public static ShareViewModel ShareToShareViewModel(domain.Share.Share share)
        {
            var shareViewModel = new ShareViewModel
            {
                ShareId = share.ShareId,
                PostId = share.PostId,
                UserId = share.UserId

            };
            return shareViewModel;
        }
    }
}
