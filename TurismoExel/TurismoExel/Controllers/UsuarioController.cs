using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoExel.Models;
using TurismoExel.Servicios;
using PagedList;
using TurismoExel.ServiceReferences;

namespace TurismoExel.Controllers
{
    [SessionUserFilter] // Aplicar filtro a todo el controlador
    public class UsuarioController : Controller
    {
        // Negocio Paquete
        NegocioPaquete nPaquete = new NegocioPaquete();

        // Negocio Reserva
        NegocioReserva nReserva = new NegocioReserva();


        // Usuario/Reservas
        public ActionResult Reservas(int? page)
        {
            Usuario u = (Usuario)Session["SesionUsuario"];
            List<Reserva> listaReservas = nReserva.ListarReservasPorUsuario(u.Id);

            int pageSize = 4;             // Cant. Registros
            int pageIndex = (page ?? 1); // Nro. Paginas

            // PagedList (Descargar de NuGet "PageList". Agregar tambien en la vista)
            PagedList<Reserva> listaPag = new PagedList<Reserva>(listaReservas, pageIndex, pageSize);

            return View(listaPag);
        }

        // Usuario/BorrarReserva
        public ActionResult BorrarReserva(int id)
        {
            //ServicioWebTurismoSoapClient nServices = new ServicioWebTurismoSoapClient();
            //TempData["MensajeServicio"] = nServices.CancelarReserva(id);

            return RedirectToAction("Reservas");
        }
    }
}