using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperIntro.Models;
using Dapper;

namespace DapperIntro.Controllers
{
    //To make a controller subclass controller
    //.Net expects your controller name to have the word controller at the end
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            List<Dish> dishes = new List<Dish>();
            using(var connect = new MySqlConnection(Secret.connection))
            {
                //So using dapper, we are able to put sql queries into a string 
                //and pass them along to our database
                //all MySql syntax is useable here
                string sql = "select * from dishes";

                //open our connection to the database
                connect.Open();
                //Expecting to return a single model or a list of models, or nothing
                dishes = connect.Query<Dish>(sql).ToList();

                //close our connection to a db, if we don't, then the database may not let another method use it
                connect.Close();
            }

            return View(dishes[0]);
        }
    }
}
