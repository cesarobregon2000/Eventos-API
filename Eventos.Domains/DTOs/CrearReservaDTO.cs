using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class CrearReservaDTO
    {
        public int EVENTO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public int CANTIDAD { get; set; }
    }
}
