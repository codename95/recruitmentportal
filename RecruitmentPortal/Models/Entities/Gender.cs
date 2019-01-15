using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class Gender
    {
        [Key]
        public byte GenderID { get; set; }
        public string GenderName { get; set; }
    }
}