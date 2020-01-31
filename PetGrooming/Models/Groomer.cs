using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class Groomer
    {
        //properties that describe a groomer
        [Key]
        public int GroomerID { get; set; }
        public string GroomerFName { get; set; }
        public string GroomerLName { get; set; }
        public DateTime GroomerDOB { get; set; }

       
        public int GroomerRate { get; set; }//rate in cents per hour
       

        //one booking to many groomers
        public ICollection<GroomBooking> GroomBookings { get; set; }
    }
}