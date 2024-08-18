using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PessoaViewModel
    {
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo ddd do celular")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string DDDCelular { get; set; }

        [Required(ErrorMessage = "Preencha o campo celular")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(9, ErrorMessage = "Mínimo {0} caracateres")]
        public string Celular { get; set; }

        public string DDDTelefoneFixo { get; set; }
      
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracateres")]
        public string email { get; set; }
        public string Contato { get; set; }        
    }
}