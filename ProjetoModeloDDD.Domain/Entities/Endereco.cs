using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string CEP { get; set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Observacao { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
