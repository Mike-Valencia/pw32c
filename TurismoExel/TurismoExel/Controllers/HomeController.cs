using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoExel.Models;
using TurismoExel.Servicios;

namespace TurismoExel.Controllers
{
    public class HomeController : Controller
    {
        // Base de Datos
        PW3_20172C_TP_TurismoEntities db = new PW3_20172C_TP_TurismoEntities();

        // Negocio Paquete
        NegocioPaquete nPaquete = new NegocioPaquete();

        // Validacion Login
        ValidarLogin VaLogin = new ValidarLogin();


        // GET: Home/Inicio
        public ActionResult Inicio()
        {
            List<Paquete> paqDestacados = nPaquete.ListarDestacados();
            return View(paqDestacados);
        }

        // GET: Home/Index
        [SessionUserFilter] // Aplicar filtro solo a esta acción
        public ActionResult Index()
        {
                List<Paquete> paqDestacados = nPaquete.ListarDestacados();
                return View(paqDestacados);

        }

        // GET: Home/Login
        public ActionResult Login()
        {
            TempData["urlAnterior"] = System.Web.HttpContext.Current.Request.UrlReferrer;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario us)
        {
            var resultado = VaLogin.Validar(us);

            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (resultado == null)
            {
                TempData["Validacion"] = "Introduce un nombre de usuario y contraseña válido";
                return View();
            }
            else
            {
                if (resultado.Admin == true)
                {
                    Session["SesionAdmin"] = resultado;
                    return RedirectToAction("../Admin/Index");
                }
                else
                {
                    Session["SesionUsuario"] = resultado;
                    Uri urlAnteriorCompleta = (Uri)TempData["urlAnterior"];
                    string urlAnteriorV = urlAnteriorCompleta.Segments[0]+ urlAnteriorCompleta.Segments[1]+urlAnteriorCompleta.Segments[2];
                    
                    if (urlAnteriorV == "/Paquete/Detalle/")
                    {
                        string urlParametro = urlAnteriorCompleta.Segments[3];
                        return RedirectToAction(".."+urlAnteriorV + urlParametro);
                    }

                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Inicio");
        }
    }
}