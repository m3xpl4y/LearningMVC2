using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVC2.Models
{
    public class Person
    {
        
        public int Id { get; set; }
        public int AdressId { get; set; }
        public int PetId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Adress Adress { get; set; }
        
        public Pet Pet { get; set; }
    }
}
