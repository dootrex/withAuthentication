using System;
using System.Collections.Generic;

#nullable disable

namespace withAuthentication.Models
{
    public partial class Language
    {
        public Language()
        {
            RealtorLanguages = new HashSet<RealtorLanguage>();
        }

        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<RealtorLanguage> RealtorLanguages { get; set; }
    }
}
