using System;
using System.Collections.Generic;
using System.Text;
using aventuras.domain.DomainExceptions;

namespace aventuras.domain.Share
{
    public class Share
    {
        public int ShareId { get; set; }
        public int PostId { get; private set; }
        public int UserId { get; private set; }


        public Share(int shareId, int postId, int userId)
        {
            ShareId = shareId;
            PostId = postId;
            UserId = userId;
        }

        public Share(int postId, int userId)
        {
            PostId = postId;
            UserId = userId;
        }

        public void EditShare(int postId, int userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
}
