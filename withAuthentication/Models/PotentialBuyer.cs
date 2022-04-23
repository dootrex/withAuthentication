using System;
using System.Collections.Generic;

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

        public virtual ICollection<DeveloperReview> DeveloperReviews { get; set; }
        public virtual ICollection<RealtorReview> RealtorReviews { get; set; }
    }
}
