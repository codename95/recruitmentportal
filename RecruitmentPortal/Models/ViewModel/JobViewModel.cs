using RecruitmentPortal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.ViewModel
{
    public class JobViewModel
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime ExpiryDate { get; set; }
        public byte JobCategoryID { get; set; }
        public IEnumerable<JobCategory> JobCategories { get; set; }
    }
}