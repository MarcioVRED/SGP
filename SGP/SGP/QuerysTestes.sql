CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](50) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Operacao] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SELECT RTRIM(R.UserName),RTRIM(L.Data),RTRIM(L.Operacao) from Logs L 
                                          INNER JOIN Registration R ON R.UserID = L.UserID
                                          order by Data

select R.UserName , L.Data Data, L.Operacao from Logs L
Inner join Registration R ON R.UserID = L.UserID


select * from Registration

select * from Logs

insert into Registration values ('2', 'MEDICO', 'sgp@samuel', 'Samuel', 'Consultorio', 'samuel@sgp.com', GETDATE())