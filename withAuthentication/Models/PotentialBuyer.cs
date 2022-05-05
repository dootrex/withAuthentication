using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace withAuthentication.Models
{
    public partial class PotentialBuyer
    {
        public PotentialBuyer()
        {
            DeveloperReviews = new HashSet<DeveloperReview>();
            RealtorReviews = new HashSet<RealtorReview>();
        }

        public int PotentialBuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        [JsonIgnore]
        public virtual ICollection<DeveloperReview> DeveloperReviews { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtorReview> RealtorReviews { get; set; }
    }
}
