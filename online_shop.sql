USE [OnlineShop]
GO
/****** Object:  Table [dbo].[About]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[metaTitle] [nvarchar](250) NULL,
	[descriptions] [nvarchar](250) NULL,
	[imageLocation] [nvarchar](500) NULL,
	[detail] [ntext] NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[metaKeyword] [nvarchar](250) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_dbo.About] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[metaTitle] [nvarchar](250) NULL,
	[parentID] [int] NULL,
	[displayOrder] [int] NULL,
	[seoTitle] [nvarchar](250) NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[metaKeyword] [nvarchar](250) NULL,
	[metaDecription] [nvarchar](300) NULL,
	[status] [bit] NOT NULL,
	[showOnHome] [int] NULL,
	[languages] [nvarchar](2) NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contact]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [ntext] NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Content]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[metaTitle] [nvarchar](250) NULL,
	[descriptions] [nvarchar](250) NULL,
	[imageLocation] [nvarchar](500) NULL,
	[categoryID] [int] NULL,
	[detail] [ntext] NULL,
	[guarantee] [int] NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[metaKeyword] [nvarchar](250) NULL,
	[status] [bit] NOT NULL,
	[topHot] [datetime] NULL,
	[viewCount] [int] NULL,
	[tags] [nvarchar](500) NULL,
	[languages] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Content] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContentTag]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentTag](
	[contentID] [bigint] NOT NULL,
	[tagID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.ContentTag] PRIMARY KEY CLUSTERED 
(
	[contentID] ASC,
	[tagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](50) NULL,
	[address] [nvarchar](100) NULL,
	[content] [ntext] NULL,
	[createDate] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Footer]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[id] [nvarchar](50) NOT NULL,
	[content] [ntext] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_dbo.Footer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[link] [nvarchar](250) NULL,
	[displayOrder] [int] NULL,
	[target] [nvarchar](50) NULL,
	[status] [bit] NOT NULL,
	[typeID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.MenuType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[productID] [bigint] NOT NULL,
	[orderID] [bigint] NOT NULL,
	[quantity] [int] NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_dbo.OrderDetail] PRIMARY KEY CLUSTERED 
(
	[productID] ASC,
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[customerID] [bigint] NULL,
	[createDate] [datetime] NULL,
	[shipName] [nvarchar](50) NULL,
	[shipMobile] [nvarchar](50) NULL,
	[shipAddress] [nvarchar](50) NULL,
	[shipEmail] [nvarchar](50) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permission]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[userGroupID] [nvarchar](20) NOT NULL,
	[roleID] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED 
(
	[userGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[code] [nvarchar](20) NULL,
	[metaTitle] [nvarchar](250) NULL,
	[descriptions] [nvarchar](250) NULL,
	[imageLocation] [nvarchar](500) NULL,
	[moreImages] [xml] NULL,
	[price] [float] NULL,
	[discountPrice] [float] NULL,
	[includeVAT] [int] NULL,
	[quantity] [int] NULL,
	[categoryID] [int] NOT NULL,
	[detail] [ntext] NULL,
	[guarantee] [int] NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[metaKeyword] [nvarchar](250) NULL,
	[status] [bit] NOT NULL,
	[topHot] [datetime] NULL,
	[viewCount] [int] NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductsCategory]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[metaTitle] [nvarchar](250) NULL,
	[parentID] [int] NULL,
	[displayOrder] [int] NULL,
	[seoTitle] [nvarchar](250) NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[metaKeyword] [nvarchar](250) NULL,
	[status] [bit] NOT NULL,
	[showOnHome] [int] NULL,
 CONSTRAINT [PK_dbo.ProductsCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slide]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imageLocation] [nvarchar](500) NULL,
	[displayOrder] [int] NULL,
	[link] [nvarchar](250) NULL,
	[descriptions] [nvarchar](250) NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Slide] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[value] [nvarchar](250) NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_dbo.SystemConfig] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[id] [nvarchar](20) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.UserGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/19/2021 6:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[groupID] [nvarchar](20) NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](20) NULL,
	[email] [nvarchar](50) NULL,
	[address] [nvarchar](100) NULL,
	[createDate] [datetime] NULL,
	[createBy] [nvarchar](100) NULL,
	[modifyDate] [datetime] NULL,
	[modifyBy] [nvarchar](100) NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([id], [content], [status]) 
VALUES (1, N'<p>Công ty CP Online Shop</p><p>Địa chỉ: Số 1 Quang Trung Hà Đông </p> <p>Điện thoại: 04 6523 5342</p>', 1)
SET IDENTITY_INSERT [dbo].[Contact] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (1, N'Trang chủ', N'/', 1, N'_blank', 1, 1)
INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (2, N'Giới thiệu', N'/gioi-thieu', 2, N'_self', 1, 1)
INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (3, N'Tin tức', N'/tin-tuc', 3, N'_self', 1, 1)
INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (4, N'Sản phẩm', N'/san-pham', 4, N'_self', 1, 1)
INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (6, N'Liên hệ', N'/lien-he', 5, N'_self', 1, 1)
INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (7, N'Đăng nhập', N'/dang-nhap', 1, N'_self', 1, 2)
INSERT [dbo].[Menu] ([id], [name], [link], [displayOrder], [target], [status], [typeID]) VALUES (9, N'Đăng ký', N'/dang-ky', 2, N'_self', 1, 2)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuType] ON 

INSERT [dbo].[MenuType] ([id], [name]) VALUES (1, N'Main menu')
INSERT [dbo].[MenuType] ([id], [name]) VALUES (2, N'Top menu')
SET IDENTITY_INSERT [dbo].[MenuType] OFF
SET IDENTITY_INSERT [dbo].[ProductsCategory] ON 

INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (1, N'Máy tính để bàn', N'may-tinh-de-ban', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (2, N'Máy tính xách tay', N'may-tinh-xach-tay', NULL, 1, NULL, CAST(N'2015-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (3, N'Phụ kiện', N'phu-kien', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (4, N'Phần mềm', N'phan-mem', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (5, N'Thể thao', N'the-thao', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (6, N'Thời trang', N'thoi-trang', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (7, N'Trang sức', N'trang-suc', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (8, N'Đồ nội thất', N'do-noi-that', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (9, N'Làm đẹp', N'lam-dep', NULL, 1, NULL, CAST(N'2020-08-26 19:20:32.210' AS DateTime), N'admin', NULL, NULL, NULL, 1, 0)
INSERT [dbo].[ProductsCategory] ([id], [name], [metaTitle], [parentID], [displayOrder], [seoTitle], [createDate], [createBy], [modifyDate], [modifyBy], [metaKeyword], [status], [showOnHome]) VALUES (10, N'Đồng Hồ', N'dong-ho', 1, 1, NULL, CAST(N'2020-09-05 00:25:30.690' AS DateTime), NULL, NULL, NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[ProductsCategory] OFF
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([id], [imageLocation], [displayOrder], [link], [descriptions], [createDate], [createBy], [modifyDate], [modifyBy], [status]) VALUES (1, N'/Design/client/images/slide-1-image.png', 1, N'/', NULL, CAST(N'2015-08-26 19:21:44.440' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([id], [imageLocation], [displayOrder], [link], [descriptions], [createDate], [createBy], [modifyDate], [modifyBy], [status]) VALUES (2, N'/Design/client/images/slide-2-image.jpg', 2, N'/', NULL, CAST(N'2015-08-26 19:22:01.173' AS DateTime), NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([id], [imageLocation], [displayOrder], [link], [descriptions], [createDate], [createBy], [modifyDate], [modifyBy], [status]) VALUES (3, N'/Design/client/images/slide-3-image.jpg', 2, N'/', NULL, CAST(N'2015-08-26 19:22:01.173' AS DateTime), NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Slide] OFF
INSERT [dbo].[UserGroup] ([id], [name]) VALUES (N'ADMIN', N'Adminitrator')
INSERT [dbo].[UserGroup] ([id], [name]) VALUES (N'MOD', N'Moderator')
INSERT [dbo].[UserGroup] ([id], [name]) VALUES (N'USER', N'User')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [userName], [password], [groupID], [name], [phone], [email], [address], [createDate], [createBy], [modifyDate], [modifyBy], [status]) 
VALUES (1, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'ADMIN', N'admin', NULL, N'admin@gmail.com', NULL, NULL, NULL, NULL, NULL, 1) -- 123456
SET IDENTITY_INSERT [dbo].[Users] OFF
