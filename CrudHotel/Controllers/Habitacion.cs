using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudHotel.Models;

namespace CrudHotel.Controllers
{
    [RoutePrefix("Api/Habitacion")]
    public class HabitacionController : ApiController
    {
        HotelDemoEntities DB = new HotelDemoEntities();
        [Route("AddOrUpdateHabitacion")]
        [HttpPost]
        public object AddOrUpdateHabitacion(Habitacion st)
        {
            try
            {
                if (st.Id == 0)
                {
                    Habitaciones sm = new Habitaciones();
                    sm.Hotel = st.Hotel;
                    sm.TipoHabitacion = st.TipoHabitacion;
                    sm.NumHabitacion = st.NumHabitacion;
                    sm.Comentario = st.Comentario;

                    DB.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = DB.Habitaciones.Where(x => x.IdHabitacion == st.Id).ToList().FirstOrDefault();
                    if (obj.IdHabitacion > 0)
                    {

                        obj.Hotel = st.Hotel;
                        obj.TipoHabitacion = st.TipoHabitacion;
                        obj.NumHabitacion = st.NumHabitacion;
                        obj.Comentario = st.Comentario;


                        DB.SaveChanges();
                        return new Response
                        {
                            Status = "Updated",
                            Message = "Updated Successfully"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new Response
            {
                Status = "Error",
                Message = "Data not insert"
            };

        }
        [Route("HabitacionDetails")]
        [HttpGet]
        public object HabitacionDetails()
        {

            var a = DB.Habitaciones.ToList();
            return a;
        }

        [Route("HabitacionDetailById")]
        [HttpGet]
        public object HabitacionDetailById(int id)
        {
            var obj = DB.Habitaciones.Where(x => x.IdHabitacion == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("DeleteHabitacion")]
        [HttpDelete]
        public object DeleteHabitacion(int id)
        {
            var obj = DB.Habitaciones.Where(x => x.IdHabitacion == id).ToList().FirstOrDefault();
            DB.Habitaciones.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }


}