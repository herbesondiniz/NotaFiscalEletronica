using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class CFOP
    {
        public int CFOPId { get; set; }
        public int CodigoCFOP { get; set; }
        public int Origem { get; set; }
        public int ICMSCSOSN { get; set; }
        public float PISAliq { get; set; }
        public int PISCSOSN { get; set; }
        public float COFINSAliq { get; set; }
        public int CONFINSCSOSN { get; set; }
        public float ISSALiq { get; set; }
        public int TipoGrupoImpostosId { get; set; }
        public virtual TipoGrupoImpostos TipoGrupoImpostos { get; set; }
    }
}
