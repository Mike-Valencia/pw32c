using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoExel.Models;
using TurismoExel.Servicios;
using TurismoExel.Utilities;
using PagedList;

namespace TurismoExel.Controllers
{
    [SessionAdminFilter] // Aplicar filtro a todo el controlador
    public class AdminController : Controller
    {
        // Negocio Paquete
        NegocioPaquete nPaquete = new NegocioPaquete();


        // GET: Admin/Index
        public ActionResult Index(int? page)
        {           
            int pageSize = 4;             // Cant. Registros
            int pageIndex = (page ?? 1); // Nro. Paginas

            List<Paquete> listaPaquetes = nPaquete.Listar();

            // PagedList (Descargar de NuGet "PageList". Agregar tambien en la vista)
            PagedList<Paquete> listaPag = new PagedList<Paquete>(listaPaquetes, pageIndex, pageSize);

            return View("Index", listaPag);
        }

        // GET: Admin/CrearPaquete
        public ActionResult CrearPaquete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearPaquete(Paquete p)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = (p.Nombre).ToString();
                //Guardar Imagen
                string pathRelativoImagen = HerramientasImagenes.Guardar(Request.Files[0], nombreSignificativo);
                p.Foto = pathRelativoImagen;
            }

            if (ModelState.IsValid)
            {
                nPaquete.Agregar(p);
                TempData["MensajeAdmin"] = String.Format("{0} {1} {2}", "Paquete ", p.Nombre, " se ha creado Correctamente!");
                return RedirectToAction("Index");
            }

            return View(p);

        }

        // GET: Admin/EditarPaquete
        public ActionResult EditarPaquete(int Id)
        {
            Paquete p = nPaquete.Mostrar(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult EditarPaquete(Paquete p, int id)
        {
            Paquete paqImg = nPaquete.Mostrar(id);

            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                if (!string.IsNullOrEmpty(p.Foto))
                {
                    //recordar eliminar la foto anterior si tenia
                    if (!string.IsNullOrEmpty(paqImg.Foto))
                    {
                        HerramientasImagenes.Borrar(p.Foto);
                    }

                    //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                    string nombreSignificativo = (p.Nombre).ToString(); ;
                    //Guardar Imagen
                    string pathRelativoImagen = HerramientasImagenes.Guardar(Request.Files[0], nombreSignificativo);
                    p.Foto = pathRelativoImagen;
                }
            }

            if (ModelState.IsValid)
            {
                nPaquete.Editar(p, id);
                TempData["MensajeAdmin"] = String.Format("{0} {1} {2}", "Paquete ", p.Nombre, " se ha Actualizado!");
                return RedirectToAction("Index");
            }
            return View(paqImg);

        }

        // GET: Admin/BorrarPaquete
        public ActionResult BorrarPaquete(int Id)
        {
            Paquete p = nPaquete.Mostrar(Id);
            return View(p);
        }

        [HttpPost, ActionName("BorrarPaquete")]
        public ActionResult BorrarPaqueteConfirmed(int Id)
        {
            Paquete p = nPaquete.Mostrar(Id);

            nPaquete.Eliminar(Id);
            TempData["MensajeAdmin"] = String.Format("{0}", "El Paquete ha sido borrado Correctamente!");

            return RedirectToAction("Index");
        }
    }
}