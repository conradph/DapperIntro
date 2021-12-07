using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperIntro.Models
{
    public class Dish
    {
        //This tells the c# that Id is our primary key in our SQL table
        //that helps c# with validation
        [Key]
        public int id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsHealthy { get; set; }
        [Range(1,10)]
        public int SpiceLevel { get; set; }
    }
}
