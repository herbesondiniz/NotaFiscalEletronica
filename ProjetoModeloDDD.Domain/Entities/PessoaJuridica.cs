using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class PessoaJuridica
    {
        public int PessoaJuridicaId { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int IndicadorIEId { get; set; }
        public virtual IndicadorIE IndicadorIE { get; set; }        
        public virtual EnderecoPessoa EnderecoPessoa { get; set; }
    }
}
