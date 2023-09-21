using System.ComponentModel.DataAnnotations;

namespace Practica7.EF.WebApi.Models
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
        [Display(Name = "Telefono")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo debe contener números.")]
        public string homePhone { get; set; }
    }
}