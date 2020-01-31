using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetGrooming.Models
{
    public class Pet
    {
       //Properties of pet
        [Key]
        public int PetID { get; set; }
        public string PetName { get; set; }
       
        public double Weight { get; set; }//in kg
        public string Color { get; set; }
        public string Notes { get; set; }



        //One species to many pets      
        public int SpeciesID { get; set; }
        [ForeignKey("SpeciesID")]
        public virtual Species Species { get; set; }

        //one booking to many pets
        public ICollection<GroomBooking> GroomBookings { get; set; }
        
        //many owner to many pets
        public ICollection<Owner> Owners { get; set; }
    }
}