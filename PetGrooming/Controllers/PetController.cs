using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;

using System.Diagnostics;

//reference taken from in-class example done by chritine bittle during lectures 

namespace PetGrooming.Controllers
{
    public class PetController : Controller
    {
       //accessing the database of the pet table
        private PetGroomingContext db = new PetGroomingContext();

       //displaying the list of pets
        public ActionResult List()
        {
           
            List<Pet> pets = db.Pets.SqlQuery("Select * from Pets").ToList();
            return View(pets);
           
        }

       //displaying the details of a particular pet on the basis of the petid
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Pet pet = db.Pets.SqlQuery("select * from pets where petid=@PetID", new SqlParameter("@PetID",id)).FirstOrDefault();
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        //Adding a new pet via [HttpPost]
        [HttpPost]
        public ActionResult Add(string PetName, Double PetWeight, String PetColor, int SpeciesID, string PetNotes)
        {
            string query = "insert into pets (PetName, Weight, color, SpeciesID, Notes) values (@PetName,@PetWeight,@PetColor,@SpeciesID,@PetNotes)";
            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@PetName",PetName);
            sqlparams[1] = new SqlParameter("@PetWeight", PetWeight);
            sqlparams[2] = new SqlParameter("@PetColor", PetColor);
            sqlparams[3] = new SqlParameter("@SpeciesID", SpeciesID);
            sqlparams[4] = new SqlParameter("@PetNotes",PetNotes);

            db.Database.ExecuteSqlCommand(query, sqlparams);
 
             return RedirectToAction("List");//after adding a new pet return to the list page
        }

        //Add a new pet
        public ActionResult New()
        {
            List<Species> species = db.Species.SqlQuery("select * from Species").ToList();

            return View(species);
        }


        //updating the details of the pet based on the petid
        public ActionResult Update(int id)
        {
            
            Pet selectedpet = db.Pets.SqlQuery("select * from pets where petid = @id", new SqlParameter("@id",id)).FirstOrDefault();
             return View(selectedpet);
        }
        //update [HttpPost]
        [HttpPost]
        public ActionResult Update(int id, string PetName, string PetColor, double PetWeight, string PetNotes)
        {

            Debug.WriteLine("I am trying to edit a pet's name to "+PetName+" and change the weight to "+PetWeight.ToString());
            string query = "update pets set PetName=@PetName, Weight=@PetWeight, color=@PetColor , Notes=@PetNotes where PetId=@id";

            SqlParameter[] parameters = new SqlParameter[5];
           
            parameters[0] = new SqlParameter("@PetName",PetName);
            parameters[1] = new SqlParameter("@PetWeight", PetWeight);
            parameters[2] = new SqlParameter("@PetColor", PetColor);
            parameters[3] = new SqlParameter("@PetNotes", PetNotes);
            parameters[4] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, parameters);
            
            return RedirectToAction("List");
        }
        //deleting a particular pet details
        public ActionResult Delete(int id)
        {
            string query = "delete from pets where petid=@id";
            SqlParameter sqlparam = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparam);
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
