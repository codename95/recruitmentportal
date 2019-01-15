using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}