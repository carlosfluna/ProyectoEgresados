using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CasoEstudioEgrasados.Models
{
    public class Usuario
    {
        public int Usu_id { get; set; }

        [Required(ErrorMessage = "El documento es obligatorio")]
        public long Usu_documento { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public string Usu_tipodoc { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Usu_nombre { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public int Usu_celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Usu_email { get; set; }

        [Required(ErrorMessage = "El genero es obligatorio")]
        public string Usu_genero { get; set; }

        public bool Usu_aprendiz { get; set; }

        public bool Usu_egresado { get; set; }

        public string Usu_areaformacion { get; set; }

        public string Usu_fechaegresado { get; set; }

        [Required(ErrorMessage = "La direccion es obligatorio")]
        public string Usu_direccion { get; set; }

        [Required(ErrorMessage = "El barrio es obligatorio")]
        public string Usu_barrio { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatorio")]
        public string Usu_ciudad { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Usu_departamento { get; set; }

        public DateTime Usu_fecharegistro { get; set; }
    }
}