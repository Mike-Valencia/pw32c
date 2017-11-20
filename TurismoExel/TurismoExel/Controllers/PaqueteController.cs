using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoExel.Models;
using TurismoExel.Servicios;

namespace TurismoExel.Controllers
{
    
    public class PaqueteController : Controller
    {
        // Negocio Paquete
        NegocioPaquete nPaquete = new NegocioPaquete();

        // Negocio Reserva
        NegocioReserva nReserva = new NegocioReserva();


        // Paquete/Detalle
        public ActionResult Detalle(int Id)
        {
            Paquete detalle = nPaquete.Mostrar(Id);
            return View(detalle);
        }

        [SessionUserFilter] // Aplicar filtro solo a esta acción
        [HttpPost]
        public ActionResult RealizarReserva(FormCollection form)
        {
            Usuario u = (Usuario)Session["SesionUsuario"];

            int IdPaquete = Int32.Parse(form["IdPaquete"]);
            int CantPersonas = Int32.Parse(form["CantPersonas"]);

            Paquete paqm = nPaquete.Mostrar(IdPaquete);

            if (paqm.LugaresDisponibles < CantPersonas)
            {
                TempData["ErrorLugar"] = "No hay tantos lugares disponibles ";
                return RedirectToAction("/Detalle/"+ IdPaquete);
            }

            //creamos la nueva reserva
            Reserva r = new Reserva();
            r.CantPersonas = CantPersonas;
            r.FechaCreacion = DateTime.Now;
            r.IdPaquete = IdPaquete;
            r.IdUsuario = u.Id;
            nReserva.Agregar(r);

            //restamos la cantidad de personas disponibles
            nPaquete.EditarPaqueteEnReserva(IdPaquete, CantPersonas);

            return RedirectToAction("../Usuario/Reservas");
        }
    }
}