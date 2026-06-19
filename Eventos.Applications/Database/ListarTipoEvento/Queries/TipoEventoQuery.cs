using Eventos.Applications.Common.Feactures;
using Eventos.Domains.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Applications.Database.ListarTipoEvento.Queries
{
  
    public record TipoEventoQuery()
: IRequest<Result<List<TipoEventoDTO>>>;

}
