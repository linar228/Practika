USE [linar2]
GO
/****** Object:  Table [dbo].[DeliveryMethod]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryMethod](
	[ID] [int] NOT NULL,
	[Name] [varchar](30) NULL,
 CONSTRAINT [PK_DeliveryMethod] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EditionReceiving]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EditionReceiving](
	[SubEdID] [int] NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_EditionReceiving] PRIMARY KEY CLUSTERED 
(
	[SubEdID] ASC,
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editions]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NULL,
	[EditionType] [int] NULL,
	[Status] [bit] NULL,
	[Price] [nvarchar](50) NULL,
 CONSTRAINT [PK_Editions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EditionType]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EditionType](
	[ID] [int] NOT NULL,
	[Name] [varchar](20) NULL,
 CONSTRAINT [PK_EditionType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodicity]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodicity](
	[ID] [int] NOT NULL,
	[Name] [varchar](25) NULL,
 CONSTRAINT [PK_Periodicity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NOT NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscribedEditions]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscribedEditions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Edition] [int] NULL,
	[SubscriptionTerm] [int] NULL,
	[DeliveryMethod] [int] NULL,
	[UserID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_SubscribedEditions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionTerm]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionTerm](
	[ID] [int] NOT NULL,
	[Term] [varchar](30) NULL,
	[Periodicity] [int] NULL,
	[Subscriber] [int] NULL,
 CONSTRAINT [PK_SubscriptionTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.06.2022 13:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[RoleId] [int] NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[DeliveryMethod] ([ID], [Name]) VALUES (1, N'Бандеролью')
INSERT [dbo].[DeliveryMethod] ([ID], [Name]) VALUES (2, N'По почте')
INSERT [dbo].[DeliveryMethod] ([ID], [Name]) VALUES (3, N'Аист приносит')
GO
SET IDENTITY_INSERT [dbo].[Editions] ON 

INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (1, N'Мурзилка', 3, 1, N'2000')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (2, N'Мурзилка Диско', 1, 1, N'2500')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (3, N'Мурзилка Ретро', 3, 1, N'4000')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (1007, N'Мурзилка 3', 2, 1, N'2400')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (1009, N'Мужчины', 3, 1, N'1313')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (1010, N'Мир', 3, 1, N'2313')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (1011, N'Рилькка', 2, 1, N'1111')
INSERT [dbo].[Editions] ([ID], [Name], [EditionType], [Status], [Price]) VALUES (1012, N'ЯМИР', 1, 0, N'5411')
SET IDENTITY_INSERT [dbo].[Editions] OFF
GO
INSERT [dbo].[EditionType] ([ID], [Name]) VALUES (1, N'Газета')
INSERT [dbo].[EditionType] ([ID], [Name]) VALUES (2, N'Журнал')
INSERT [dbo].[EditionType] ([ID], [Name]) VALUES (3, N'Цифровой')
GO
INSERT [dbo].[Periodicity] ([ID], [Name]) VALUES (1, N'Еженедельно')
INSERT [dbo].[Periodicity] ([ID], [Name]) VALUES (2, N'Ежемесячно')
GO
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([ID], [RoleName]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[SubscribedEditions] ON 

INSERT [dbo].[SubscribedEditions] ([ID], [Date], [Edition], [SubscriptionTerm], [DeliveryMethod], [UserID], [Status]) VALUES (10, CAST(N'2022-06-30T11:11:00.000' AS DateTime), 1007, 1, 3, 32, 1)
INSERT [dbo].[SubscribedEditions] ([ID], [Date], [Edition], [SubscriptionTerm], [DeliveryMethod], [UserID], [Status]) VALUES (11, CAST(N'2022-06-30T11:21:00.000' AS DateTime), 2, 1, 2, 32, 1)
INSERT [dbo].[SubscribedEditions] ([ID], [Date], [Edition], [SubscriptionTerm], [DeliveryMethod], [UserID], [Status]) VALUES (13, CAST(N'2022-06-30T13:42:34.323' AS DateTime), 1, 1, 1, 35, 0)
INSERT [dbo].[SubscribedEditions] ([ID], [Date], [Edition], [SubscriptionTerm], [DeliveryMethod], [UserID], [Status]) VALUES (14, CAST(N'2022-06-30T15:14:00.000' AS DateTime), 1007, 1, 2, 35, 1)
INSERT [dbo].[SubscribedEditions] ([ID], [Date], [Edition], [SubscriptionTerm], [DeliveryMethod], [UserID], [Status]) VALUES (15, CAST(N'2022-06-30T13:09:00.000' AS DateTime), 1010, 1, 2, 30, 1)
INSERT [dbo].[SubscribedEditions] ([ID], [Date], [Edition], [SubscriptionTerm], [DeliveryMethod], [UserID], [Status]) VALUES (16, CAST(N'2022-06-30T13:42:47.913' AS DateTime), 1011, 1, 1, 35, 1)
SET IDENTITY_INSERT [dbo].[SubscribedEditions] OFF
GO
INSERT [dbo].[SubscriptionTerm] ([ID], [Term], [Periodicity], [Subscriber]) VALUES (1, N'6 месяцев', 1, NULL)
INSERT [dbo].[SubscriptionTerm] ([ID], [Term], [Periodicity], [Subscriber]) VALUES (2, N'1 год', 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Login], [RoleId], [Password]) VALUES (30, N'1', 1, N'1')
INSERT [dbo].[Users] ([ID], [Login], [RoleId], [Password]) VALUES (32, N'2', 2, N'2')
INSERT [dbo].[Users] ([ID], [Login], [RoleId], [Password]) VALUES (34, N'13', 2, N'13')
INSERT [dbo].[Users] ([ID], [Login], [RoleId], [Password]) VALUES (35, N'3', 2, N'3')
INSERT [dbo].[Users] ([ID], [Login], [RoleId], [Password]) VALUES (36, N'5', 2, N'5')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[EditionReceiving]  WITH CHECK ADD  CONSTRAINT [FK_EditionReceiving_SubscribedEditions] FOREIGN KEY([SubEdID])
REFERENCES [dbo].[SubscribedEditions] ([ID])
GO
ALTER TABLE [dbo].[EditionReceiving] CHECK CONSTRAINT [FK_EditionReceiving_SubscribedEditions]
GO
ALTER TABLE [dbo].[Editions]  WITH CHECK ADD  CONSTRAINT [FK_Editions_EditionType] FOREIGN KEY([EditionType])
REFERENCES [dbo].[EditionType] ([ID])
GO
ALTER TABLE [dbo].[Editions] CHECK CONSTRAINT [FK_Editions_EditionType]
GO
ALTER TABLE [dbo].[SubscribedEditions]  WITH CHECK ADD  CONSTRAINT [FK_SubscribedEditions_DeliveryMethod] FOREIGN KEY([DeliveryMethod])
REFERENCES [dbo].[DeliveryMethod] ([ID])
GO
ALTER TABLE [dbo].[SubscribedEditions] CHECK CONSTRAINT [FK_SubscribedEditions_DeliveryMethod]
GO
ALTER TABLE [dbo].[SubscribedEditions]  WITH CHECK ADD  CONSTRAINT [FK_SubscribedEditions_Editions] FOREIGN KEY([Edition])
REFERENCES [dbo].[Editions] ([ID])
GO
ALTER TABLE [dbo].[SubscribedEditions] CHECK CONSTRAINT [FK_SubscribedEditions_Editions]
GO
ALTER TABLE [dbo].[SubscribedEditions]  WITH CHECK ADD  CONSTRAINT [FK_SubscribedEditions_SubscriptionTerm] FOREIGN KEY([SubscriptionTerm])
REFERENCES [dbo].[SubscriptionTerm] ([ID])
GO
ALTER TABLE [dbo].[SubscribedEditions] CHECK CONSTRAINT [FK_SubscribedEditions_SubscriptionTerm]
GO
ALTER TABLE [dbo].[SubscribedEditions]  WITH CHECK ADD  CONSTRAINT [FK_SubscribedEditions_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[SubscribedEditions] CHECK CONSTRAINT [FK_SubscribedEditions_Users]
GO
ALTER TABLE [dbo].[SubscriptionTerm]  WITH CHECK ADD  CONSTRAINT [FK_SubscriptionTerm_Periodicity] FOREIGN KEY([Periodicity])
REFERENCES [dbo].[Periodicity] ([ID])
GO
ALTER TABLE [dbo].[SubscriptionTerm] CHECK CONSTRAINT [FK_SubscriptionTerm_Periodicity]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles1] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles1]
GO
