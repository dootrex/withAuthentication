using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace withAuthentication.Models
{
    public partial class Realtor
    {
        public Realtor()
        {
            RealtorLanguages = new HashSet<RealtorLanguage>();
            RealtorReviews = new HashSet<RealtorReview>();
        }

        public int RealtorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePic { get; set; }
        public string BioText { get; set; }
        public decimal? AvgStarRating { get; set; }
        public string Website { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public DateTime? SubscriptionExpiration { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtorLanguage> RealtorLanguages { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtorReview> RealtorReviews { get; set; }
    }
}
