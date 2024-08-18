using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class UnidadeComercialViewModel
    {
        [Key]
        public int UnidadeComercialId { get; set; }
        [Required(ErrorMessage = "Preencha o campo unidade")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(120, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Descricao { get; set; }
    }
}