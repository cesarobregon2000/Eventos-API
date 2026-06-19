using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Domains.DTOs
{
    public class ReporteOcupacionDTO
    {
        public string Evento { get; set; } = string.Empty;
        public int CapacidadTotal { get; set; }
        public int EntradasVendidas { get; set; }
        public int EntradasDisponibles { get; set; }
        public decimal PorcentajeOcupacion { get; set; }
        public decimal TotalIngresos { get; set; }
        public string EstadoEvento { get; set; } = string.Empty;
    }
}
