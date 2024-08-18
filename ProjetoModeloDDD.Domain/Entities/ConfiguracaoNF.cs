using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class ConfiguracaoNF
    {
        public int ConfiguracaoNFId { get; set; }
        public int NaturezaOperacaoId { get; set; }
        public string NumeroNF { get; set; }
        public NaturezaOperacao NaturezaOperacao { get; set; }
        public int DocumentoNotaFiscalId { get; set; }
        public DocumentoNotaFiscal DocumentoNotaFiscal { get; set; }
        public int ContabilidadeId { get; set; }
        public Contabilidade Contabilidade { get; set; }
    }
}
