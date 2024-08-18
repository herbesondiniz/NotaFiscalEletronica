using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class NaturezaOperacaoService: ServiceBase<NaturezaOperacao>, INaturezaOperacaoService
    {
        private readonly INaturezaOperacaoRepository _naturezaOperacaoRepository;
        public NaturezaOperacaoService(INaturezaOperacaoRepository naturezaOperacaoRepository) :
            base(naturezaOperacaoRepository)
        {
            _naturezaOperacaoRepository = naturezaOperacaoRepository;
        }
    }
}
