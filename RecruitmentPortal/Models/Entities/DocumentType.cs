using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }
        public string DocumentTypeName { get; set; }
    }
}