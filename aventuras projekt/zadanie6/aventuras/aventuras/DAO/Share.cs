using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAO
{
    public class Share
    {
        public int ShareId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }

    }
}
