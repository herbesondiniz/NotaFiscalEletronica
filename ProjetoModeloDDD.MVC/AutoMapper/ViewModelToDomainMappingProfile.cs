using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public override string ProfileName
		{
			get { return "ViewModelToDomainMappingProfile"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ClienteViewModel, Cliente>();
			Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<ConfiguracaoViewModel, ConfiguracaoNF>();			
			Mapper.CreateMap<TipoGrupoImpostosViewModel, TipoGrupoImpostos>();
			Mapper.CreateMap<TipoServicoViewModel, TipoServico>();
			Mapper.CreateMap<GrupoImpostosViewModel, GrupoImpostos>();
			Mapper.CreateMap<CFOPViewModel, CFOP>();
			Mapper.CreateMap<UnidadeComercialViewModel, UnidadeComercial>();
			Mapper.CreateMap<NCMViewModel, NCM>();
			Mapper.CreateMap<ProdutoServicoViewModel, ProdutoServico>();
			Mapper.CreateMap<PessoaViewModel, Pessoa>();
			Mapper.CreateMap<PessoaFisicaViewModel, PessoaFisica>();
			Mapper.CreateMap<EnderecoPessoaViewModel, EnderecoPessoa>();
			Mapper.CreateMap<IndicadorIEViewModel, IndicadorIE>();
			Mapper.CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();			
		}
	}
}