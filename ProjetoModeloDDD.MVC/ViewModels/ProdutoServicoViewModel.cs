using ProjetoModeloDDD.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoServicoViewModel
    {
        [Key]
        public int ProdutoServicoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(120, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Descricao { get; set; }

        [Range(0, 99999.99)]
        [Required(ErrorMessage = "Preencha um valor")]
        public float ValorUnitario { get; set; }

        [Required(ErrorMessage = "Preencha o campo código de barras")]
        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string CodigoBarras { get; set; }
        public int GrupoImpostosId { get; set; }
        public virtual GrupoImpostos GrupoImpostos { get; set; }
        public int UnidadeComercialId { get; set; }
        public virtual UnidadeComercial UnidadeComercial { get; set; }
        public int NCMId { get; set; }
        public virtual NCM NCM { get; set; }
    }
}