using System.ComponentModel.DataAnnotations;

namespace Practica3.EF.MVC.Models
{
    public class EmployeesView
    {
        [Key]
        public int id { get; set; }
     
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(20)]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(20)]
        public string lastName { get; set; }

        [MaxLength(15, ErrorMessage ="No cumple con el formato requerido")]
        [MinLength(10, ErrorMessage = "No cumple con el formato requerido")]
        [Display(Name = "Telefono")]
        public string homePhone { get; set; }
    }
}