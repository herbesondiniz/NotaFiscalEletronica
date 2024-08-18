using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string DDDCelular { get; set; }
        public string Celular { get; set; }
        public string DDDTelefoneFixo { get; set; }
        public string TelefoneFixo { get; set; }
        public string email { get; set; }
        public string Contato { get; set; }
    }
}
