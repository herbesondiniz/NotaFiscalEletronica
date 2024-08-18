using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class CFOPViewModel
    {
        [Key]
        public int CFOPId { get; set; }       
        public int CodigoCFOP { get; set; }

        [Required(ErrorMessage = "Preencha o campo origem")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
        public int Origem { get; set; }        
        public int ICMSCSOSN { get; set; }
        public float PISAliq { get; set; }
        public float PISCSOSN { get; set; }
        public float COFINSAliq { get; set; }
        public float CONFINSCSOSN { get; set; }
        public float ISSALiq { get; set; }
        public int TipoGrupoImpostosId { get; set; }
        public virtual TipoGrupoImpostos TipoGrupoImpostos { get; set; }
    }
}