using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class NCMViewModel
    {
        [Key]
        public int NCMId { get; set; }

        [Required(ErrorMessage = "Preencha o campo ncm")]
        [MaxLength(12, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracateres")]
        public string CodigoNCM { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime DataFimVigencia { get; set; }

        [Required(ErrorMessage = "Preencha o campo unidade")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição da unidade")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string DescricaoUnidade { get; set; }
    }
}