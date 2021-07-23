using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempManager.Models;

namespace TempManager.Controllers
{
    public class ValidationController : Controller
    {
        //get the database context from the TempManagerContext model
        private TempManagerContext data { get; set; }
        //assign the context to the data variable
        public ValidationController(TempManagerContext ctx) => data = ctx;
        /// <summary>
        ///validate it is in date time format and then see if it is in the database. 
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Return results</returns>
        public JsonResult CheckDate(string date)
        {
            //parse text to see if it is datetime
            DateTime dt = DateTime.Parse(date);
            //check to see if it is already in the db
            Temp temp = data.Temps.FirstOrDefault(t => t.Date == dt);
            //if its null, return a json object stating true
            if (temp == null)
            {
                return Json(true);
            }
            else
            {
                //else return a string saying the entered date is in the db
                return Json($"The date {date} is already in the database.");

            }
        }
    }
}
