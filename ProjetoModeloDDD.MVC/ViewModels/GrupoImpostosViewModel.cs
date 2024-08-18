using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class GrupoImpostosViewModel
    {
        [Key]
        public int GrupoImpostosId { get; set; }

        [Required(ErrorMessage = "Preencha o campo descrição")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public string Descricao { get; set; }
        public int TipoGrupoImpostosId { get; set; }
        public virtual TipoGrupoImpostos TipoGrupoImpostos { get; set; }
        public virtual IEnumerable<CFOP> CFOPs { get; set; }
        public int TipoServicoId { get; set; }
        public virtual TipoServico TipoServico { get; set; }
    }
}