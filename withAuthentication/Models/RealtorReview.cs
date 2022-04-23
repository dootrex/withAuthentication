using System;
using System.Collections.Generic;

#nullable disable

namespace withAuthentication.Models
{
    public partial class RealtorReview
    {
        public int ReviewId { get; set; }
        public int? RealtorId { get; set; }
        public int? PotentialBuyerId { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }

        public virtual PotentialBuyer PotentialBuyer { get; set; }
        public virtual Realtor Realtor { get; set; }
    }
}
