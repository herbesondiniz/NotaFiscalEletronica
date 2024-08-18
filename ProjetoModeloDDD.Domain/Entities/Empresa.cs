using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Empresa
    {       
        public int EmpresaId {get;set;} 
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string IE { get; set; }
        public string InscricaoMunicipal {get;set;}
        public string Email { get; set; }
        public string CNAE { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Municipio { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Contato { get; set; }
        public int RegimeTributarioId { get; set; }
        public virtual RegimeTributario RegimeTributario { get; set; }
    }
}