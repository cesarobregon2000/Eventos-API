using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class ListarEventosDTO
    {
        public int EventoID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioEntrada { get; set; }
        public string Estado { get; set; }
        public string Venue { get; set; }
        public int Capacidad { get; set; }
        public string CiudadNombre { get; set; }
        public string TipoEvento { get; set; }
    }
}
