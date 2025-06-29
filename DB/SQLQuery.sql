USE [UAI-Food]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 29/6/2025 16:14:43 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/6/2025 16:14:43 ******/
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
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GET_USUARIO_ID]    Script Date: 29/6/2025 16:14:43 ******/
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
/****** Object:  StoredProcedure [dbo].[GUARDAR_PEDIDO]    Script Date: 29/6/2025 16:14:43 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PEDIDOS]    Script Date: 29/6/2025 16:14:43 ******/
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
/****** Object:  StoredProcedure [dbo].[LISTAR_PEDIDOS_POR_USUARIO]    Script Date: 29/6/2025 16:14:43 ******/
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
/****** Object:  StoredProcedure [dbo].[VALIDAR_USUARIO]    Script Date: 29/6/2025 16:14:43 ******/
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
