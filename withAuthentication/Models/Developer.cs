using System;
using System.Collections.Generic;

#nullable disable

namespace withAuthentication.Models
{
    public partial class Developer
    {
        public Developer()
        {
            DeveloperReviews = new HashSet<DeveloperReview>();
            Projects = new HashSet<Project>();
        }

        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
        public decimal? AvgStarRating { get; set; }

        public virtual ICollection<DeveloperReview> DeveloperReviews { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
