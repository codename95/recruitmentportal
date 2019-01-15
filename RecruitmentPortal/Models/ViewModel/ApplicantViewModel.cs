using RecruitmentPortal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.ViewModel
{
    public class ApplicantViewModel
    {
        public Account Account { get; set; }
        public IEnumerable<Application> UserApplications { get; set; }
    }
}