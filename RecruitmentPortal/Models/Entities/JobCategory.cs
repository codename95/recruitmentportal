using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class JobCategory
    {
        [Key]
        public  short JobCategoryID { get; set; }
        public string JobCategoryName { get; set; }
    }
}