using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public override string ProfileName
		{
			get { return "DomainToViewModelMappings"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Cliente, ClienteViewModel>();
			Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Empresa, EmpresaViewModel>();
            Mapper.CreateMap<TipoServico, TipoServicoViewModel>();
			Mapper.CreateMap<GrupoImpostos, GrupoImpostosViewModel>();
			Mapper.CreateMap<ConfiguracaoNF, ConfiguracaoViewModel>();
			Mapper.CreateMap<CFOP, CFOPViewModel>();
			Mapper.CreateMap<UnidadeComercial, UnidadeComercialViewModel>();
			Mapper.CreateMap<NCM, NCMViewModel>();
			Mapper.CreateMap<ProdutoServico, ProdutoServicoViewModel>();
			Mapper.CreateMap<Pessoa, PessoaViewModel>();
			Mapper.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
			Mapper.CreateMap<EnderecoPessoa, EnderecoPessoaViewModel>();
			Mapper.CreateMap<IndicadorIE, IndicadorIEViewModel>();
			Mapper.CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
		}
	}
}