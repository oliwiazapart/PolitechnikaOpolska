using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using aventuras.iservices.Requests;


namespace aventuras.iservices.Share
{
    public interface IShareService
    {
        Task<aventuras.domain.Share.Share> GetShareByShareId(int shareId);
        Task<aventuras.domain.Share.Share> CreateShare(CreateShare createShare);
        Task EditShare(EditShare createShare, int shareId);

    }
}
