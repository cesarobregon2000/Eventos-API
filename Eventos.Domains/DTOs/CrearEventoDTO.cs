using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class CrearEventoDTO
    {
        public string TITULO { get; set; }
        public string DESCRIPCION { get; set; }
        public int VENUE { get; set; }
        public int CAPACIDAD_MAXIMA { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public int PRECIO_ENTRADA { get; set; }

        public int TIPO_EVENTO_ID { get; set; }
    }
}
