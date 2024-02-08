IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Barrio] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    [Estado] int NOT NULL,
    [FechaCreacion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [FlujoFondos] (
    [Id] int NOT NULL IDENTITY,
    [Ingresos] decimal(18,2) NOT NULL,
    [Pagos] decimal(18,2) NOT NULL,
    [SaldoFinal] decimal(18,2) NOT NULL,
    [FechaActualizacion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_FlujoFondos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Productos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Calibre] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [Estado] int NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Proveedores] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    [Estado] int NOT NULL,
    [FechaCreacion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Proveedores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [DeudaClientes] (
    [Id] int NOT NULL IDENTITY,
    [IdCliente] int NOT NULL,
    [Estado] int NOT NULL,
    [MontoDeuda] decimal(18,2) NOT NULL,
    [IdVenta] int NOT NULL,
    [CreacionDeuda] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DeudaClientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DeudaClientes_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [IngresoClientes] (
    [Id] int NOT NULL IDENTITY,
    [IdCliente] int NOT NULL,
    [Ingresos] decimal(18,2) NOT NULL,
    [MontoFinal] decimal(18,2) NOT NULL,
    [FechaIngreso] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_IngresoClientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IngresoClientes_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Ventas] (
    [Id] int NOT NULL IDENTITY,
    [IdCliente] int NOT NULL,
    [Estado] int NOT NULL,
    [MontoVentas] decimal(18,2) NOT NULL,
    [FechaVenta] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Ventas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Ventas_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PagoProveedores] (
    [Id] int NOT NULL IDENTITY,
    [IdProveedor] int NOT NULL,
    [Pagos] decimal(18,2) NOT NULL,
    [MontoFinal] decimal(18,2) NOT NULL,
    [FechaPago] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_PagoProveedores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PagoProveedores_Proveedores_IdProveedor] FOREIGN KEY ([IdProveedor]) REFERENCES [Proveedores] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrdenDeVentas] (
    [Id] int NOT NULL IDENTITY,
    [IdProducto] int NOT NULL,
    [IdVenta] int NOT NULL,
    [Cantidad] int NOT NULL,
    [FechaCreacion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_OrdenDeVentas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrdenDeVentas_Productos_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [Productos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrdenDeVentas_Ventas_IdVenta] FOREIGN KEY ([IdVenta]) REFERENCES [Ventas] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_DeudaClientes_IdCliente] ON [DeudaClientes] ([IdCliente]);
GO

CREATE INDEX [IX_IngresoClientes_IdCliente] ON [IngresoClientes] ([IdCliente]);
GO

CREATE INDEX [IX_OrdenDeVentas_IdProducto] ON [OrdenDeVentas] ([IdProducto]);
GO

CREATE INDEX [IX_OrdenDeVentas_IdVenta] ON [OrdenDeVentas] ([IdVenta]);
GO

CREATE INDEX [IX_PagoProveedores_IdProveedor] ON [PagoProveedores] ([IdProveedor]);
GO

CREATE INDEX [IX_Ventas_IdCliente] ON [Ventas] ([IdCliente]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240207225358_mig1', N'6.0.26');
GO

COMMIT;
GO

