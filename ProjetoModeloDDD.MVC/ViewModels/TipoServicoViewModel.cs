using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class TipoServicoViewModel
    {
        [Key]
        public int TipoServicoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public int Descricao { get; set; }
    }
}