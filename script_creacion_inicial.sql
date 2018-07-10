--Esquema
USE [GD1C2018]
GO
--CREATE SCHEMA [LA_QUERY_DE_PAPEL] 
GO



CREATE TABLE [LA_QUERY_DE_PAPEL].[Rol] ( 
	Id_Rol INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Persona] ( 
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Telefono nvarchar(50),
	Habilitado bit DEFAULT 1 NOT NULL,
	
	PRIMARY KEY (Tipo_Documento, Nro_Documento),	
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Persona_conflicto_migracion] ( 
	id_persona_conflicto INT PRIMARY KEY IDENTITY (1,1),
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Telefono nvarchar(50),
	Mail nvarchar(255),
	Nacionalidad nvarchar(255)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Usuario] ( 
	Id_Usuario INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Username nvarchar(255) NOT NULL UNIQUE,
	Password varbinary(255) NOT NULL,	
	Id_Rol INT NOT NULL,
	Cant_fallos INT DEFAULT 0 NOT NULL,
	Mail nvarchar(255) NOT NULL,
	login_habilitado bit DEFAULT 1 NOT NULL,

	FOREIGN KEY (Tipo_Documento, Nro_Documento) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento) ON UPDATE CASCADE,
	FOREIGN KEY (Id_Rol) REFERENCES [LA_QUERY_DE_PAPEL].[Rol] (Id_Rol)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Cliente] ( 
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Localidad nvarchar(255),
	Mail nvarchar(255) UNIQUE,
	Nacionalidad nvarchar(255) NOT NULL,

	PRIMARY KEY (Tipo_Documento, Nro_Documento),
	FOREIGN KEY (Tipo_Documento, Nro_Documento) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento) ON UPDATE CASCADE,
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Cliente_Conflicto_Migracion] ( 
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Localidad nvarchar(255),
	Mail nvarchar(255),
	Nacionalidad nvarchar(255) NOT NULL,

	PRIMARY KEY (Tipo_Documento, Nro_Documento),
	FOREIGN KEY (Tipo_Documento, Nro_Documento) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento) ON UPDATE CASCADE,
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Hotel] ( 
	Id_Hotel INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Mail nvarchar(255),
	Telefono nvarchar(50),
	Direccion nvarchar(255) NOT NULL,
	Cant_Estrellas INT NOT NULL,
	Recarga_Estrella INT NOT NULL,
	Ciudad nvarchar(255) NOT NULL,
	Pais nvarchar(255) NOT NULL,
	Fecha_Creacion datetime
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Hotel_Baja](
    Id_Baja INT  PRIMARY KEY IDENTITY(1,1),
    Id_Hotel INT NOT NULL,
    Fecha_inicio datetime NOT NULL,
    Fecha_fin datetime NOT NULL,
	Descripcion nvarchar(255),

	FOREIGN KEY (Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Hotel] (Id_Hotel)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Tipo_Habitacion](
	Id_tipo INT PRIMARY KEY,
	Descripcion nvarchar(255), 
	Porcentual numeric(18,2)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Habitacion](
    Nro_Habitacion INT,
    Id_Hotel INT NOT NULL,
	Piso INT NOT NULL,
    Ubicacion nvarchar(255),
    Tipo_Hab INT,
	Descripcion nvarchar(255),
	Habilitada bit NOT NULL DEFAULT 1,

	FOREIGN KEY (Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Hotel] (Id_Hotel),
	FOREIGN KEY (Tipo_Hab) REFERENCES [LA_QUERY_DE_PAPEL].[Tipo_Habitacion] (Id_tipo),
	PRIMARY KEY (Nro_Habitacion, Id_Hotel)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Regimen] ( 
	Id_Regimen INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL,
	);	
	
CREATE TABLE[LA_QUERY_DE_PAPEL].[RegimenxHotel] ( 
	Id_Hotel INT NOT NULL,
	Id_Regimen INT NOT NULL,
	
	PRIMARY KEY (Id_Hotel, Id_Regimen),
	FOREIGN KEY (Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Hotel] (Id_Hotel),
	FOREIGN KEY (Id_Regimen) REFERENCES [LA_QUERY_DE_PAPEL].[Regimen] (Id_Regimen)
	);	

CREATE TABLE [LA_QUERY_DE_PAPEL].[Reserva] ( 
	Id_Reserva INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Id_Regimen INT NOT NULL,
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches INT NOT NULL,
	Fecha_Inicio datetime,
	Fecha_Fin datetime,	
	Estado VARCHAR(255) NOT NULL,
	Tipo_Documento VARCHAR(20) NOT NULL,
	Nro_Documento INT NOT NULL, 

	FOREIGN KEY (Id_Regimen) REFERENCES [LA_QUERY_DE_PAPEL].[Regimen] (Id_Regimen),
	FOREIGN KEY (Tipo_Documento, Nro_Documento) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Reserva_Conflicto_Migracion] ( 
	Id_Reserva INT NOT NULL PRIMARY KEY,
	Id_Regimen INT NOT NULL REFERENCES [LA_QUERY_DE_PAPEL].[Regimen] (Id_Regimen),
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches INT NOT NULL,
	Fecha_Inicio datetime,
	Fecha_Fin datetime,	
	Estado VARCHAR(255) NOT NULL,
	Tipo_Documento VARCHAR(20) NOT NULL,
	Nro_Documento INT NOT NULL, 
	Id_Persona_Conflicto INT REFERENCES [LA_QUERY_DE_PAPEL].[Persona_conflicto_migracion] (id_persona_conflicto)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[ReservaxHabitacion] (
	Id_Reserva INT NOT NULL,
	Nro_Habitacion INT NOT NULL,
	Id_Hotel INT NOT NULL,
	
	PRIMARY KEY (Id_Reserva, Nro_Habitacion, Id_Hotel),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Reserva] (Id_Reserva),
	FOREIGN KEY (Nro_Habitacion, Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Habitacion] (Nro_Habitacion, Id_Hotel)
	);


CREATE TABLE [LA_QUERY_DE_PAPEL].[ReservaxHabitacion_Conflicto_Migracion] (
	Id_Reserva INT NOT NULL,
	Id_Hotel INT NOT NULL,
	Nro_Habitacion INT NOT NULL,
	
	PRIMARY KEY (Id_Reserva, Id_Hotel, Nro_Habitacion),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Reserva_Conflicto_Migracion],
	FOREIGN KEY (Nro_Habitacion, Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Habitacion] (Nro_Habitacion, Id_Hotel)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Historial_Reserva] (
	Id_Reserva INT NOT NULL REFERENCES [LA_QUERY_DE_PAPEL].[Reserva] (Id_Reserva),
	Tipo nvarchar(255) NOT NULL,
	Fecha datetime NOT NULL,
	Id_Usuario INT NOT NULL REFERENCES [LA_QUERY_DE_PAPEL].[Usuario] (Id_Usuario)
);

CREATE TABLE [LA_QUERY_DE_PAPEL].[UsuarioxHotel] ( 
	Id_Hotel INT NOT NULL,
	Id_Usuario INT NOT NULL,

	PRIMARY KEY (Id_Hotel, Id_Usuario),
	FOREIGN KEY (Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].Hotel (Id_Hotel),
	FOREIGN KEY (Id_Usuario) REFERENCES [LA_QUERY_DE_PAPEL].[Usuario] (Id_Usuario)
	);
	
CREATE TABLE [LA_QUERY_DE_PAPEL].[Consumible] ( 
	Id_Consumible INT  NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL
	);	


CREATE TABLE [LA_QUERY_DE_PAPEL].[Estadia](
	Id_Reserva INT NOT NULL PRIMARY KEY,
	Fecha_ingreso datetime ,
	Usuario_ingreso_id int,
	Fecha_egreso datetime ,
	Usuario_egreso_id int, 

	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Reserva] (Id_Reserva), 
	FOREIGN KEY (Usuario_ingreso_id) REFERENCES [LA_QUERY_DE_PAPEL].[Usuario] (Id_Usuario),
	FOREIGN KEY (Usuario_egreso_id) REFERENCES [LA_QUERY_DE_PAPEL].[Usuario] (Id_Usuario)
	
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Estadia_conflicto_migracion](
	Id_Reserva INT NOT NULL PRIMARY KEY,
	Fecha_ingreso datetime ,
	Fecha_egreso datetime ,

	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Reserva_conflicto_migracion] (Id_Reserva)
	);


CREATE TABLE [LA_QUERY_DE_PAPEL].[MedioPago] ( 
	Id_medio_pago INT NOT NULL PRIMARY KEY,
	Desc_medio_pago nvarchar(50) NOT NULL
	);	

CREATE TABLE [LA_QUERY_DE_PAPEL].[Factura] ( 
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Id_Reserva INT NOT NULL,
	Tipo_Documento_Cliente varchar(20) NOT NULL,
	Nro_Documento_Cliente INT NOT NULL,
	Fecha_Emision datetime NOT NULL,
	Total_Factura numeric(18,2),
	Forma_Pago nvarchar(50) NOT NULL,
	
	FOREIGN KEY (Tipo_Documento_Cliente, Nro_Documento_Cliente) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Estadia] (Id_Reserva),

	);
	

CREATE TABLE [LA_QUERY_DE_PAPEL].[Factura_Conflicto_Migracion] ( 
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Id_Reserva INT NOT NULL,
	Tipo_Documento_Cliente varchar(20) NOT NULL,
	Nro_Documento_Cliente INT NOT NULL,
	Fecha_Emision datetime NOT NULL,
	Total_Factura numeric(18,2),
	Forma_Pago nvarchar(50) NOT NULL,
	Id_Persona INT,
	
	FOREIGN KEY (Id_Persona) REFERENCES [LA_QUERY_DE_PAPEL].[Persona_Conflicto_Migracion] (Id_Persona_Conflicto),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Estadia_Conflicto_Migracion] (Id_Reserva),

	);


CREATE TABLE [LA_QUERY_DE_PAPEL].[Funcionalidad] ( 
	Id_Funcion INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL
	);	


CREATE TABLE [LA_QUERY_DE_PAPEL].[FuncionalidadxRol] ( 
	Id_Rol INT NOT NULL,
	Id_Funcion INT NOT NULL,

	PRIMARY KEY (Id_Rol, Id_Funcion),
	FOREIGN KEY (Id_Funcion) REFERENCES [LA_QUERY_DE_PAPEL].[Funcionalidad] (Id_Funcion),
	FOREIGN KEY (Id_Rol) REFERENCES [LA_QUERY_DE_PAPEL].[Rol] (Id_Rol)
	);
	--Conviene crear otra entidad Forma de Pago con id y descripcion??
	--

CREATE TABLE [LA_QUERY_DE_PAPEL].[Consumible_estadia] (
	Id_Reserva INT NOT NULL ,
	Id_Consumible INT NOT NULL ,
	cantidad INT

	PRIMARY KEY (Id_Reserva,Id_Consumible),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Estadia] (Id_Reserva),
	FOREIGN KEY (Id_Consumible) REFERENCES [LA_QUERY_DE_PAPEL].[Consumible] (Id_Consumible),

	);


CREATE TABLE [LA_QUERY_DE_PAPEL].[Consumible_estadia_Conflicto_Migracion] (
	Id_Reserva INT NOT NULL ,
	Id_Consumible INT NOT NULL ,
	cantidad INT

	PRIMARY KEY (Id_Reserva,Id_Consumible),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].Estadia_Conflicto_Migracion (Id_Reserva),
	FOREIGN KEY (Id_Consumible) REFERENCES [LA_QUERY_DE_PAPEL].[Consumible] (Id_Consumible)
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Item] ( 
	Nro_Factura numeric(18) NOT NULL,
	Id_Reserva INT NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	Precio NUMERIC (18,2) NOT NULL DEFAULT 0.0,
	Cantidad INT NOT NULL,
	
	
	FOREIGN KEY (Nro_Factura) REFERENCES [LA_QUERY_DE_PAPEL].[Factura] (Nro_Factura),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Estadia] (Id_Reserva)

	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Item_Conflicto_Migracion] ( 
	Nro_Factura numeric(18) NOT NULL,
	Id_Reserva INT NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
	Precio NUMERIC (18,2) NOT NULL DEFAULT 0.0,
	Cantidad INT NOT NULL,
	
	
	FOREIGN KEY (Nro_Factura) REFERENCES [LA_QUERY_DE_PAPEL].[Factura_Conflicto_Migracion] (Nro_Factura),
	FOREIGN KEY (Id_Reserva) REFERENCES [LA_QUERY_DE_PAPEL].[Estadia_Conflicto_Migracion] (Id_Reserva)

	);

GO

--Indices

CREATE INDEX Nro_Doc_index ON LA_QUERY_DE_PAPEL.Persona (Nro_Documento);
CREATE INDEX Apellido_index ON LA_QUERY_DE_PAPEL.Persona (Apellido);
CREATE INDEX Nombre_index ON LA_QUERY_DE_PAPEL.Persona (Nombre);
CREATE INDEX Ciudad_Hotel_index ON LA_QUERY_DE_PAPEL.Hotel (Ciudad);
CREATE INDEX Direccion_Hotel_index ON LA_QUERY_DE_PAPEL.Hotel (Direccion);



INSERT INTO LA_QUERY_DE_PAPEL.Rol (Nombre)
VALUES ('Administrador General'), ('Guest')

INSERT INTO LA_QUERY_DE_PAPEL.Funcionalidad (Descripcion)
VALUES ('ABM de rol'), ('ABM de usuario'), ('ABM de hotel'), ('ABM de cliente'), ('ABM de habitacion'), ('Generar o modificar reserva'), ('Cancelar reserva'), ('Listado estadistico')

INSERT INTO LA_QUERY_DE_PAPEL.FuncionalidadxRol(Id_Rol, Id_Funcion)
VALUES (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1,8), (2,6), (2, 7)

INSERT INTO LA_QUERY_DE_PAPEL.Persona (Tipo_Documento, Nro_Documento, Apellido, Nombre,	Direccion, Fecha_Nacimiento, Telefono, Habilitado)
VALUES ('DNI', 1, '', '', '', GETDATE(), '', 1)

INSERT INTO LA_QUERY_DE_PAPEL.Usuario (Tipo_Documento, Nro_Documento, Username,	Password, Id_Rol, Mail)
VALUES ('DNI', 1, 'admin', CONVERT(varbinary(255),HASHBYTES('SHA2_256','w23e'),2), 1, ''), ('DNI', 1, 'guest', HASHBYTES('SHA2_256',''), 2, '')

INSERT INTO LA_QUERY_DE_PAPEL.MedioPago(Id_medio_pago, Desc_medio_pago)
VALUES (1, 'Efectivo'), (2, 'Tarjeta de Crédito')
GO

--baja logica del rol
CREATE TRIGGER LA_QUERY_DE_PAPEL.deleteRol ON LA_QUERY_DE_PAPEL.Rol
INSTEAD OF DELETE
AS
BEGIN
UPDATE LA_QUERY_DE_PAPEL.Rol
	SET Habilitado = 0
	WHERE LA_QUERY_DE_PAPEL.Rol.Id_Rol IN (SELECT Id_Rol FROM deleted)
END
GO

--para usar en el abm de usuarios
CREATE VIEW LA_QUERY_DE_PAPEL.usuarios
AS
SELECT Id_Usuario, Username, Password, Id_Rol, Nombre, Apellido, P.Tipo_Documento, P.Nro_Documento, Mail, Telefono, Direccion, Fecha_Nacimiento, Habilitado
FROM LA_QUERY_DE_PAPEL.Persona P
	JOIN LA_QUERY_DE_PAPEL.Usuario U
	ON P.Tipo_Documento = U.Tipo_Documento
		AND P.Nro_Documento = U.Nro_Documento
GO

--triggers para poder hacer insert, delete y update en la view de usuarios y validar el username
CREATE TRIGGER LA_QUERY_DE_PAPEL.insertUsuarios ON LA_QUERY_DE_PAPEL.usuarios
INSTEAD OF INSERT
AS
BEGIN
BEGIN TRY
	INSERT INTO LA_QUERY_DE_PAPEL.Persona (Tipo_Documento, Nro_Documento, Apellido, Nombre, Direccion, Fecha_Nacimiento, Telefono, Habilitado)
		SELECT i.Tipo_Documento, i.Nro_Documento, i.Apellido, i.Nombre, i.Direccion, i.Fecha_Nacimiento, i.Telefono, i.Habilitado
		FROM inserted i

	INSERT INTO LA_QUERY_DE_PAPEL.Usuario (Tipo_Documento, Nro_Documento, Username, Password, Id_Rol, Mail)
		SELECT i.Tipo_Documento, i.Nro_Documento, i.Username, i.Password, i.Id_Rol, i.Mail
		FROM inserted i
END TRY

BEGIN CATCH
	RAISERROR('El username ya esta en uso', 16, 1)
END CATCH
END
GO

CREATE TRIGGER LA_QUERY_DE_PAPEL.deleteUsuarios ON LA_QUERY_DE_PAPEL.usuarios
INSTEAD OF DELETE
AS
BEGIN
DELETE p FROM LA_QUERY_DE_PAPEL.Persona p
	JOIN deleted d
		ON p.Tipo_Documento = d.Tipo_Documento
			AND p.Nro_Documento = d.Nro_Documento
END
GO

CREATE TRIGGER LA_QUERY_DE_PAPEL.updateUsuarios ON LA_QUERY_DE_PAPEL.usuarios
INSTEAD OF UPDATE
AS
BEGIN
BEGIN TRY
	UPDATE LA_QUERY_DE_PAPEL.Persona
		SET Tipo_Documento = i.Tipo_Documento, Nro_Documento = i.Nro_Documento, Apellido = i.Apellido, Nombre = i.Nombre, Direccion = i.Direccion,
			Fecha_Nacimiento = i.Fecha_Nacimiento, Telefono = i.Telefono, Habilitado = i.Habilitado
		FROM inserted i
		WHERE LA_QUERY_DE_PAPEL.Persona.Tipo_Documento IN (SELECT Tipo_Documento FROM deleted) AND LA_QUERY_DE_PAPEL.Persona.Nro_Documento IN (SELECT Nro_Documento FROM deleted)

	UPDATE LA_QUERY_DE_PAPEL.Usuario
		SET Username = i.Username, Password = i.Password, Id_Rol = i.Id_Rol, Mail = i.Mail
		FROM inserted i
		WHERE LA_QUERY_DE_PAPEL.Usuario.Username IN (SELECT Username FROM deleted)
END TRY

BEGIN CATCH
	RAISERROR('El username ya esta en uso', 16, 1)
END CATCH
END
GO

--para usar en el abm de clientes
CREATE VIEW LA_QUERY_DE_PAPEL.clientes
AS
SELECT Nombre, Apellido, p.Tipo_Documento, p.Nro_Documento, Mail, Telefono, Direccion, Localidad, Nacionalidad, Fecha_Nacimiento, Habilitado
FROM LA_QUERY_DE_PAPEL.Persona p
	JOIN LA_QUERY_DE_PAPEL.Cliente c
	ON p.Tipo_Documento = c.Tipo_Documento
		AND p.Nro_Documento = c.Nro_Documento
GO

--triggers para poder hacer insert y delete en la view de clientes y validar el mail
CREATE TRIGGER LA_QUERY_DE_PAPEL.insertClientes ON LA_QUERY_DE_PAPEL.clientes
INSTEAD OF INSERT
AS
BEGIN
BEGIN TRY
	INSERT INTO LA_QUERY_DE_PAPEL.Persona (Tipo_Documento, Nro_Documento, Apellido, Nombre, Direccion, Fecha_Nacimiento, Telefono, Habilitado)
		SELECT i.Tipo_Documento, i.Nro_Documento, i.Apellido, i.Nombre, i.Direccion, i.Fecha_Nacimiento, i.Telefono, i.Habilitado
		FROM inserted i

	INSERT INTO LA_QUERY_DE_PAPEL.Cliente (Tipo_Documento, Nro_Documento, Localidad, Mail, Nacionalidad)
		SELECT i.Tipo_Documento, i.Nro_Documento, i.Localidad, i.Mail, i.Nacionalidad
		FROM inserted i
END TRY

BEGIN CATCH
	RAISERROR('El mail ya esta en uso', 16, 1)
END CATCH
END
GO

CREATE TRIGGER LA_QUERY_DE_PAPEL.deleteClientes ON LA_QUERY_DE_PAPEL.clientes
INSTEAD OF DELETE
AS
BEGIN
DELETE p FROM LA_QUERY_DE_PAPEL.Persona p
	JOIN deleted d
		ON p.Tipo_Documento = d.Tipo_Documento
			AND p.Nro_Documento = d.Nro_Documento
END
GO

--procedure para actualizar un cliente
CREATE PROCEDURE LA_QUERY_DE_PAPEL.procedure_update_cliente
	@nombre nvarchar(255),
	@apellido nvarchar(255),
	@tipoDoc varchar(20),
	@nroDoc int,
	@mail nvarchar(255),
	@telefono nvarchar(50),
	@direccion nvarchar(255),
	@localidad nvarchar(255),
	@nacionalidad nvarchar(255),
	@fechaNac datetime,
	@habilitado bit,
	@tipoDocOriginal varchar(20),
	@nroDocOriginal int
AS
BEGIN
	DECLARE @mailOriginal nvarchar(255)
	SELECT @mailOriginal = Mail FROM LA_QUERY_DE_PAPEL.Cliente WHERE Tipo_Documento = @tipoDocOriginal AND Nro_Documento = @nroDocOriginal

	IF(@mail <> @mailOriginal AND EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Cliente WHERE Mail = @mail AND Tipo_Documento <> @tipoDocOriginal AND Nro_Documento <> @nroDocOriginal))
	BEGIN
		RAISERROR('El mail ya esta en uso', 16, 1)
		RETURN
	END

	IF(@tipoDoc <> @tipoDocOriginal AND @nroDoc <> @nroDocOriginal AND EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Cliente WHERE Tipo_Documento = @tipoDoc AND Nro_Documento = @nroDoc)
		OR @tipoDoc <> @tipoDocOriginal AND EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Cliente WHERE Tipo_Documento = @tipoDoc AND Nro_Documento = @nroDocOriginal)
		OR @nroDoc <> @nroDocOriginal AND EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Cliente WHERE Tipo_Documento = @tipoDocOriginal AND Nro_Documento = @nroDoc))
	BEGIN
		RAISERROR('El tipo y numero de documento ya estan en uso', 16, 1)
		RETURN
	END

	UPDATE LA_QUERY_DE_PAPEL.Persona
		SET Tipo_Documento = @tipoDoc, Nro_Documento = @nroDoc, Apellido = @apellido, Nombre = @nombre, Direccion = @direccion,
			Fecha_Nacimiento = @fechaNac, Telefono = @telefono, Habilitado = @habilitado
		WHERE Tipo_Documento = @tipoDocOriginal AND Nro_Documento = @nroDocOriginal

	UPDATE LA_QUERY_DE_PAPEL.Cliente
		SET Localidad = @localidad, Mail = @mail, Nacionalidad = @nacionalidad
		WHERE Tipo_Documento = @tipoDoc AND Nro_Documento = @nroDoc
END
GO

--baja logica de una persona
CREATE TRIGGER LA_QUERY_DE_PAPEL.deletePersonas ON LA_QUERY_DE_PAPEL.Persona
INSTEAD OF DELETE
AS
BEGIN
UPDATE LA_QUERY_DE_PAPEL.Persona
	SET Habilitado = 0
	WHERE LA_QUERY_DE_PAPEL.Persona.Tipo_Documento IN (SELECT Tipo_Documento FROM deleted) AND LA_QUERY_DE_PAPEL.Persona.Nro_Documento IN (SELECT Nro_Documento FROM deleted)
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.procedure_alta_habitacion
	@nroHabitacion int,
	@idHotel int,
	@piso int,
	@ubicacion char,
	@idTipoHab int,
	@descripcion nvarchar(255),
	@habilitada bit
AS
BEGIN
	IF(EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Habitacion WHERE Nro_Habitacion = @nroHabitacion AND Id_Hotel = @idHotel))
	BEGIN
		RAISERROR('Ya existe el numero de habitacion en el hotel', 16, 1)
		RETURN
	END
		
	INSERT INTO LA_QUERY_DE_PAPEL.Habitacion(Nro_Habitacion, Id_Hotel, Piso, Ubicacion, Tipo_Hab, Descripcion, Habilitada)
	VALUES (@nroHabitacion, @idHotel, @piso, @ubicacion, @idTipoHab, @descripcion, @habilitada)
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.validar_regimen
	@idHotel int,
	@idRegimen int,
	@fechaActual datetime
AS
BEGIN
	DECLARE @descripcion nvarchar(255)
	DECLARE @error nvarchar (255)

	IF(EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva r
			   JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON r.Id_Reserva = rh.Id_Reserva
				WHERE rh.Id_Hotel = @idHotel AND r.Id_Regimen = @idRegimen
					AND r.Fecha_Inicio >= @fechaActual))
	BEGIN
		SELECT @descripcion = Descripcion FROM LA_QUERY_DE_PAPEL.Regimen WHERE Id_Regimen = @idRegimen
		SET @error = 'Existen reservas para el regimen ' + @descripcion
		RAISERROR (@error, 16, 1)
		RETURN
	END
	
	IF(EXISTS (SELECT 1 FROM LA_QUERY_DE_PAPEL.Estadia e
			   JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON e.Id_Reserva = rh.Id_Reserva
			   JOIN LA_QUERY_DE_PAPEL.Reserva r ON e.Id_Reserva = r.Id_Reserva
				WHERE rh.Id_Hotel = @idHotel AND r.Id_Regimen = @idRegimen
					AND e.Fecha_ingreso <= @fechaActual AND e.Fecha_egreso IS NULL))
	BEGIN
		SELECT @descripcion = Descripcion FROM LA_QUERY_DE_PAPEL.Regimen WHERE Id_Regimen = @idRegimen
		SET @error = 'Existen estadias para el regimen ' + @descripcion
		RAISERROR (@error, 16, 1)
		RETURN
	END
END
GO

CREATE VIEW LA_QUERY_DE_PAPEL.reservas_sin_cancelar
AS
	SELECT Id_Reserva, Id_Regimen, Fecha_Reserva, Cant_Noches, Fecha_Inicio, Fecha_Fin, Estado, Tipo_Documento, Nro_Documento
	FROM LA_QUERY_DE_PAPEL.Reserva
		WHERE UPPER(Estado) NOT LIKE '%CANCELADA%' 
GO

--verifico si existen reservas o estadias en el periodo que se quiere dar de baja el hotel
CREATE PROCEDURE LA_QUERY_DE_PAPEL.validar_baja_hotel
	@idHotel int,
	@fechaInicio datetime,
	@fechaFin datetime
AS
BEGIN
	IF(EXISTS(
		SELECT 1 FROM LA_QUERY_DE_PAPEL.reservas_sin_cancelar r
		JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON r.Id_Reserva = rh.Id_Reserva
			WHERE rh.Id_Hotel = @idHotel 
				AND(Fecha_Inicio BETWEEN @fechaInicio AND @fechaFin OR Fecha_Fin BETWEEN @fechaInicio AND @fechaFin OR Fecha_Inicio < @fechaInicio AND Fecha_Fin > @fechaFin)))
	BEGIN
		RAISERROR('Existen reservas en el periodo elegido', 16, 1)
		RETURN
	END

	IF(EXISTS(
		SELECT 1 FROM LA_QUERY_DE_PAPEL.Estadia e
		JOIN LA_QUERY_DE_PAPEL.Reserva r ON e.Id_Reserva = r.Id_Reserva
		JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON e.Id_Reserva = rh.Id_Reserva
			WHERE rh.Id_Hotel = @idHotel 
				AND e.Fecha_egreso IS NULL AND r.Fecha_Fin <= @fechaInicio))
	BEGIN
		RAISERROR('Existen estadias en el periodo elegido', 16, 1)
		RETURN
	END
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_activa
	@nroReserva int
AS
BEGIN
	IF(NOT EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva))
	BEGIN
		RAISERROR('El numero de reserva no existe', 16, 1)
		RETURN
	END
	
	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva AND UPPER(Estado) LIKE '%CANCELADA%'))
	BEGIN
		RAISERROR('La reserva fue cancelada', 16, 1)
		RETURN
	END

	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva AND UPPER(Estado) LIKE '%INGRESO%'))
	BEGIN
		RAISERROR('La reserva fue efectivizada', 16, 1)
		RETURN
	END
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_modificable
	@nroReserva int,
	@fechaActual datetime
AS
BEGIN
	EXEC LA_QUERY_DE_PAPEL.validar_reserva_activa @nroReserva

	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva AND Fecha_Inicio >= @fechaActual))
	BEGIN
		RAISERROR('La reserva no se puede modificar', 16, 1)
		RETURN
	END
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.actualizar_reserva
	@nroReserva int,
	@idRegimen int,
	@fechaDeModificacion datetime,
	@cantNoches int,
	@fechaInicio datetime,
	@fechaFin datetime,
	@idUsuario int
AS
BEGIN
	UPDATE LA_QUERY_DE_PAPEL.Reserva 
	SET Id_Regimen = @idRegimen, Cant_Noches = @cantNoches, Fecha_Inicio = @fechaInicio, Fecha_Fin = @fechaFin, Estado = 'Reserva modificada'
		WHERE Id_Reserva = @nroReserva

	INSERT INTO LA_QUERY_DE_PAPEL.Historial_Reserva (Id_Reserva, Id_Usuario, Tipo, Fecha)
	VALUES (@nroReserva, @idUsuario, 'Modificacion', @fechaDeModificacion)
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.cancelar_reserva
	@nroReserva int,
	@motivo nvarchar(242),
	@fechaCancelacion datetime,
	@idUsuario int
AS
BEGIN
	INSERT INTO LA_QUERY_DE_PAPEL.Historial_Reserva (Id_Reserva, Tipo, Fecha, Id_Usuario)
	VALUES (@nroReserva, 'Cancelada: ' + @motivo, @fechaCancelacion, @idUsuario)

	DECLARE @estado nvarchar(255) = 'Reserva cancelada por recepcion'
	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Usuario WHERE Id_Usuario = @idUsuario AND Username = 'guest'))
		SET @estado = 'Reserva cancelada por cliente'

	UPDATE LA_QUERY_DE_PAPEL.Reserva
		SET Estado = @estado
		WHERE Id_Reserva = @nroReserva
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_para_ingreso
	@nroReserva int,
	@fechaActual datetime,
	@idUsuario int
AS
BEGIN
	IF(NOT EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva))
	BEGIN
		RAISERROR('La reserva no existe', 16, 1)
		RETURN
	END

	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Estadia WHERE Id_Reserva = @nroReserva))
	BEGIN
		RAISERROR('Ya se realizo el ingreso de la reserva', 16, 1)
		RETURN
	END

	IF(NOT EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.reservas_sin_cancelar WHERE Id_Reserva = @nroReserva))
	BEGIN
		RAISERROR('La reserva se cancelo', 16, 1)
		RETURN
	END

	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva AND Fecha_Inicio > @fechaActual))
	BEGIN
		RAISERROR('Todavia no se puede registrar el ingreso', 16, 1)
		RETURN
	END

	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @nroReserva AND Fecha_Inicio < @fechaActual))
	BEGIN
		EXECUTE LA_QUERY_DE_PAPEL.cancelar_reserva @nroReserva, 'Ingreso fuera de termino', @fechaActual, @idUsuario
		RAISERROR('Ya paso la fecha de ingreso. La reserva fue cancelada', 16, 1)
		RETURN
	END
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.registrar_ingreso
	@nroReserva int,
	@idUsuario int,
	@fechaActual datetime
AS
BEGIN
	INSERT INTO LA_QUERY_DE_PAPEL.Estadia (Id_Reserva, Usuario_ingreso_id, Fecha_ingreso)
	VALUES (@nroReserva, @idUsuario, @fechaActual)

	UPDATE LA_QUERY_DE_PAPEL.Reserva
	SET Estado = 'Reserva con ingreso'
		WHERE Id_Reserva = @nroReserva
END
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.validar_reserva_para_egreso
	@nroReserva int,
	@fechaActual datetime,
	@idUsuario int
AS
BEGIN
	IF(NOT EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Estadia WHERE Id_Reserva = @nroReserva))
	BEGIN
		RAISERROR('La reserva no tiene registrada el ingreso', 16, 1)
		RETURN
	END

	IF(EXISTS(SELECT 1 FROM LA_QUERY_DE_PAPEL.Estadia WHERE Id_Reserva = @nroReserva AND Fecha_egreso IS NOT NULL))
	BEGIN
		RAISERROR('Ya se realizo el egreso de la reserva', 16, 1)
		RETURN
	END
END
GO

CREATE FUNCTION LA_QUERY_DE_PAPEL.habitaciones_libres (@idHotel int, @idRegimen int, @tipoHab nvarchar(255), @fechaDesde datetime, @fechaHasta datetime)
RETURNS TABLE
AS
	RETURN (
		SELECT  h.Nro_Habitacion, Piso, Ubicacion, th.Descripcion AS Tipo_Habitacion, h.Descripcion
		FROM LA_QUERY_DE_PAPEL.Habitacion h
			--LEFT JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion
            --LEFT JOIN LA_QUERY_DE_PAPEL.reservas_sin_cancelar r ON rha.Id_Reserva = r.Id_Reserva
			JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo
			JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel
				WHERE rho.Id_Hotel = @idHotel
					AND rho.Id_Regimen = @idRegimen
					AND h.Habilitada = 1 
					AND th.Descripcion LIKE @tipoHab
					AND h.Nro_Habitacion NOT IN ( 
						SELECT distinct Nro_Habitacion FROM LA_QUERY_DE_PAPEL.reservas_sin_cancelar r 
							JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON r.Id_Reserva = rh.Id_Reserva
								WHERE Id_Hotel = @idHotel
									AND Fecha_Inicio < @fechaHasta  AND Fecha_Fin > @fechaDesde)
	)
GO

CREATE FUNCTION LA_QUERY_DE_PAPEL.habitaciones_de_reserva (@nroReserva int)
RETURNS TABLE
AS
	RETURN (
		SELECT h.Nro_Habitacion, Piso, Ubicacion, th.Descripcion AS Tipo_Habitacion, h.Descripcion
		FROM LA_QUERY_DE_PAPEL.Habitacion h
			JOIN LA_QUERY_DE_PAPEL.Tipo_Habitacion th ON h.Tipo_Hab = th.Id_tipo
			JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rh ON h.Id_Hotel = rh.Id_Hotel AND h.Nro_Habitacion = rh.Nro_Habitacion
				WHERE rh.Id_Reserva = @nroReserva
	)
GO

CREATE FUNCTION LA_QUERY_DE_PAPEL.habitaciones_disponibles_para_reserva (@idHotel int, @idRegimen int, @tipoHab nvarchar(255), @fechaDesde datetime, @fechaHasta datetime, @nroReserva int)
RETURNS TABLE
AS
	RETURN (
		SELECT * FROM LA_QUERY_DE_PAPEL.habitaciones_libres(@idHotel, @idRegimen, @tipoHab, @fechaDesde, @fechaHasta)
		UNION
		SELECT * FROM LA_QUERY_DE_PAPEL.habitaciones_de_reserva(@nroReserva)
	)
GO

CREATE PROCEDURE LA_QUERY_DE_PAPEL.procedure_login
	@usuario nvarchar(20),
	@contrasenia varbinary(255)
AS
BEGIN

	DECLARE @pass varbinary(255), @intentos INT, @habilitado BIT

	SELECT @pass=Password, @intentos=Cant_fallos, @habilitado = login_habilitado
	FROM LA_QUERY_DE_PAPEL.Usuario
	WHERE Username = @usuario

	IF (@pass IS NULL) 
	BEGIN
		RAISERROR ('Usuario incorrecto', 16, 1)
		RETURN
	END

	IF (@habilitado = 0) 
	BEGIN
		RAISERROR ('Usuario inhabilitado', 16, 1)
		RETURN
	END

	IF (@pass <> @contrasenia) 
	BEGIN
		UPDATE LA_QUERY_DE_PAPEL.Usuario SET Cant_fallos = @intentos + 1
		WHERE Username = @usuario
		DECLARE @error varchar(100)= 'Contraseña incorrecta. Le quedan ' + str(2 - @intentos) + ' intentos'
		RAISERROR (@error, 16, 1)

		IF(@intentos = 2)
		BEGIN
			UPDATE LA_QUERY_DE_PAPEL.Usuario SET login_habilitado = 0
			WHERE Username = @usuario
		END
		RETURN
	END

	UPDATE LA_QUERY_DE_PAPEL.Usuario SET Cant_fallos = 0
	WHERE Username = @usuario

END
GO


/*
CREATE PROCEDURE LA_QUERY_DE_PAPEL.procedure_generar_reserva
	@descripcionRegimen nvarchar(255),
	@fechaDeReserva datetime,
	@fechaInicio datetime,
	@fechaFin datetime,
	@idUsuario int
AS
BEGIN
	DECLARE @idRegimen int
	SELECT @idRegimen = Id_Regimen FROM LA_QUERY_DE_PAPEL.Regimen WHERE Descripcion = @descripcionRegimen

	INSERT INTO LA_QUERY_DE_PAPEL.Reserva (Id_Regimen, Fecha_Reserva, Cant_Noches, Fecha_Inicio, Fecha_Fin, Estado, Tipo_Documento, Nro_Documento)
	VALUES (@idRegimen, @fechaDeReserva, DATEDIFF(day, @fechaInicio, @fechaFin), @fechaInicio, @fechaFin, 'Reserva correcta', )
END
GO
*/


CREATE PROCEDURE [LA_QUERY_DE_PAPEL].Cargar_Personas
AS
BEGIN

	DECLARE @Email VARCHAR(255), @Nombre VARCHAR(50), @Apellido VARCHAR(50), @Nro_pasaporte INT, @Calle VARCHAR(50), @Nro_Calle INT, @Piso INT, @Depto VARCHAR(5), @Fecha_Nacimiento DATETIME, @Direccion VARCHAR(250), @Nacionalidad VARCHAR(255)
			
	DECLARE cursor_personas CURSOR FOR
	SELECT DISTINCT Cliente_Mail, Cliente_Pasaporte_Nro, Cliente_Apellido, Cliente_Nombre, Cliente_Fecha_Nac, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, Cliente_Nacionalidad FROM gd_esquema.Maestra

	OPEN cursor_personas
	FETCH NEXT FROM cursor_personas INTO @Email, @Nro_pasaporte, @Apellido, @Nombre, @Fecha_Nacimiento, @Calle, @Nro_Calle, @Piso, @Depto, @Nacionalidad;
	

	WHILE (@@FETCH_STATUS = 0)
	BEGIN	

		SET @Direccion = @Calle + ' ' + CAST(@Nro_Calle AS VARCHAR) + ' Piso ' + CAST(@Piso AS VARCHAR) + ' Depto ' + @Depto

		IF NOT EXISTS(SELECT Nro_Documento FROM [LA_QUERY_DE_PAPEL].Persona WHERE @Nro_pasaporte = Nro_Documento)
		BEGIN

			INSERT INTO [LA_QUERY_DE_PAPEL].Persona 
				(Tipo_Documento, Nro_Documento, Apellido, Nombre, Direccion, Fecha_Nacimiento)
			VALUES ('Pasaporte', @Nro_pasaporte, @Apellido, @Nombre, @Direccion, @Fecha_Nacimiento);

			IF NOT EXISTS (SELECT Nro_Documento FROM LA_QUERY_DE_PAPEL.Cliente WHERE @Email = Mail)
			BEGIN

				INSERT INTO LA_QUERY_DE_PAPEL.Cliente
					(Tipo_Documento, Nro_Documento, Mail, Nacionalidad)
				VALUES ('Pasaporte', @Nro_pasaporte, @Email, @Nacionalidad);

			END

			ELSE
			BEGIN

				INSERT INTO LA_QUERY_DE_PAPEL.Cliente_Conflicto_Migracion
					(Tipo_Documento, Nro_Documento, Mail, Nacionalidad)
				VALUES ('Pasaporte', @Nro_pasaporte, @Email, @Nacionalidad);

			END

			FETCH NEXT FROM cursor_personas INTO @Email, @Nro_pasaporte, @Apellido, @Nombre, @Fecha_Nacimiento, @Calle, @Nro_Calle, @Piso, @Depto, @Nacionalidad;
		END

		ELSE
		BEGIN

			INSERT INTO [LA_QUERY_DE_PAPEL].[Persona_conflicto_migracion] 
				(Tipo_Documento, Nro_Documento, Apellido, Nombre, Direccion, Fecha_Nacimiento, Mail, Nacionalidad)
			VALUES ('Pasaporte', @Nro_pasaporte, @Apellido, @Nombre, @Direccion, @Fecha_Nacimiento, @Email, @Nacionalidad);

			FETCH NEXT FROM cursor_personas INTO @Email, @Nro_pasaporte, @Apellido, @Nombre, @Fecha_Nacimiento, @Calle, @Nro_Calle, @Piso, @Depto, @Nacionalidad;
		END
			
	END 
	CLOSE cursor_personas;
	DEALLOCATE cursor_personas;


END
GO



CREATE PROCEDURE [LA_QUERY_DE_PAPEL].Cargar_Reservas
AS
BEGIN

	DECLARE @Id_Reserva INT, @Fecha_Reserva DATETIME, @Cant_Noches INT, @Id_Regimen INT, @Regimen_Precio NUMERIC(18,2), @Regimen_Descripcion VARCHAR(255), @Tipo_Documento VARCHAR(20), @Nro_Documento INT,
			@Apellido_cliente VARCHAR(255), @Nombre_cliente VARCHAR(255), @id_hotel INT, @Nro_habitacion INT, @Direccion_hotel VARCHAR(255), @Hotel_ciudad VARCHAR(255), @Hotel_Calle VARCHAR(255), @Hotel_Nro_Calle NUMERIC(18,0), @Fecha_Fin DATETIME;

	SET @Tipo_Documento = 'Pasaporte';

	DECLARE cursor_reservas CURSOR FOR
	SELECT DISTINCT Cliente_Pasaporte_Nro, Cliente_Apellido, Cliente_Nombre, Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Regimen_Precio, Regimen_Descripcion, Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Habitacion_Numero FROM gd_esquema.Maestra;

	OPEN cursor_reservas
	FETCH NEXT FROM cursor_reservas INTO @Nro_Documento, @Apellido_cliente, @Nombre_cliente, @Id_Reserva, @Fecha_Reserva, @Cant_Noches, @Regimen_Precio, @Regimen_Descripcion, @Hotel_Ciudad, @Hotel_Calle, @Hotel_Nro_Calle, @Nro_habitacion;



	WHILE (@@FETCH_STATUS = 0)
	BEGIN	

		SET @Id_Regimen = (SELECT TOP 1 id_regimen FROM LA_QUERY_DE_PAPEL.Regimen WHERE Descripcion = @Regimen_Descripcion AND Precio = @Regimen_Precio);
		SET @Direccion_hotel = @Hotel_Calle + ' ' + CAST(@Hotel_Nro_Calle AS VARCHAR);
		SET @id_hotel = (SELECT TOP 1 Id_Hotel FROM [LA_QUERY_DE_PAPEL].[Hotel] WHERE Ciudad = @Hotel_Ciudad AND Direccion = @Direccion_hotel)
		SET @Fecha_Fin = DATEADD (DAY, @Cant_Noches, @Fecha_Reserva);

		IF EXISTS(SELECT Nro_Documento FROM [LA_QUERY_DE_PAPEL].Persona WHERE @Nro_Documento = Nro_Documento AND @Apellido_cliente = Apellido AND @Nombre_cliente = Nombre)
		BEGIN

			SET IDENTITY_INSERT [LA_QUERY_DE_PAPEL].Reserva ON

			INSERT INTO [LA_QUERY_DE_PAPEL].Reserva (Id_Reserva, Fecha_Reserva, Cant_Noches, Id_Regimen, Tipo_Documento, Nro_Documento, Estado, Fecha_Inicio, Fecha_Fin)
			VALUES(@Id_Reserva, @Fecha_Reserva, @Cant_Noches, @Id_Regimen, @Tipo_Documento, @Nro_Documento, 'Reserva con ingreso', @Fecha_Reserva, @Fecha_Fin)

			SET IDENTITY_INSERT [LA_QUERY_DE_PAPEL].Reserva OFF

			
			INSERT INTO [LA_QUERY_DE_PAPEL].[ReservaxHabitacion] (Id_Reserva, Id_Hotel, Nro_Habitacion)
			VALUES(@Id_Reserva, @id_hotel, @Nro_habitacion)

			FETCH NEXT FROM cursor_reservas INTO @Nro_Documento, @Apellido_cliente, @Nombre_cliente, @Id_Reserva, @Fecha_Reserva, @Cant_Noches, @Regimen_Precio, @Regimen_Descripcion, @Hotel_Ciudad, @Hotel_Calle, @Hotel_Nro_Calle, @Nro_habitacion;
		END

		ELSE
		BEGIN
			INSERT INTO [LA_QUERY_DE_PAPEL].Reserva_Conflicto_Migracion (Id_Reserva, Fecha_Reserva, Cant_Noches, Id_Regimen, Tipo_Documento, Nro_Documento, Estado, Fecha_Inicio, Fecha_Fin, Id_Persona_Conflicto)
			VALUES(@Id_Reserva, @Fecha_Reserva, @Cant_Noches, @Id_Regimen, @Tipo_Documento, @Nro_Documento, 'Reserva con ingreso', @Fecha_Reserva, @Fecha_Fin,
				(SELECT id_persona_conflicto FROM LA_QUERY_DE_PAPEL.Persona_conflicto_migracion WHERE @Nro_Documento = Nro_Documento AND @Apellido_cliente = Apellido AND @Nombre_cliente = Nombre)
				)

			INSERT INTO  [LA_QUERY_DE_PAPEL].[ReservaxHabitacion_Conflicto_Migracion]  (Id_Reserva, Id_Hotel, Nro_Habitacion)
			VALUES(@Id_Reserva, @id_hotel, @Nro_habitacion)

			FETCH NEXT FROM cursor_reservas INTO @Nro_Documento, @Apellido_cliente, @Nombre_cliente, @Id_Reserva, @Fecha_Reserva, @Cant_Noches, @Regimen_Precio, @Regimen_Descripcion, @Hotel_Ciudad, @Hotel_Calle, @Hotel_Nro_Calle, @Nro_habitacion;
		END
			
	END 
	CLOSE cursor_reservas;
	DEALLOCATE cursor_reservas;

END
GO


CREATE PROCEDURE [LA_QUERY_DE_PAPEL].Cargar_Estadias
AS
BEGIN

	
	DECLARE @Id_Reserva INT, @Fecha_Ingreso DATETIME, @Cant_Noches INT, @Fecha_Egreso DATETIME;


	DECLARE cursor_estadias CURSOR FOR
	SELECT DISTINCT Reserva_Codigo, Estadia_Fecha_Inicio, Estadia_Cant_Noches FROM gd_esquema.Maestra WHERE Estadia_Fecha_Inicio IS NOT NULL;

	OPEN cursor_estadias
	FETCH NEXT FROM cursor_estadias INTO @Id_Reserva, @Fecha_Ingreso, @Cant_Noches;


	WHILE (@@FETCH_STATUS = 0)
	BEGIN	

		SET @Fecha_Egreso = DATEADD (DAY, @Cant_Noches, @Fecha_Ingreso);

		IF EXISTS (SELECT Id_Reserva FROM LA_QUERY_DE_PAPEL.Reserva WHERE Id_Reserva = @Id_Reserva)
		BEGIN

			INSERT INTO LA_QUERY_DE_PAPEL.Estadia 
				(Id_Reserva, Fecha_ingreso, Fecha_egreso)
			VALUES (@Id_Reserva, @Fecha_Ingreso, @Fecha_Egreso)

		END

		ELSE
		BEGIN

			INSERT INTO LA_QUERY_DE_PAPEL.Estadia_conflicto_migracion 
				(Id_Reserva, Fecha_ingreso, Fecha_egreso)
			VALUES (@Id_Reserva, @Fecha_Ingreso, @Fecha_Egreso)

		END

		FETCH NEXT FROM cursor_estadias INTO @Id_Reserva, @Fecha_Ingreso, @Cant_Noches;

	END 
	CLOSE cursor_estadias;
	DEALLOCATE cursor_estadias;

END
GO


--Migracion

--Cargo los hoteles

INSERT INTO [LA_QUERY_DE_PAPEL].[Hotel] (Nombre, Pais, Ciudad, Direccion, Cant_Estrellas, Recarga_Estrella, Fecha_Creacion) 
SELECT DISTINCT 'Hotel ' + RTRIM(M.Hotel_Ciudad) + ' (Calle: ' + RTRIM(M.Hotel_Calle) + ')', 'Desconocido', 
	M.Hotel_Ciudad, M.Hotel_Calle + ' ' + CAST(M.Hotel_Nro_Calle AS VARCHAR), M.Hotel_CantEstrella, M.Hotel_Recarga_Estrella,
	DATETIMEFROMPARTS(2000, 1, 1, 0, 0, 0, 0)
FROM gd_esquema.Maestra M

--SELECT * FROM LA_QUERY_DE_PAPEL.Hotel


--Cargo los tipos de habitaciones

INSERT INTO LA_QUERY_DE_PAPEL.Tipo_Habitacion (Id_tipo, Descripcion, Porcentual)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual FROM gd_esquema.Maestra

--SELECT * FROM LA_QUERY_DE_PAPEL.Tipo_Habitacion


--Cargo las habitaciones

INSERT INTO [LA_QUERY_DE_PAPEL].[Habitacion] (Nro_Habitacion, Id_Hotel, Piso, Ubicacion, Tipo_Hab, Descripcion)
SELECT DISTINCT M.Habitacion_Numero, 
				(SELECT DISTINCT Id_Hotel FROM [LA_QUERY_DE_PAPEL].[Hotel] H WHERE H.Ciudad = M.Hotel_Ciudad AND H.Direccion = M.Hotel_Calle + ' ' + CAST(M.Hotel_Nro_Calle AS VARCHAR)), 
				M.Habitacion_Piso, M.Habitacion_Frente, Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion
FROM gd_esquema.Maestra M

--SELECT * FROM LA_QUERY_DE_PAPEL.Habitacion 


--Cargo los regimenes

INSERT INTO [LA_QUERY_DE_PAPEL].Regimen (Descripcion, Precio)
SELECT DISTINCT M.Regimen_Descripcion, M.Regimen_Precio
FROM gd_esquema.Maestra M

--SELECT * FROM LA_QUERY_DE_PAPEL.Regimen


--Cargo los regimenes por hotel

INSERT INTO LA_QUERY_DE_PAPEL.RegimenxHotel
SELECT DISTINCT 
		(SELECT Id_Hotel FROM LA_QUERY_DE_PAPEL.Hotel WHERE Ciudad = M.Hotel_Ciudad AND Direccion = M.Hotel_Calle + ' ' + CAST(M.Hotel_Nro_Calle AS VARCHAR)),
		(SELECT Id_Regimen FROM LA_QUERY_DE_PAPEL.Regimen WHERE Descripcion = M.Regimen_Descripcion AND Precio = M.Regimen_Precio)
FROM gd_esquema.Maestra M

--SELECT * FROM LA_QUERY_DE_PAPEL.RegimenxHotel


--Cargo los clientes (Como personas)

EXECUTE [LA_QUERY_DE_PAPEL].Cargar_Personas
 
--SELECT * FROM [LA_QUERY_DE_PAPEL].Persona
--SELECT * FROM [LA_QUERY_DE_PAPEL].Cliente
--SELECT * FROM [LA_QUERY_DE_PAPEL].Cliente_Conflicto_Migracion
--SELECT * FROM [LA_QUERY_DE_PAPEL].Persona_conflicto_migracion


--Cargo las reservas

EXECUTE LA_QUERY_DE_PAPEL.Cargar_Reservas

--SELECT * FROM [LA_QUERY_DE_PAPEL].Reserva
--SELECT * FROM [LA_QUERY_DE_PAPEL].Reserva_Conflicto_Migracion
--SELECT * FROM [LA_QUERY_DE_PAPEL].ReservaxHabitacion
--SELECT * FROM [LA_QUERY_DE_PAPEL].ReservaxHabitacion_Conflicto_Migracion


--Cargo las estadias

EXECUTE LA_QUERY_DE_PAPEL.Cargar_Estadias

--SELECT * FROM [LA_QUERY_DE_PAPEL].Estadia
--SELECT * FROM [LA_QUERY_DE_PAPEL].Estadia_conflicto_migracion


-- Cargo los consumibles

INSERT INTO LA_QUERY_DE_PAPEL.Consumible (Id_Consumible,descripcion,precio)
SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL

--SELECT * FROM LA_QUERY_DE_PAPEL.Consumible




INSERT INTO LA_QUERY_DE_PAPEL.UsuarioxHotel (Id_Hotel, Id_Usuario)
VALUES (1, 1), (2, 1), (1, 2)



--cargo consumible_estadia 

INSERT INTO LA_QUERY_DE_PAPEL.Consumible_estadia (Id_Reserva,Id_Consumible,cantidad)
SELECT DISTINCT e.Id_Reserva, c.Id_Consumible, COUNT(m.Consumible_Descripcion)
FROM gd_esquema.Maestra m JOIN LA_QUERY_DE_PAPEL.consumible c on m.Consumible_Codigo= c.Id_Consumible
						  JOIN LA_QUERY_DE_PAPEL.estadia e on m.Reserva_Codigo=e.Id_Reserva		
GROUP BY e.Id_Reserva,c.Id_Consumible



-- Cargo los consumibles para las estadias en conflicto

INSERT INTO LA_QUERY_DE_PAPEL.[Consumible_estadia_Conflicto_Migracion] (Id_Reserva,Id_Consumible,cantidad)
SELECT DISTINCT E.Id_Reserva, C.Id_Consumible, COUNT(M.Consumible_Descripcion)
FROM gd_esquema.Maestra M JOIN LA_QUERY_DE_PAPEL.consumible C ON M.Consumible_Codigo = C.Id_Consumible
						  JOIN LA_QUERY_DE_PAPEL.Estadia_conflicto_migracion E ON M.Reserva_Codigo = E.Id_Reserva	
GROUP BY e.Id_Reserva,c.Id_Consumible

--SELECT * FROM LA_QUERY_DE_PAPEL.[Consumible_estadia_Conflicto_Migracion]



INSERT INTO LA_QUERY_DE_PAPEL.Factura (Nro_Factura, Id_Reserva, Tipo_Documento_cliente, Nro_Documento_cliente, Fecha_Emision, Forma_Pago)

select distinct m.Factura_Nro, e.Id_Reserva, c.Tipo_Documento, c.Nro_Documento,CAST(m.Factura_Fecha as DATE),(select Desc_medio_pago from LA_QUERY_DE_PAPEL.MedioPago where Id_medio_pago = 1)
from gd_esquema.Maestra m join LA_QUERY_DE_PAPEL.Estadia e on m.Reserva_Codigo=e.Id_Reserva JOIN LA_QUERY_DE_PAPEL.Cliente c ON m.Cliente_Pasaporte_Nro = c.Nro_Documento
where m.Factura_Fecha is not null

--SELECT*FROM LA_QUERY_DE_PAPEL.Factura



--Cargo las facturas con conflicto

INSERT INTO LA_QUERY_DE_PAPEL.Factura_Conflicto_Migracion (Nro_Factura, Id_Reserva, Tipo_Documento_cliente, Nro_Documento_cliente, Fecha_Emision, Forma_Pago, Id_Persona)
SELECT DISTINCT M.Factura_Nro, E.Id_Reserva, R.Tipo_Documento, R.Nro_Documento, CAST(M.Factura_Fecha AS DATE),
				(SELECT Desc_medio_pago FROM LA_QUERY_DE_PAPEL.MedioPago WHERE Id_medio_pago = 1),
				R.Id_Persona_Conflicto
FROM gd_esquema.Maestra M 
	JOIN LA_QUERY_DE_PAPEL.Estadia_conflicto_migracion E ON M.Reserva_Codigo = E.Id_Reserva 
	JOIN LA_QUERY_DE_PAPEL.Reserva_Conflicto_Migracion R ON E.Id_Reserva = R.Id_Reserva
where M.Factura_Fecha IS NOT NULL


--SELECT*FROM LA_QUERY_DE_PAPEL.Factura_Conflicto_Migracion

--Inserto todos los items de consumibles 

INSERT INTO LA_QUERY_DE_PAPEL.Item (Nro_Factura, Id_Reserva, Descripcion, Precio, Cantidad)
SELECT Nro_Factura , f.Id_Reserva, consumible.descripcion, consumible.precio,consumible_estadia.cantidad
FROM LA_QUERY_DE_PAPEL.Factura f
JOIN LA_QUERY_DE_PAPEL.consumible_estadia ON (consumible_estadia.Id_Reserva = f.Id_Reserva)
JOIN LA_QUERY_DE_PAPEL.consumible ON (consumible.Id_Consumible = consumible_estadia.Id_Consumible)


--SELECT*FROM LA_QUERY_DE_PAPEL.Item ORDER BY Id_Reserva



-- Cargo los items de consumibles con conflictos

INSERT INTO LA_QUERY_DE_PAPEL.Item_Conflicto_Migracion (Nro_Factura, Id_Reserva, Descripcion, Precio, Cantidad)
SELECT Nro_Factura , F.Id_Reserva, C.descripcion, C.precio, CE.cantidad
FROM LA_QUERY_DE_PAPEL.Factura_Conflicto_Migracion F
	JOIN LA_QUERY_DE_PAPEL.Consumible_estadia_Conflicto_Migracion CE ON (CE.Id_Reserva = F.Id_Reserva)
	JOIN LA_QUERY_DE_PAPEL.consumible C ON (C.Id_Consumible = CE.Id_Consumible)

--SELECT * FROM LA_QUERY_DE_PAPEL.Item_Conflicto_Migracion ORDER BY Id_Reserva



--Inserto los descuentos por all inclusive

INSERT INTO LA_QUERY_DE_PAPEL.item (Nro_Factura, Id_Reserva, Cantidad, descripcion, precio)
SELECT f.Nro_Factura, e.Id_Reserva,  1, 'Descuento por régimen All Inclusive', 0- SUM(consumible.precio * consumible_estadia.cantidad)
FROM LA_QUERY_DE_PAPEL.Factura f
JOIN LA_QUERY_DE_PAPEL.Estadia e ON (f.Id_Reserva = e.Id_Reserva)
JOIN LA_QUERY_DE_PAPEL.Consumible_estadia ON (consumible_estadia.Id_Reserva = e.Id_Reserva)
JOIN LA_QUERY_DE_PAPEL.Consumible ON (consumible.Id_Consumible = consumible_estadia.Id_Consumible)
JOIN LA_QUERY_DE_PAPEL.Reserva ON (reserva.Id_Reserva = e.Id_Reserva)
where reserva.Id_Regimen = 4
GROUP BY f.Nro_Factura, e.Id_Reserva



--Inserto los descuentos por all inclusive con conflictos

INSERT INTO LA_QUERY_DE_PAPEL.Item_Conflicto_Migracion (Nro_Factura, Id_Reserva, Cantidad, descripcion, precio)
SELECT F.Nro_Factura, E.Id_Reserva,  1, 'Descuento por régimen All Inclusive', 0- SUM(C.precio * CE.cantidad)
FROM LA_QUERY_DE_PAPEL.Factura_Conflicto_Migracion F
	JOIN LA_QUERY_DE_PAPEL.Estadia_conflicto_migracion E ON (F.Id_Reserva = E.Id_Reserva)
	JOIN LA_QUERY_DE_PAPEL.Consumible_estadia_Conflicto_Migracion CE ON (CE.Id_Reserva = E.Id_Reserva)
	JOIN LA_QUERY_DE_PAPEL.Consumible C ON (C.Id_Consumible = CE.Id_Consumible)
	JOIN LA_QUERY_DE_PAPEL.Reserva_Conflicto_Migracion R ON (R.Id_Reserva = E.Id_Reserva)
where R.Id_Regimen = 4
GROUP BY F.Nro_Factura, E.Id_Reserva

--SELECT * FROM LA_QUERY_DE_PAPEL.Item_Conflicto_Migracion



--Cargo las estadias en tabla items

INSERT INTO LA_QUERY_DE_PAPEL.Item (Nro_Factura, Id_Reserva, Descripcion, Precio, Cantidad)
SELECT f.Nro_Factura, e.Id_Reserva, 'Estadia',  m.Item_Factura_Cantidad,m.Item_Factura_Monto
	FROM gd_esquema.Maestra m
	 JOIN LA_QUERY_DE_PAPEL.Estadia e
		ON m.Reserva_Codigo = e.Id_Reserva
	JOIN LA_QUERY_DE_PAPEL.Factura f ON (e.Id_Reserva = f.Id_Reserva)
	WHERE m.Consumible_Codigo IS NULL
		AND m.Item_Factura_Monto IS NOT NULL



--Cargo las estadias en tabla items con conflictos

INSERT INTO LA_QUERY_DE_PAPEL.Item_Conflicto_Migracion (Nro_Factura, Id_Reserva, Descripcion, Precio, Cantidad)
SELECT f.Nro_Factura, e.Id_Reserva, 'Estadia',  m.Item_Factura_Cantidad,m.Item_Factura_Monto
FROM gd_esquema.Maestra m
	JOIN LA_QUERY_DE_PAPEL.Estadia_conflicto_migracion e
		ON m.Reserva_Codigo = e.Id_Reserva
	JOIN LA_QUERY_DE_PAPEL.Factura_Conflicto_Migracion f ON (e.Id_Reserva = f.Id_Reserva)
WHERE m.Consumible_Codigo IS NULL
	AND m.Item_Factura_Monto IS NOT NULL



--Cargo el total de las facturas 
UPDATE LA_QUERY_DE_PAPEL.Factura SET Total_Factura =(SELECT SUM(cantidad*precio) FROM LA_QUERY_DE_PAPEL.Item WHERE item.Nro_Factura = factura.Nro_Factura)


--Cargo el total de las facturas con conflicto
UPDATE LA_QUERY_DE_PAPEL.Factura_Conflicto_Migracion SET Total_Factura =(SELECT SUM(cantidad*precio) FROM LA_QUERY_DE_PAPEL.Item_Conflicto_Migracion I WHERE I.Nro_Factura = Nro_Factura)


GO



-- Functions para listados estadisticos

-- Hoteles con mayor cantidad de reservas canceladas

CREATE FUNCTION LA_QUERY_DE_PAPEL.HotelesMayoresCancelaciones (@anio int, @Trimestre int)
RETURNS TABLE
AS
	RETURN (
		SELECT TOP 5 Hotel.Id_Hotel, Hotel.nombre AS 'Hotel Nombre', COUNT(R.Id_Reserva) AS Cantidad_cancelaciones FROM LA_QUERY_DE_PAPEL.Reserva R
			JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion RxH ON RxH.Id_Reserva = R.Id_Reserva
			JOIN LA_QUERY_DE_PAPEL.Hotel Hotel ON Hotel.Id_Hotel = RxH.Id_Hotel
		WHERE	UPPER(R.Estado) LIKE '%CANCELADA%'
				AND Fecha_Inicio IS NOT NULL 
				AND Fecha_Fin IS NOT NULL 
				AND((floor(MONTH(R.Fecha_Inicio)/4) + 1) = @trimestre
				AND YEAR(R.Fecha_Inicio) = @anio)
		GROUP BY Hotel.Id_Hotel, Hotel.nombre
		ORDER BY Cantidad_cancelaciones DESC
	)
GO

--SELECT * FROM LA_QUERY_DE_PAPEL.HotelesMayoresCancelaciones ('2017', '1')


-- Hoteles con mayor cantidad de consumibles facturados

CREATE FUNCTION LA_QUERY_DE_PAPEL.HotelesMayoresConsumibles (@anio int, @Trimestre int)
RETURNS TABLE
AS
	RETURN (
		SELECT TOP 5 Hotel.Id_Hotel, nombre AS 'Hotel Nombre', COUNT(Id_Consumible) AS Cantidad FROM LA_QUERY_DE_PAPEL.consumible_estadia
			JOIN LA_QUERY_DE_PAPEL.estadia ON (consumible_estadia.Id_Reserva = estadia.Id_Reserva)
			JOIN LA_QUERY_DE_PAPEL.reserva ON (estadia.Id_Reserva = reserva.Id_Reserva)
			JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion ON (ReservaxHabitacion.Id_Reserva = reserva.Id_Reserva)
			JOIN LA_QUERY_DE_PAPEL.hotel ON (hotel.Id_Hotel = ReservaxHabitacion.Id_Hotel)
		WHERE Fecha_ingreso IS NOT NULL AND Fecha_egreso IS NOT NULL AND((floor(MONTH(Estadia.Fecha_ingreso)/4) + 1) = @trimestre
				and YEAR(Estadia.Fecha_ingreso) = @anio)
		GROUP BY Hotel.Id_Hotel, nombre
		ORDER BY cantidad DESC
	)
GO

--SELECT * FROM LA_QUERY_DE_PAPEL.HotelesMayoresConsumibles ('2017', '1')


-- Hoteles con mayor cantidad de dias fuera de servicio

CREATE FUNCTION LA_QUERY_DE_PAPEL.HotelesMasDiasFueraDeServicio (@anio int, @Trimestre int)
RETURNS TABLE
AS
	RETURN (
		SELECT TOP 5 Hotel.Id_Hotel, Hotel.nombre AS 'Hotel Nombre', COUNT( DATEDIFF(DAY, HB.Fecha_inicio, HB.Fecha_fin)) AS Cantidad_dias 
			FROM LA_QUERY_DE_PAPEL.Hotel_Baja HB
			JOIN LA_QUERY_DE_PAPEL.Hotel Hotel ON Hotel.Id_Hotel = HB.Id_Hotel
		WHERE	Fecha_Inicio IS NOT NULL 
				AND Fecha_Fin IS NOT NULL 
				AND((floor(MONTH(HB.Fecha_Inicio)/4) + 1) = @trimestre
				AND YEAR(HB.Fecha_Inicio) = @anio)
		GROUP BY Hotel.Id_Hotel, Hotel.nombre
		ORDER BY Cantidad_dias DESC
	)
GO

--SELECT * FROM LA_QUERY_DE_PAPEL.HotelesMasDiasFueraDeServicio ('2017', '1')


--SELECT Estadia.Id_Reserva, ReservaxHabitacion.Nro_Habitacion, Estadia.Fecha_ingreso, Estadia.Fecha_egreso, ReservaxHabitacion.Id_Hotel FROM LA_QUERY_DE_PAPEL.ReservaxHabitacion JOIN LA_QUERY_DE_PAPEL.Reserva ON (ReservaxHabitacion.Id_Reserva = Reserva.Id_Reserva) JOIN LA_QUERY_DE_PAPEL.Estadia ON (Estadia.Id_Reserva = Reserva.Id_Reserva)
--where Fecha_ingreso BETWEEN '2017-01-01' AND '2017-03-31' AND Fecha_egreso BETWEEN  '2017-01-01' AND '2017-03-31' AND Id_Hotel = 2 AND Nro_Habitacion = 2


-- Habitaciones con mayor cantidad de días y veces ocupadas

CREATE FUNCTION LA_QUERY_DE_PAPEL.[habitacionesMasOcupadas] (@anio int, @Trimestre int)
RETURNS TABLE
AS
	RETURN (
		SELECT TOP 5 RxH.Nro_Habitacion 'Número de Habitación', RxH.Id_Hotel 'Id Hotel', nombre AS 'Nombre Hotel', SUM(DATEDIFF(DAY, e.Fecha_ingreso, e.Fecha_egreso)) 'Cantidad de Días', COUNT(1) 'Cantidad de Veces'
			FROM LA_QUERY_DE_PAPEL.Estadia e JOIN LA_QUERY_DE_PAPEL.Reserva r ON (e.Id_Reserva = r.Id_Reserva) JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion RxH
				ON e.Id_Reserva = RxH.Id_Reserva JOIN LA_QUERY_DE_PAPEL.Hotel ON (RxH.Id_Hotel = Hotel.Id_Hotel)
		WHERE ((floor(MONTH(e.fecha_ingreso)/4) + 1) = @trimestre
			and YEAR(e.fecha_ingreso) = @anio)
		GROUP BY RxH.Id_Hotel, RxH.Nro_Habitacion, Nombre
		ORDER BY 4 DESC, 5 DESC
	)
GO

--SELECT * FROM LA_QUERY_DE_PAPEL.[habitacionesMasOcupadas] ('2017', '1')


-- Clientes con mas puntaje

CREATE FUNCTION LA_QUERY_DE_PAPEL.ClientesConMasPuntos (@anio int, @Trimestre int)
RETURNS TABLE
AS
	RETURN (
		SELECT TOP 5 P.Apellido, P.Nombre, P.Tipo_Documento, P.Nro_Documento, 
					SUM(F.Cant_Puntos_por_Factura)
						AS Cantidad_puntos 
					FROM LA_QUERY_DE_PAPEL.Persona P
			JOIN (SELECT Fact.Tipo_Documento_Cliente, Fact.Nro_Documento_Cliente, Fact.Fecha_Emision, FLOOR((SELECT SUM(I.Precio) FROM LA_QUERY_DE_PAPEL.Item I 
						WHERE I.Nro_Factura = Fact.Nro_Factura 
							AND UPPER(I.Descripcion) LIKE '%ESTADIA%'
					) / 20) 
					+ FLOOR((SELECT SUM(I.Precio) FROM LA_QUERY_DE_PAPEL.Item I
						WHERE I.Nro_Factura = Fact.Nro_Factura
							AND UPPER(I.Descripcion) NOT LIKE '%ESTADIA%'
							AND UPPER(I.Descripcion) NOT LIKE '%ALL INCLUSIVE%'
					) / 10) AS Cant_Puntos_por_Factura 
				FROM LA_QUERY_DE_PAPEL.Factura Fact) F 
				ON F.Tipo_Documento_Cliente = P.Tipo_Documento AND F.Nro_Documento_Cliente = P.Nro_Documento
		WHERE	F.Fecha_Emision IS NOT NULL 
				AND((floor(MONTH(F.Fecha_Emision)/4) + 1) = @trimestre
				AND YEAR(F.Fecha_Emision) = @anio)
		GROUP BY P.Nombre, P.Apellido, P.Tipo_Documento, P.Nro_Documento
		ORDER BY Cantidad_puntos DESC, P.Apellido, P.Nombre
	)
GO

--SELECT * FROM LA_QUERY_DE_PAPEL.ClientesConMasPuntos ('2017', '1')



--Dropeo indices

DROP INDEX Nro_Doc_index ON LA_QUERY_DE_PAPEL.Persona;
DROP INDEX Apellido_index ON LA_QUERY_DE_PAPEL.Persona;
DROP INDEX Nombre_index ON LA_QUERY_DE_PAPEL.Persona;
DROP INDEX Ciudad_Hotel_index ON LA_QUERY_DE_PAPEL.Hotel;
DROP INDEX Direccion_Hotel_index ON LA_QUERY_DE_PAPEL.Hotel;
