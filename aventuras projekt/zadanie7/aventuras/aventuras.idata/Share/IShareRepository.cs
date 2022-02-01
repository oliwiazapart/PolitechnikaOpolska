using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aventuras.idata.Share
{
    public interface IShareRepository
    {
        Task<int> AddShare(aventuras.domain.Share.Share share);
        Task<aventuras.domain.Share.Share> GetShare(int shareId);
        Task EditShare(domain.Share.Share share);

    }
}
