using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aventuras.ViewModels
{
    public class RatingViewModel
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int NumericRating { get; set; }
        public bool UsefulStatus { get; set; }

    }
}
