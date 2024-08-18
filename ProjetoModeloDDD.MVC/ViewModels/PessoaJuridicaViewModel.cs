using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class PessoaJuridicaViewModel
    {
        [Key]
        public int PessoaJuridicaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo razão social")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracateres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(14, ErrorMessage = "Mínimo {0} caracateres")]
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public int PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }
        public int IndicadorIEId { get; set; }
        public virtual IndicadorIEViewModel IndicadorIE { get; set; }
        public virtual EnderecoPessoaViewModel EnderecoPessoa { get; set; }
        public int TipoEnderecoPessoaId { get; set; }
    }
}