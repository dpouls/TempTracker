using Microsoft.AspNetCore.Mvc;
using System;
//We need to include the dataannotations
using System.ComponentModel.DataAnnotations;

namespace TempManager.Models
{
    public class Temp
    {
       
        public int Id { get; set; }
        //makes this field required (not empty)
        [Required(ErrorMessage = "Please enter a date.")]
        //uses a method in the validationcontroller to check if the date is in datetime format and not in the db
        [Remote("CheckDate","Validation")]
        public DateTime? Date { get; set; }
        //makes this field required (not empty)
        [Required(ErrorMessage = "Please enter a low temperature.")]
        //specifies a range from -200 to 200 for the temperatures and requires that the user input is between those values
        [Range(-200,200,ErrorMessage = "Low Temperature must be between -200 and 200")]
        public double? Low { get; set; }
        //makes this field required (not empty)
        [Required(ErrorMessage = "Please enter a high temperature.")]
        //specifies a range from -200 to 200 for the temperatures and requires that the user input is between those values
        [Range(-200, 200, ErrorMessage = "High Temperature must be between -200 and 200")]
        public double? High { get; set; }
    }
}
