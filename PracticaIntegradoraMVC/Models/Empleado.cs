using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using SistemaWebEmpleado.Validators;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Apellido { get; set; }

        //TODO: AgregarRequired
        public int DNI { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("[A-Z]{1}[0-9]{5}", ErrorMessage = "Legajo Invalido")]
        public string Legajo { get; set; }
        
        [CheckValidYearAtributte]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Titulo { get; set; }

    }
}
