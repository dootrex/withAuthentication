using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual PotentialBuyer PotentialBuyer { get; set; }
        [JsonIgnore]
        public virtual Realtor Realtor { get; set; }
    }
}
