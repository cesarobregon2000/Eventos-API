using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class TipoEventoDTO
    {
        public int TipoEvenId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}
