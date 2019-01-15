using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class Job
    {
        [Key]
        public long JobID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime ExpiryDate { get; set; }
        public byte JobCategoryID { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public int Views { get; set; }

        public virtual JobCategory JobCategory { get; set; }
    }
}