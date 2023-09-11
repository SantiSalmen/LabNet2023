using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica3.EF.MVC.Models
{
    public class EmployeesView
    {
        [Key]
        public int id { get; set; }
     
        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Required]
        [StringLength(20)]
        public string lastName { get; set; }
    }
}