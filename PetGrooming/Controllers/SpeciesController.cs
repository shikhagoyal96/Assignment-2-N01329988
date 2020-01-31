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
    public class SpeciesController : Controller
    {
        //connect to the database
        private PetGroomingContext db = new PetGroomingContext();
       
        public ActionResult Index()
        {
            return View();
        }

       //method to view a list of species from the database
        public ActionResult List()
        {

            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();

            return View(myspecies);
        }

       //method to show the details of a particular species
        public ActionResult Show(int id)
        {
            string query = "select * from Species where SpeciesId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Species selectedspecies = db.Species.SqlQuery(query, param).FirstOrDefault();
           
            return View(selectedspecies);
        }
       //adding a new species
        public ActionResult Add()
        {
            List<Species> species = db.Species.SqlQuery("select * from Species").ToList();

            return View(species);
        }
       //Add via [HttpPost]
        [HttpPost]
        public ActionResult Add(string SpeciesName)
        {

            string query = "insert into Species (Name) values (@SpeciesName)";
            SqlParameter[] sqlparams = new SqlParameter[1];

            sqlparams[0] = new SqlParameter("@SpeciesName", SpeciesName);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }
        //update method to change the detials of a specie
        public ActionResult Update(int id)
        {

          
            string query = "select * from species where SpeciesId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Species selectedspecies = db.Species.SqlQuery(query, param).FirstOrDefault();

            return View(selectedspecies);
        }
        //Update via [HttpPost]
        [HttpPost]
        public ActionResult Update(int id, string SpeciesName)
        {
            string query = "update species set Name=@SpeciesName where SpeciesId=@id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0]=new SqlParameter("@SpeciesName", SpeciesName);
            sqlparams[1]=new SqlParameter("@id",id);
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }
        //delete method to remove a specie from the database
        public ActionResult Delete(int id)
        {
            string query = "delete from species where SpeciesId=@id";
            SqlParameter sqlparam = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparam);
            return RedirectToAction("List");
        }
       
    }
}