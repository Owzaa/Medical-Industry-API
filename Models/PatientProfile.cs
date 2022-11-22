using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.BuilderProperties;


namespace Medical_Industry_API.Models
{
    public class PatientProfile
    {
        public PatientProfile()
        {
            Requisitions = new List<Requisition>();
        }

        public Patient? Patient { get; set; }
        public List<Requisition>? Requisitions { get; set; }
    }

    public class Patient
    {

        public Guid? PatientId { get; set; }
        public string? AvatarPhoto { get; set; }
        public string? PatientName { get; set; }
        public string? PatientIdentityNumber { get; set; }
        public Address? PatientAddress { get; set; }
    }


    public class Requisition
    {
        public Requisition()
        {
            Tests = new List<Test>();
        }

        public Guid? RequisitionId { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string? ReferringPhysician { get; set; }
        public List<Test>? Tests { get; set; }
    }

    public class Test
    {
        public Guid? TestId { get; set; }
        public string? TestName { get; set; }
        public string? Comment { get; set; }
        public int? NormalRange { get; set; } // A normal value
        public int? TestResult { get; set; } // A value for the specific test
        //performed
    }
}
