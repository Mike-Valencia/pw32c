//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurismoExel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        public int Id { get; set; }
        public int CantPersonas { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdPaquete { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Paquete Paquete { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}