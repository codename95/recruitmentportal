using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class Document
    {
        [Key]
        public long DocumentID { get; set; }
        public string DocumentTypeID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string DateCreated { get; set; }
        public long AccountID { get; set; }
        public long ApplicationID { get; set; }
        public virtual DocumentType GetDocumentType { get; set; }
        public virtual Application Application { get; set; }
    }
}