/*===========================Tabelas do módulo Usuário =============================*/
Create TABLE Usuario (
 UsuarioId int not null Identity(1,1) primary key,
 Nome varchar(120) not null,
 Login varchar(50) not null,
 senha varchar(32) not null
)
CREATE INDEX idx_UsuarioId ON Usuario (UsuarioId);


INSERT INTO Usuario (Nome,Login,Senha) values ('Herbeson','herbeson','202cb962ac59075b964b07152d234b70')

/*===========================Tabelas do módulo Empresa =============================*/

Create TABLE RegimeTributario (
 RegimeTributarioId int not null Identity(1,1) primary key,
 Descricao varchar(255)
)

CREATE INDEX idx_RegimeTributarioId ON RegimeTributario (RegimeTributarioId);

CREATE TABLE Empresa (
	EmpresaId int not null identity(1,1) primary key,
    RazaoSocial varchar(255),
	CNPJ varchar(14),
	NomeFantasia varchar(255),
    IE varchar(30),
	InscricaoMunicipal varchar(30),
    Email varchar(255),
	CNAE varchar(50),
	CEP varchar(8),
	Endereco varchar(255),
	Bairro varchar(255),
	UF varchar(2),
	Municipio varchar(255),
	Telefone varchar(10),
	Celular varchar(11),
	Contato varchar (50),
	RegimeTributarioId int
);

CREATE INDEX idx_EmpresaId ON Empresa (EmpresaId);
ALTER TABLE Empresa ADD FOREIGN KEY (RegimeTributarioId) REFERENCES RegimeTributario(RegimeTributarioId);

/*===================Tabelas do módulo de Configuração=========================================*/

use NotaFiscalEletronicaDB

Create TABLE NaturezaOperacao (
 NaturezaOperacaoId int not null Identity(1,1) primary key,
 CodigoNaturezaOperacao varchar(10),
 Descricao varchar(255)
 )

CREATE INDEX idx_NaturezaOperacaoId ON NaturezaOperacao (NaturezaOperacaoId);

create table Contabilidade (
 ContabilidadeId int not null Identity(1,1) primary key,
 RazaoSocialContabilidade varchar(255),
 ContatoContabilidade varchar(50),
 TelefoneContabilidade varchar(15),
 EmailContabilidade varchar(50)
)

CREATE INDEX idx_ContabilidadeId ON Contabilidade(ContabilidadeId);

create table DocumentoNotaFiscal (
DocumentoNotaFiscalId int not null Identity(1,1) primary key,
Ambiente varchar(50),
TipoDocumento varchar(10)
)

CREATE INDEX idx_DocumentoNotaFiscalId ON DocumentoNotaFiscal (DocumentoNotaFiscalId);

Create TABLE ConfiguracaoNF (
 ConfiguracaoNFId int not null Identity(1,1) primary key,				
 NaturezaOperacaoId int, 
 NumeroNF varchar(20),
 DocumentoNotaFiscalId int,
 InformacoesComplementares varchar(255),
 ContabilidadeId int
)

CREATE INDEX idx_ConfiguracaoId ON ConfiguracaoNF(ConfiguracaoNFId);
ALTER TABLE ConfiguracaoNF ADD FOREIGN KEY (NaturezaOperacaoId) REFERENCES NaturezaOperacao(NaturezaOperacaoId);
ALTER TABLE ConfiguracaoNF ADD FOREIGN KEY (ContabilidadeId) REFERENCES Contabilidade(ContabilidadeId);
ALTER TABLE ConfiguracaoNF ADD FOREIGN KEY (DocumentoNotaFiscalId) REFERENCES DocumentoNotaFiscal(DocumentoNotaFiscalId);


/*============================= Inserts===========================================*/


INSERT INTO RegimeTributario (Descricao) values ('Simples Nacional')
INSERT INTO DocumentoNotaFiscal (Ambiente, TipoDocumento) values ('Homologação','NF-e')
INSERT INTO DocumentoNotaFiscal (Ambiente, TipoDocumento) values ('Homologação','NFC-e')
INSERT INTO DocumentoNotaFiscal (Ambiente, TipoDocumento) values ('Produção','NF-e')
INSERT INTO DocumentoNotaFiscal (Ambiente, TipoDocumento) values ('Produção','NFC-e')
INSERT INTO NaturezaOperacao (CodigoNaturezaOperacao, Descricao) values ('5.102','Consumidor Interno')
INSERT INTO Contabilidade (RazaoSocialContabilidade,ContatoContabilidade,TelefoneContabilidade,EmailContabilidade) VALUES ('Contabilidade XPTO','Francisco','11-3313-0122','xpto@gmail.com')
INSERT INTO ConfiguracaoNF (NaturezaOperacaoId,DocumentoNotaFiscalId,ContabilidadeId, InformacoesComplementares, NumeroNF) 
	  VALUES (1,1,1,'Informações XPTO - Homologação NF-e','000001')

INSERT INTO ConfiguracaoNF (NaturezaOperacaoId,DocumentoNotaFiscalId,ContabilidadeId, InformacoesComplementares,NumeroNF) 
	  VALUES (1,2,1,'Informações XPTO - Homologação NFC-e','000001')

INSERT INTO ConfiguracaoNF (NaturezaOperacaoId,DocumentoNotaFiscalId,ContabilidadeId, InformacoesComplementares,NumeroNF) 
	  VALUES (1,3,1,'Informações XPTO - Produção NF-e','000001')

INSERT INTO ConfiguracaoNF (NaturezaOperacaoId,DocumentoNotaFiscalId,ContabilidadeId, InformacoesComplementares,NumeroNF) 
	  VALUES (1,4,1,'Informações XPTO - Produção NFC-e','000001')


--select * from NaturezaOperacao
--select * from Contabilidade
--select * from DocumentoNotaFiscal 
--select * from ConfiguracaoNF

/*==============================Grupo de Impostos============================================================*/

Create TABLE TipoGrupoImpostos(--Produto ou Serviço
TipoGrupoImpostosId int not null Identity(1,1) primary key,
Descricao varchar(100)
)

CREATE INDEX idx_TipoGrupoImpostos ON TipoGrupoImpostos(TipoGrupoImpostosId)

CREATE TABLE TipoServico(
TipoServicoId int not null Identity(1,1) primary key,
Descricao varchar(max)
)

CREATE INDEX idx_TipoServicoId ON TipoServico(TipoServicoId)

Create TABLE GrupoImpostos (
 GrupoImpostosId int not null Identity(1,1) primary key,				
 Descricao varchar(100), 
 TipoGrupoImpostosId int,
 TipoServicoId int
)

CREATE INDEX idx_GrupoImpostosId ON GrupoImpostos(GrupoImpostosId)
ALTER TABLE GrupoImpostos ADD FOREIGN KEY (TipoGrupoImpostosId) REFERENCES TipoGrupoImpostos(TipoGrupoImpostosId)


Create TABLE CFOP (
 CFOPId int not null Identity(1,1) primary key,
 CodigoCFOP int not null, 			
 Origem int, 
 ICMSCSOSN int,
 PISAliq float,
 PISCSOSN int,
 COFINSAliq float,
 CONFINSCSOSN int,
 ISSALiq float,
 TipoGrupoImpostosId int
)

CREATE INDEX idx_CFOP ON CFOP(CFOPId);
ALTER TABLE CFOP ADD FOREIGN KEY (TipoGrupoImpostosId) REFERENCES TipoGrupoImpostos(TipoGrupoImpostosId);

INSERT INTO TipoGrupoImpostos (Descricao) values ('Produto')
INSERT INTO TipoGrupoImpostos (Descricao) values ('Serviço')

INSERT INTO TipoServico (Descricao) values ('101 - Análise e desenvolvimento de sistemas.')
INSERT INTO TipoServico (Descricao) values ('102 - Programação.')
INSERT INTO TipoServico (Descricao) values ('103 - Processamento de dados e congêneses.')
INSERT INTO TipoServico (Descricao) values ('104 - Elaboração de programas de computadores , inclusive jogos eletrônicos.')

INSERT INTO CFOP (CodigoCFOP, Origem, PISAliq, PISCSOSN, COFINSAliq, CONFINSCSOSN, ISSALiq, TipoGrupoImpostosId)
Values (5102, 0, 0.00, 99, 0.00, 99, 0.00,1)

INSERT INTO CFOP (CodigoCFOP, Origem, PISAliq, PISCSOSN, COFINSAliq, CONFINSCSOSN, ISSALiq, TipoGrupoImpostosId)
Values (6102, 0, 0.00, 99, 0.00, 99, 0.00,1)

INSERT INTO CFOP (CodigoCFOP,Origem, ICMSCSOSN, PISAliq,PISCSOSN,COFINSAliq,CONFINSCSOSN,ISSALiq,TipoGrupoImpostosId)
Values (6102, 0, 102, 0.00,99,0.00,99,0.00,2)

INSERT INTO CFOP (CodigoCFOP,Origem, ICMSCSOSN, PISAliq,PISCSOSN,COFINSAliq,CONFINSCSOSN,ISSALiq,TipoGrupoImpostosId)
Values (6933, 0, 102, 0.00,99,0.00,99,0.00,2)

--select * from TipoGrupoImpostos
--select * from GrupoImpostos
--select * from tiposervico
--select * from CFOP
--DROP INDEX idx_GrupoImpostosId ON GrupoImpostos;
--DROP table GrupoImpostos

/*==============================Lista de Produtos============================================================*/

Create TABLE NCM (
 NCMId int not null Identity(1,1) primary key,
 CodigoNCM VARCHAR(12),
 DataInicioVigencia datetime, 			
 DataFimVigencia datetime, 
 Unidade varchar(2),
 DescricaoUnidade varchar(100)
)

CREATE INDEX idx_NCM ON NCM(NCMId)

INSERT INTO NCM (CodigoNCM, DataInicioVigencia, DataFimVigencia, Unidade, DescricaoUnidade) VALUES ('01012100','20160101',NULL,'UN','UNIDADE')
INSERT INTO NCM (CodigoNCM, DataInicioVigencia, DataFimVigencia, Unidade, DescricaoUnidade) VALUES ('01012101','20160101',NULL,'UN','UNIDADE')
INSERT INTO NCM (CodigoNCM, DataInicioVigencia, DataFimVigencia, Unidade, DescricaoUnidade) VALUES ('01012102','20160101',NULL,'UN','UNIDADE')
INSERT INTO NCM (CodigoNCM, DataInicioVigencia, DataFimVigencia, Unidade, DescricaoUnidade) VALUES ('01012103','20160101',NULL,'UN','UNIDADE')
INSERT INTO NCM (CodigoNCM, DataInicioVigencia, DataFimVigencia, Unidade, DescricaoUnidade) VALUES ('01012104','20160101',NULL,'UN','UNIDADE')

Create TABLE UnidadeComercial (
 UnidadeComercialId int not null Identity(1,1) primary key,
 Unidade varchar(2),
 Descricao varchar(20)
)

CREATE INDEX idx_UnidadeComercial ON UnidadeComercial(UnidadeComercialId);

Create TABLE ProdutoServico (
 ProdutoServicoId int not null Identity(1,1) primary key,
 Descricao varchar(120),
 ValorUnitario float,
 CodigoBarras varchar(15), 
 GrupoImpostosId int not null,
 UnidadeComercialId int not null,
 NCMId int 
)

CREATE INDEX idx_ProdutoServico ON ProdutoServico(ProdutoServicoId);

--DROP INDEX idx_ProdutoServico ON idx_ProdutoServico;
--DROP table [dbo].[ProdutoServico]

ALTER TABLE ProdutoServico ADD FOREIGN KEY (GrupoImpostosId) REFERENCES GrupoImpostos(GrupoImpostosId);
ALTER TABLE ProdutoServico ADD FOREIGN KEY (UnidadeComercialId) REFERENCES UnidadeComercial(UnidadeComercialId);

INSERT INTO UnidadeComercial (Unidade, Descricao) VALUES ('UN', 'UNIDADE')
INSERT INTO UnidadeComercial (Unidade, Descricao) VALUES ('kg', 'kilograma')

INSERT INTO ProdutoServico (Descricao,ValorUnitario,CodigoBarras,GrupoImpostosId,UnidadeComercialId,NCMId) VALUES ('licença de uso de software', 29.90,'1121221131211',4,1,1)


SELECT * FROM UnidadeComercial
SELECT * FROM GrupoImpostos
select * from TipoGrupoImpostos
SELECT * FROM ProdutoServico
select * from ncm n 

/*==============================Módulo Destinatário ============================================================*/
use NotaFiscalEletronicaDB

Create TABLE Pessoa (
 PessoaId int not null Identity(1,1) primary key,
 DDDCelular varchar(2),
 Celular varchar(9),
 DDDTelefoneFixo varchar(2),
 TelefoneFixo varchar(8),
 email varchar(200),
 Contato varchar(50)
)
CREATE INDEX idx_PessoaId ON Pessoa(PessoaId);

Create TABLE Endereco (
 EnderecoId int not null Identity(1,1) primary key,
 CEP varchar(8),
 Tipo varchar(50),
 Logradouro varchar(500),
 Observacao varchar(500),
 Bairro varchar(100),
 Municipio varchar(100),
 Cidade varchar(100),
 UF varchar(2)
)
CREATE INDEX idx_EnderecoId ON Endereco(EnderecoId);

Create TABLE TipoEnderecoPessoa (
 TipoEnderecoPessoaId int not null Identity(1,1) primary key,
 Tipo varchar(30) 
)
CREATE INDEX idx_TipoEnderecoPessoaId ON TipoEnderecoPessoa(TipoEnderecoPessoaId)

Create Table EnderecoPessoa (
 EnderecoPessoaId int not null Identity(1,1) primary key,
 CEP varchar(8),
 Tipo varchar(50),
 Logradouro varchar(500),
 Numero int,
 Bairro varchar(100),
 Municipio varchar(100),
 Cidade varchar(100),
 UF varchar(2),
 Complemento varchar(100),
 PessoaId int not null,
 TipoEnderecoPessoaId int not null
)

CREATE INDEX idx_EnderecoPessoaId ON EnderecoPessoa(EnderecoPessoaId);
ALTER TABLE EnderecoPessoa ADD FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId);
ALTER TABLE EnderecoPessoa ADD FOREIGN KEY (TipoEnderecoPessoaId) REFERENCES TipoEnderecoPessoa(TipoEnderecoPessoaId);

Create TABLE PessoaFisica (
 PessoaFisicaId int not null Identity(1,1) primary key,
 Nome varchar(50),
 RG varchar(15),
 CPF varchar(11),
 PessoaId int
)
CREATE INDEX idx_PessoaFisicaId ON PessoaFisica(PessoaFisicaId);
ALTER TABLE PessoaFisica ADD FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId);

Create TABLE IndicadorIE (
 IndicadorIEId int not null Identity(1,1) primary key,
 Descricao varchar(50) 
)
CREATE INDEX idx_IndicadorIEId ON IndicadorIE(IndicadorIEId);

INSERT INTO IndicadorIE(Descricao) VALUES ('Contribuinte Isento')
INSERT INTO IndicadorIE(Descricao) VALUES ('Contribuinte ICMS')
INSERT INTO IndicadorIE(Descricao) VALUES ('Não Contribuinte')

Create TABLE PessoaJuridica (
 PessoaJuridicaId int not null Identity(1,1) primary key,
 RazaoSocial varchar(50),
 CNPJ varchar(14) not null,
 IE varchar(15),
 PessoaId int,
 IndicadorIEId int
)
CREATE INDEX idx_PessoaJuridicaId ON PessoaJuridica(PessoaJuridicaId);
ALTER TABLE PessoaJuridica ADD FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId);
ALTER TABLE PessoaJuridica ADD FOREIGN KEY (IndicadorIEId) REFERENCES IndicadorIE(IndicadorIEId);

INSERT INTO TipoEnderecoPessoa(Tipo) VALUES ('Residencial')
INSERT INTO TipoEnderecoPessoa(Tipo) VALUES ('Comercial')

select *  from pessoa  
select * from pessoaFisica  
select * from PessoaJuridica
select * from endereco  
select * from EnderecoPessoa  
select * from TipoEnderecoPessoa
select * from IndicadorIE
