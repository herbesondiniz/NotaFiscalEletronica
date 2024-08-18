using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class NCM
    {
        public int NCMId { get; set; }
        public string CodigoNCM { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime DataFimVigencia { get; set; }
        public string Unidade { get; set; }
        public string DescricaoUnidade { get; set; }
    }
}
