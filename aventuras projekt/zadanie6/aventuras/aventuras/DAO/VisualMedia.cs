using aventuras.common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAO
{
    public class VisualMedia
    {
        public int VisualMediaId { get; set; }
        public int PostId { get; set; }
        public MediaType VMediaType { get; set; }
        public string VMediaHref { get; set; }


        public virtual Post Post { get; set; }
    }
}
