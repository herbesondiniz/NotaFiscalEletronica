
namespace ProjetoModeloDDD.Domain.Entities
{
    public class ProdutoServico
    {
        public int ProdutoServicoId { get; set; }
        public string Descricao { get; set; }
        public float ValorUnitario { get; set; }
        public string CodigoBarras { get; set; }
        public int GrupoImpostosId { get; set; }
        public virtual GrupoImpostos GrupoImpostos { get; set; }
        public int UnidadeComercialId { get; set; }
        public virtual UnidadeComercial UnidadeComercial { get; set; }
        public int NCMId { get; set; }
        public virtual NCM NCM { get; set; }
    }
}
