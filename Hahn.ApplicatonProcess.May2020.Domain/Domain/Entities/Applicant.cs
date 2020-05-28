using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Entities
{
    public class Applicant
    {
        public Applicant()
        {
            Hired = false;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; } 
        public bool Hired { get; set; }
    }
}
