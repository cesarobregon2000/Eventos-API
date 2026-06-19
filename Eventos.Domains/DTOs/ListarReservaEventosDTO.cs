using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class ListarReservaEventosDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaReserva { get; set; }
        public int reservaId { get; set; }
    }
}
