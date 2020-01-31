using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class Owner
    {
        //some properties that describe an owner
        public int OwnerID { get; set; }
        public string OwnerFname { get; set; }
        public string OwnerLname { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerWorkPhone { get; set; }
        public string OwnerHomePhone { get; set; }


        //one booking to many owners
        public ICollection<GroomBooking> GroomBookings { get; set; }

        //many owners to many pets
        public ICollection<Pet> Pets { get; set; }

    }
}