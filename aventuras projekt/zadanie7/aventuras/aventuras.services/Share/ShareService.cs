using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.iservices.Requests;
using aventuras.iservices.Share;
using aventuras.idata.Share;

namespace aventuras.services.Share
{
    public class ShareService : IShareService
    {
        private readonly IShareRepository _shareRepository;

        public ShareService(IShareRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }

        public Task<domain.Share.Share> GetShareByShareId(int shareId)
        {
            return _shareRepository.GetShare(shareId);
        }

        public async Task<domain.Share.Share> CreateShare(CreateShare createShare)
        {
            var share = new domain.Share.Share(createShare.PostId, createShare.UserId);
            share.ShareId = await _shareRepository.AddShare(share);
            return share;
        }
         
        public async Task EditShare(EditShare createShare, int shareId)
        {
            var share = await _shareRepository.GetShare(shareId);
            share.EditShare(createShare.PostId, createShare.UserId);
            await _shareRepository.EditShare(share);
        }


    }
}

