using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class VenueDTO
    {
        public int VenueId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }
        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }
    }
}
