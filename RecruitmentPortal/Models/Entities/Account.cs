using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Models.Entities
{
    public class Account
    {
        [Key]
        public long AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public short StateID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public byte GenderID { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActiveAccount { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual State State { get; set; }
    }
}