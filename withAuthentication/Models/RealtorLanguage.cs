using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace withAuthentication.Models
{
    public partial class RealtorLanguage
    {
        public int RealtorLanguageId { get; set; }
        public int? RealtorId { get; set; }
        public int? LanguageId { get; set; }
        [JsonIgnore]
        public virtual Language Language { get; set; }
        [JsonIgnore]
        public virtual Realtor Realtor { get; set; }
    }
}
