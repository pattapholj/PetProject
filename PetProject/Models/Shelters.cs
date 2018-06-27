using System;
using System.Collections.Generic;

namespace PetProject.Models
{
    public partial class Shelters
    {
        public Shelters()
        {
            Pets = new HashSet<Pets>();
        }

        public int Id { get; set; }
        public string ShelterName { get; set; }
        public string ShelterAddress { get; set; }
        public string ShelterPhoneNumber { get; set; }
        public string ShelterCity { get; set; }
        public string ShelterZip { get; set; }
        public string ShelterEmail { get; set; }
        public double? ShelterLatitude { get; set; }
        public double? ShelterLongitude { get; set; }
        public string ShelterId { get; set; }

        public ICollection<Pets> Pets { get; set; }
    }
}
