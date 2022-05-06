using System;
using System.Collections.Generic;

#nullable disable

namespace withAuthentication.Models
{
    public partial class RealtorLanguage
    {
        public int RealtorLanguageId { get; set; }
        public int? RealtorId { get; set; }
        public int? LanguageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Realtor Realtor { get; set; }
    }
}
