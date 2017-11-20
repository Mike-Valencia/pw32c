using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using TurismoExel.Models;

namespace TurismoExel
{
    /// <summary>
    /// Descripción breve de ServicioWebTurismo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ServicioWebTurismo : System.Web.Services.WebService
    {

        // Base de Datos
        PW3_20172C_TP_TurismoEntities db = new PW3_20172C_TP_TurismoEntities();

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CancelarReserva(int ReservaId)
        {
            //Buscamos la reserva para eliminar
            Reserva reservaAEliminar = db.Reserva.Find(ReservaId);

            if (reservaAEliminar.Paquete.FechaInicio > System.DateTime.Now)
            {
                //Buscamos el paquete para sumarle los lugares disponibles
                Paquete paquete = db.Paquete.Where(p => p.Id == reservaAEliminar.IdPaquete).FirstOrDefault();

                //Se suman los lugares nuevamente al paquete
                paquete.LugaresDisponibles = paquete.LugaresDisponibles + reservaAEliminar.CantPersonas;

                //eliminamos la reserva
                db.Reserva.Remove(reservaAEliminar);
                db.SaveChanges();

                var msjOk = String.Format("{0} {1} {2}", "La reserva ", paquete.Nombre, " ha sido cancelada!");

                return new JavaScriptSerializer().Serialize(msjOk);
            }
            else
            {
                var msjError = "La fecha de reserva ha expirado";
                return new JavaScriptSerializer().Serialize(msjError);
            }
        }
    }
}
