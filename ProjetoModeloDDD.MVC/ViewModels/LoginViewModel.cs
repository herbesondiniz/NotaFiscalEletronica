using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o usuário")]
        [Display(Name = "Usuário:")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Lembrar-me:")]
        public bool LembrarMe { get; set; }
    }
}