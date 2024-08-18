using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class IndicadorIEViewModel
    {
        [Key]
        public int IndicadorIEId { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo {0} caracateres")]
        public string Descricao { get; set; }
    }
}