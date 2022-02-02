using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarea3_Registro_Estudiantes.Entidades
{
    public class Carreras
    {
        [Key]
        public int CarreraID { get; set; }
        public string? Nombre { get; set; }
        
    }
}