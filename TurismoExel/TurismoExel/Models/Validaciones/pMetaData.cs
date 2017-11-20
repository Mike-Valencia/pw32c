using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurismoExel.Models.Validaciones
{
    public class pMetaData
    {
        [StringLength(100), Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [StringLength(250), Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get; set; }

        //[Required(ErrorMessage = "La foto es obligatoria")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        public System.DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha fin es obligatoria")]
        public System.DateTime FechaFin { get; set; }

        [Range(0, 5000, ErrorMessage = "Cantidad incorrecto") Required(ErrorMessage = "La cantidad es obligatorio")]
        public Nullable<int> LugaresDisponibles { get; set; }

        [Range(1, 20000, ErrorMessage = "Precio incorrecto") Required(ErrorMessage = "El precio es obligatorio")]
        public int PrecioPorPersona { get; set; }
    }
}