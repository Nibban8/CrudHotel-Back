using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudHotel.Models;

namespace CrudHotel.Controllers
{
    [RoutePrefix("Api/Tarifa")]
    public class TarifaController : ApiController
    {
        HotelDemoEntities DB = new HotelDemoEntities();
        [Route("AddOrUpdateTarifa")]
        [HttpPost]
        public object AddOrUpdateTarifa(Tarifa st)
        {
            try
            {
                if (st.Id == 0)
                {
                    Tarifas sm = new Tarifas();
                    sm.Hotel = st.Hotel;
                    sm.FechaInicio = st.FehaInicio;
                    sm.FechaFin = st.FechaFin;
                    sm.Precio = st.Precio;

                    DB.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Successfully"
                    };
                }
                else
                {
                    var obj = DB.Tarifas.Where(x => x.IdTarifa == st.Id).ToList().FirstOrDefault();
                    if (obj.IdTarifa > 0)
                    {

                        obj.Hotel = st.Hotel;
                        obj.FechaInicio = st.FehaInicio;
                        obj.FechaFin = st.FechaFin;
                        obj.Precio = st.Precio;


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
        [Route("TarifaDetails")]
        [HttpGet]
        public object TarifaDetails()
        {

            var a = DB.Tarifas.ToList();
            return a;
        }

        [Route("TarifaDetailById")]
        [HttpGet]
        public object TarifaDetailById(int id)
        {
            var obj = DB.Tarifas.Where(x => x.IdTarifa == id).ToList().FirstOrDefault();
            return obj;
        }
        [Route("DeleteTarifa")]
        [HttpDelete]
        public object DeleteTarifa(int id)
        {
            var obj = DB.Tarifas.Where(x => x.IdTarifa == id).ToList().FirstOrDefault();
            DB.Tarifas.Remove(obj);
            DB.SaveChanges();
            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }


}