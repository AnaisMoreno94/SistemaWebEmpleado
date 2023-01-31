using Microsoft.AspNetCore.Http.Features;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Validators
{
    public class CheckValidYearAtributte : ValidationAttribute
    {
        public CheckValidYearAtributte() 
        {
            ErrorMessage = "El año de nacimiento debe ser mayor a 2000";
        }
        public override bool IsValid(object value)
        {
            DateTime fechaNacimiento = (DateTime)value;
            int year = fechaNacimiento.Year;

            if (year < 2000) return false; else return true;

        }
    }
}
