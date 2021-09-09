using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC2.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [StringLength(25)]
        [Display(Name ="Breed")]
        public string Type { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
