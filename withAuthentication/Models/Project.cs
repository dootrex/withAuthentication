﻿using System;
using System.Collections.Generic;

#nullable disable

namespace withAuthentication.Models
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public int? DeveloperId { get; set; }
        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectImage { get; set; }

        public virtual Developer Developer { get; set; }
    }
}