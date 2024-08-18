using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
	public class ProdutoViewModel
	{
		[Key]
		public int ProdutoId { get; set; }

		[Required(ErrorMessage = "Preencha o campo nome")]
		[MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracateres")]
		public string Nome { get; set; }
		
		[Range(0, 99999.99)]
		[Required(ErrorMessage = "Preencha um valor")]		
		public decimal Valor { get; set; }

		[DisplayName("Disponível?")]
		public bool Disponivel { get; set; }
		public int ClienteId { get; set; }
		public virtual ClienteViewModel Cliente { get; set; }		
	}
}