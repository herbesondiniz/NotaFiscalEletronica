using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class GrupoImpostos
    {       
        public int GrupoImpostosId { get; set; }
        public string Descricao { get; set; }
        public int TipoGrupoImpostosId { get; set; }
        public virtual TipoGrupoImpostos TipoGrupoImpostos { get; set; }
        public virtual IEnumerable<CFOP> CFOPs { get; set; }
        public int TipoServicoId { get; set; }         
        public virtual TipoServico TipoServico { get; set; }
    }
}
