using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurismoExel.Models;

namespace TurismoExel.Servicios
{
    public class NegocioPaquete
    {
        // Base de Datos
        PW3_20172C_TP_TurismoEntities db = new PW3_20172C_TP_TurismoEntities();

        // Agregar Paquete
        public void Agregar(Paquete p)
        {
            db.Paquete.Add(p);
            db.SaveChanges();
        }

        // Editar Paquete
        public void Editar(Paquete paq, int Id)
        {
            Paquete p = db.Paquete.Find(Id);
            p.Nombre = paq.Nombre;
            if (paq.Foto != null)
            {
                p.Foto = paq.Foto;
            }
            p.Descripcion = paq.Descripcion;
            p.FechaInicio = paq.FechaInicio;
            p.FechaFin = paq.FechaFin;
            p.LugaresDisponibles = paq.LugaresDisponibles;
            p.PrecioPorPersona = paq.PrecioPorPersona;
            p.Destacado = paq.Destacado;
            db.SaveChanges();
        }

        //Eliminar Paquete
        public void Eliminar(int Id)
        {
            Paquete paq = db.Paquete.Find(Id);

            var listaReserva = db.Reserva.Where(r => r.IdPaquete == paq.Id);

            foreach (Reserva res in listaReserva)
            {
                db.Reserva.Remove(res);
            }

            db.Paquete.Remove(paq);
            db.SaveChanges();
        }

        // Mostrar Paquete
        public Paquete Mostrar(int Id)
        {
            Paquete paquete = db.Paquete.Where(p => p.Id == Id).FirstOrDefault();
            return paquete;
        }

        // Listar Paquete
        public List<Paquete> Listar()
        {
            List<Paquete> listaPaquetes = db.Paquete.OrderByDescending(p => p.FechaInicio).ToList();
            return listaPaquetes;
        }

        // Listar Paquete Destacado
        public List<Paquete> ListarDestacados()
        {
            List<Paquete> paqDestacados = db.Paquete.Where(p => p.Destacado == true && p.FechaInicio >= DateTime.Today).OrderBy(p => p.FechaInicio).ToList();
            return paqDestacados;
        }

        // Editar Paquete En Base A La Reserva
        public void EditarPaqueteEnReserva(int IdPaquete, int CantPersonas)
        {
            Paquete paquete = db.Paquete.Where(p => p.Id == IdPaquete).First();
            paquete.LugaresDisponibles = paquete.LugaresDisponibles - CantPersonas;
            db.SaveChanges();
        }
    }
}