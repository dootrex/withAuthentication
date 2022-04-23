using System;
using System.Collections.Generic;

#nullable disable

namespace withAuthentication.Models
{
    public partial class DeveloperReview
    {
        public int ReviewId { get; set; }
        public int? DeveloperId { get; set; }
        public int? PotentialBuyerId { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual PotentialBuyer PotentialBuyer { get; set; }
    }
}
