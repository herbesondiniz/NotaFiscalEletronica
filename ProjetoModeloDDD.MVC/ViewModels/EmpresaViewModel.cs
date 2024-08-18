using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class EmpresaViewModel
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo razão social")]
        [MaxLength(255, ErrorMessage = "Máximo {0} caracteres")]        
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo cnpj")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome fantasia")]
        [MaxLength(255, ErrorMessage = "Máximo {0} caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo de inscrição estadual")]
        public string IE { get; set; }

        [Required(ErrorMessage = "Preencha o campo de inscrição municipal")]
        public string InscricaoMunicipal { get; set; }

        [Required(ErrorMessage = "Preencha o campo e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNAE")]
        public string CNAE { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha o campo endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o campo bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo UF")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Preencha o campo município")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo celular")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        public string Celular { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        public string Contato { get; set; }
        public string RegimeTributarioId { get; set; }
        public virtual RegimeTributario RegimeTributario { get; set; }
    }
}