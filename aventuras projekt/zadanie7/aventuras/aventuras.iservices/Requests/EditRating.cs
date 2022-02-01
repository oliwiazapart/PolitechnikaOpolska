using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.iservices.Requests
{
    public class EditRating
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int NumericRating { get; set; }
        public bool UsefulStatus { get; set; }
    }
}
