using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class EnderecoPessoaViewModel
    {
        [Key]
        public int EnderecoPessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo cep")]
        [MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracateres")]
        public string CEP { get; set; }
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o campo número")]        
        public int Numero { get; set; }
        [Required(ErrorMessage = "Preencha o campo bairro")]
        public string Bairro { get; set; }        
        public string Municipio { get; set; }
       
        [Required(ErrorMessage = "Preencha o campo cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo UF")]
        public string UF { get; set; }
        public string Complemento { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }            
        public int TipoEnderecoPessoaId { get; set; }
        public virtual TipoEnderecoPessoa TipoEnderecoPessoa { get; set; }
    }
}