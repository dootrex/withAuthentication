using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using withAuthentication.Models;

namespace withAuthentication.ViewModels
{
    public class DeveloperReviewVM
    {
        public int ReviewId { get; set; }
        public int? DeveloperId { get; set; }
        public int? PotentialBuyerId { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }

        public virtual PotentialBuyer PotentialBuyer { get; set; }
        public virtual Developer Developer { get; set; }
    }
}