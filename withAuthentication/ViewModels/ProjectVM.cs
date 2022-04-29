using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace withAuthentication.ViewModels
{
    public class ProjectVM
    {
        public int ProjectId { get; set; }
        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectImage { get; set; }

    }
}
