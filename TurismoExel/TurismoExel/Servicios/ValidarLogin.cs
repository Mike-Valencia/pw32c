using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurismoExel.Models;

namespace TurismoExel.Servicios
{
    public class ValidarLogin
    {
        // Base de Datos
        PW3_20172C_TP_TurismoEntities db = new PW3_20172C_TP_TurismoEntities();

        // Validar Login
        public Usuario Validar(Usuario u)
        {
            var emailUser = u.Email;
            var passUser = u.Contrasenia;

            Usuario us = db.Usuario.Where(m => m.Email == emailUser && m.Contrasenia == passUser).FirstOrDefault();
            return (us);
        }
    }
}