//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChronoHealHealthCare1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Career_Registration
    {
        public int CRId { get; set; }
        public string CRName { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public Nullable<int> MartialStatus { get; set; }
        public string Aadhar { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Addrss { get; set; }
        public string City { get; set; }
        public Nullable<int> State1 { get; set; }
        public string DoctorRegistration { get; set; }
        public string Qualification { get; set; }
        public string EducationBoard { get; set; }
        public string Specialization { get; set; }
        public int ExperienceInYears { get; set; }
        public string CRId1 { get; set; }
    
        public virtual Gender Gender1 { get; set; }
        public virtual Marital Marital { get; set; }
        public virtual State State { get; set; }
    }
}
