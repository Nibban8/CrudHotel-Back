using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudHotel.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int Hotel { get; set; }
        public string TipoHabitacion { get; set; }
        public int NumHabitacion { get; set; }
        public string Comentario { get; set; }
    }
}