using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class UnidadeComercial
    {
        public int UnidadeComercialId { get; set; }
        public string Unidade { get; set; }
        public string Descricao { get; set; }
    }
}
