using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurismoExel.Models;

namespace TurismoExel.Servicios
{
    public class NegocioReserva
    {
        // Base de Datos
        PW3_20172C_TP_TurismoEntities db = new PW3_20172C_TP_TurismoEntities();

        //Agregar Reserva
        public void Agregar(Reserva r)
        {
            db.Reserva.Add(r);
            db.SaveChanges();
        }

        //Listar Reserva de Usuario
        public List<Reserva> ListarReservasPorUsuario(int IdUsuario)
        {
            List<Reserva> listaReservas = db.Reserva.Where(p => p.IdUsuario == IdUsuario).OrderBy(p => p.Paquete.FechaInicio).ToList();
            return listaReservas;
        }

        //Cancelar Reserva de Usuario y Devolver los lugares reservados al Paquete
        public void CancelarReserva(int id)
        {
            //Buscamos la reserva para eliminar
            Reserva reservaAEliminar = db.Reserva.Find(id);

            //Buscamos el paquete para sumarle los lugares disponibles
            Paquete paquete = db.Paquete.Where(p => p.Id == reservaAEliminar.IdPaquete).FirstOrDefault();

            //Se suman los lugares nuevamente al paquete
            paquete.LugaresDisponibles = paquete.LugaresDisponibles + reservaAEliminar.CantPersonas;

            //eliminamos la reserva
            db.Reserva.Remove(reservaAEliminar);

            db.SaveChanges();
        }
    }
}