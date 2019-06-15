

select * from Registration
select * from Logs
select * from Staff
select * from Patient
select * from [Procedure]









--insert into Registration(UserID, UserTipo, UserSenha, UserName, UserContato, UserEmail,DataCadastro) VALUES ('Admin','ADM','adminsgp','Suporte','991559891','suporte@sgp.com',GETDATE())

--CREATE TABLE [dbo].[Staff](
--	[S_ID] [int] NOT NULL,
--	[StaffID] [nchar](15) NOT NULL,
--	[Nome] [nchar](150) NOT NULL,
--	[DOB] [datetime] NOT NULL,
--	[Sexo] [nchar](15) NOT NULL,
--	[Endereco] [varchar](250) NOT NULL,
--	[Cidade] [nchar](150) NOT NULL,
--	[Contato] [nchar](50) NOT NULL,
--	[Email] [nchar](150) NULL,
--	[Tipo] [nchar](100) NOT NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[S_ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO

--CREATE TABLE [dbo].[Patient](
--	[P_ID] [int] NOT NULL,
--	[PacienteID] [nchar](15) NOT NULL,
--	[Nome] [nchar](150) NOT NULL,
--	[DOB] [datetime] NOT NULL,
--	[Sexo] [nchar](15) NOT NULL,
--	[Observacoes] [varchar](250) NOT NULL,
--	[Doencas] [nchar](150) NOT NULL,
--	[Medicamentos] [nchar](50) NOT NULL,
--	[Email] [nchar](150) NULL,
--	[Fumante] [nchar](150) NOT NULL,
--	[Contato] [nchar](100) NULL,
-- CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
--(
--	[P_ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO

--CREATE TABLE [dbo].[Procedure](
--	[Proc_Id] [int] NOT NULL,
--	[ProcID] [nchar](15) NOT NULL,
--	[Data] [datetime] NOT NULL,
--	[PacienteID] [int] NOT NULL,
--	[StaffID] [int] NOT NULL,
--	[ProcTipo] [nchar](150) NOT NULL,
--	[Descricao] [varchar](250) NULL,
--	[Dente] [nchar](10) NOT NULL,
--	[Exodontia] [varchar](250) NULL,
--	[Endodontia] [varchar](250) NULL,
--	[Periodontia] [varchar](250) NULL,
--PRIMARY KEY CLUSTERED 
--(
--	[Proc_Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO

