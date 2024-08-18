using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PessoaFisicaViewModel
    {
        [Key]
        public int PessoaFisicaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo {0} caracateres")]
        public string RG { get; set; }
        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo {0} caracateres")]
        public string CPF { get; set; }
        public int PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual EnderecoPessoaViewModel EnderecoPessoa { get; set; }
        public int TipoEnderecoPessoaId { get; set; }
    }
}