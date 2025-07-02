USE [UAI-Food]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ComboDescripcion] [nvarchar](255) NOT NULL,
	[Agregados] [nvarchar](500) NULL,
	[Fecha] [datetime] NOT NULL,
	[CostoTotal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[esAgregado] [bit] NOT NULL,
	[Precio] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductosPedido]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductosPedido](
	[ProductoId] [int] NOT NULL,
	[PedidoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC,
	[PedidoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (1, N'Combo Basico', 0, 200)
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (2, N'Combo Especial', 0, 300)
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (3, N'ComboFamiliar', 0, 400)
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (4, N'Papa', 1, 50)
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (5, N'Queso', 1, 15)
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (6, N'Tomate', 1, 24)
GO
INSERT [dbo].[Productos] ([Id], [Nombre], [esAgregado], [Precio]) VALUES (7, N'Carne', 1, 36)
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Descripcion], [Password]) VALUES (1, N'test', N'test')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[ProductosPedido]  WITH CHECK ADD FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[ProductosPedido]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GET_AGREGADOS]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_AGREGADOS]
AS
BEGIN
    SELECT 
        p.Id AS ProductoId,
        p.Nombre,
        p.precio,
		p.esAgregado
    FROM 
        [UAI-Food].[dbo].[Productos] as p
    WHERE 
        p.esAgregado = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[GET_ALL_PRODUCTOS]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ALL_PRODUCTOS]
AS
BEGIN
    SELECT 
        p.Id AS ProductoId,
        p.Nombre,
        p.precio,
		p.esAgregado
    FROM 
        Productos as p
END;
GO
/****** Object:  StoredProcedure [dbo].[GET_COMBOS]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_COMBOS]
AS
BEGIN
    SELECT 
        p.Id AS ProductoId,
        p.Nombre,
        p.precio,
		p.esAgregado
    FROM 
        [UAI-Food].[dbo].[Productos] as p
    WHERE 
        p.esAgregado = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[GET_USUARIO_ID]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_USUARIO_ID]
	@NombreUsuario VARCHAR(100)
AS
	BEGIN
	SELECT TOP (1) [Id] FROM Usuario
	WHERE Usuario.Descripcion = @NombreUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[GUARDAR_PEDIDO]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GUARDAR_PEDIDO]
    @UsuarioId INT,
    @ComboDescripcion NVARCHAR(255),
    @Agregados NVARCHAR(500),
    @Fecha DATETIME,
    @CostoTotal INT
AS
BEGIN
    INSERT INTO Pedido (UsuarioId, ComboDescripcion, Agregados, Fecha, CostoTotal)
    VALUES (@UsuarioId, @ComboDescripcion, @Agregados, @Fecha, @CostoTotal);
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PEDIDOS]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_PEDIDOS]
AS
BEGIN
    SELECT 
        P.Id,
        P.UsuarioId,
        U.Descripcion AS UsuarioDescripcion,
        P.ComboDescripcion,
        P.Agregados,
        P.Fecha,
        P.CostoTotal
    FROM Pedido P
    INNER JOIN Usuario U ON P.UsuarioId = U.Id
    ORDER BY P.Fecha DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_PEDIDOS_POR_USUARIO]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_PEDIDOS_POR_USUARIO]
    @UsuarioId INT
AS
BEGIN
    SELECT 
        P.Id,
        P.UsuarioId,
        U.Descripcion AS UsuarioDescripcion,
        P.ComboDescripcion,
        P.Agregados,
        P.Fecha,
        P.CostoTotal
    FROM Pedido P
    INNER JOIN Usuario U ON P.UsuarioId = U.Id
    WHERE P.UsuarioId = @UsuarioId
    ORDER BY P.Fecha DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[VALIDAR_USUARIO]    Script Date: 7/2/2025 4:58:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VALIDAR_USUARIO]
    @UserName NVARCHAR(100),
    @Password NVARCHAR(255)
AS
BEGIN
    SELECT COUNT(1)
    FROM [Usuario]
    WHERE Descripcion = @UserName AND Password = @Password
END
GO
