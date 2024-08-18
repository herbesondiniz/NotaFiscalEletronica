
namespace ProjetoModeloDDD.Domain.Entities
{
    public class EnderecoPessoa
    {
        public int EnderecoPessoaId { get; set; }
        public string CEP { get; set; }              
        public string Logradouro { get; set; }        
        public int Numero { get; set; }        
        public string Bairro { get; set; }              
        public string Cidade { get; set; }      
        public string UF { get; set; }
        public string Complemento { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }         
        public int TipoEnderecoPessoaId { get; set; }
        public virtual TipoEnderecoPessoa TipoEnderecoPessoa { get; set; }
    }
}
