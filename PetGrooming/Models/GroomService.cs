using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class GroomService
    {
       //some properties that describe a groomservice
         public int GroomServiceID { get; set; }
        public string ServiceName { get; set; }
        
        public int ServiceCost { get; set; }//coats in cad
       
        public int ServiceDuration { get; set; }

      //many services to many bookings
        public ICollection<GroomBooking> GroomBookings { get; set; }
    }
}