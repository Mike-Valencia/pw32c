using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurismoExel.Models.Validaciones
{
    public class uMetaData
    {
        public int Id { get; set; }

        [StringLength(200), Required(ErrorMessage = "El Correo Electrónico es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email incorrecto")]
        public string Email { get; set; }

        [StringLength(50), Required(ErrorMessage = "La Contraseña es obligatorio")]
        public string Contrasenia { get; set; }
        public bool Admin { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}