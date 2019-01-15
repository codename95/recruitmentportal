using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}