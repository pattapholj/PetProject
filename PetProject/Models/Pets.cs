using System;
using System.Collections.Generic;

namespace PetProject.Models
{
    public partial class Pets
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetBreed1 { get; set; }
        public string PetBreed2 { get; set; }
        public string PetGender { get; set; }
        public string PetDescription { get; set; }
        public string PetDetails { get; set; }
        public string PetLastUpdated { get; set; }
        public string PetPhotosLink { get; set; }
        public string ShelterId { get; set; }
        public string PetId { get; set; }
        public string PetType { get; set; }

        public Shelters Shelter { get; set; }
    }
}
