

namespace ProjetoModeloDDD.Domain.Entities
{
    public class PessoaFisica
    {
        public int PessoaFisicaId { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }        
        public virtual EnderecoPessoa EnderecoPessoa { get; set; }
    }
}
