using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class TipoGrupoImpostosViewModel
    {
        [Key]
        public int TipoGrupoImpostosId { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Descricao { get; set; }
    }
}