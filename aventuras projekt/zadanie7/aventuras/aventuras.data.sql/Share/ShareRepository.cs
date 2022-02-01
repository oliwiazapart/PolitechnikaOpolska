using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.idata.Share;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;



namespace aventuras.data.sql.Share
{
    public class ShareRepository : IShareRepository
    {
        private readonly AventurasDbContext _context;

        public ShareRepository(AventurasDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddShare(domain.Share.Share share)
        {
            var shareDAO = new DAO.Share
            {
                PostId = share.PostId,
                UserId = share.UserId
            };

            await _context.AddAsync(shareDAO);
            await _context.SaveChangesAsync();
            return shareDAO.ShareId;
        }

        public async Task<domain.Share.Share> GetShare(int shareId)
        {
            var share = await _context.Share.FirstOrDefaultAsync(x => x.ShareId == shareId);
            return new domain.Share.Share(share.ShareId,
                share.PostId,
                share.UserId
                );

        }

        public async Task EditShare(domain.Share.Share share)
        {
            var editShare = await _context.Share.FirstOrDefaultAsync(x => x.ShareId == share.ShareId);
            editShare.PostId = share.PostId;
            editShare.UserId = share.UserId;
            await _context.SaveChangesAsync();
        }

    
    }
}
