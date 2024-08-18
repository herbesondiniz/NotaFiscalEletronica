using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ConfiguracaoViewModel
    {
        [Key]
        public int ConfiguracaoNFId { get; set; }      
        public int NaturezaOperacaoId { get; set; }
        
        [Required(ErrorMessage = "Informe o próximo número de nota fiscal")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo {0} caracateres")]
        public string NumeroNF { get; set; }
        public NaturezaOperacao NaturezaOperacao { get; set; }
        public int DocumentoNotaFiscalId { get; set; }
        public DocumentoNotaFiscal DocumentoNotaFiscal { get; set; }
        public int ContabilidadeId { get; set; }
        public Contabilidade Contabilidade { get; set; }        
    }
}