using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea3_Registro_Estudiantes.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudiantesID { get; set; }
        public string? Nombres { get; set; }
        public string? Email { get; set; }
        public int CarreraID { get; set; }
        public bool Activo { get; set; }

    }
}