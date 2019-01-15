using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class Application
    {
        [Key]
        public long ApplicationID { get; set; }
        public long AccountID { get; set; }
        public long JobID { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime? DateLastModified { get; set; }

        public virtual Job Job { get; set; }
        public virtual Account Account { get; set; }
    }
}