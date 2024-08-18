using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Contabilidade
    {
        public int ContabilidadeId { get; set; }
        public string RazaoSocialContabilidade { get; set; }
        public string ContatoContabilidade { get; set; }
        public string TelefoneContabilidade { get; set; }
        public string EmailContabilidade { get; set; }

    }
}
