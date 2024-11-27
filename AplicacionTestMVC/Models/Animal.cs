using System.ComponentModel.DataAnnotations;

namespace AplicacionTestMVC.Models
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }

        [Required(ErrorMessage = "El nombre del animal es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del animal no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre del animal")]
        public string NombreAnimal { get; set; }

        [StringLength(50, ErrorMessage = "La raza del animal no puede tener más de 50 caracteres")]
        [Display(Name = "Raza")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de animal")]
        [Display(Name = "Tipo animal")]
        public int RIdTipoAnimal { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una fecha valida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FechaNacimiento { get; set; }

        //Navegacion entre TipoAnimal
        public TipoAnimal TipoDeAnimal { get; set; } = new TipoAnimal();
    }
}
