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
    public class NaturezaOperacaoAppService: AppServiceBase<NaturezaOperacao>, INaturezaOperacaoAppService
    {
        private readonly INaturezaOperacaoService _naturezaOperacaoService;
        public NaturezaOperacaoAppService(INaturezaOperacaoService naturezaOperacaoService)
            : base(naturezaOperacaoService)
        {
            _naturezaOperacaoService = naturezaOperacaoService;
        }
    }
}
