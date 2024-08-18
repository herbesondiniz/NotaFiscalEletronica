using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class TipoGrupoImpostosAppService : AppServiceBase<TipoGrupoImpostos>, ITipoGrupoImpostosAppService
    {
        private readonly ITipoGrupoImpostosService _tipoGrupoImpostosService;
        public TipoGrupoImpostosAppService(ITipoGrupoImpostosService tipoGrupoImpostosService)
             : base(tipoGrupoImpostosService)
        {
            _tipoGrupoImpostosService = tipoGrupoImpostosService;
        }
    }
}
