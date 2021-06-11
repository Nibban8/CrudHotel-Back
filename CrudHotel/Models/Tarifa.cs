using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudHotel.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public int Hotel { get; set; }
        public DateTime FehaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public float Precio { get; set; }
    }
}