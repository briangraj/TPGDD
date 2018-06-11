--Esquema
USE [GD1C2018]
GO
--CREATE SCHEMA [LA_QUERY_DE_PAPEL] 
GO

CREATE TABLE [LA_QUERY_DE_PAPEL].[Rol] ( 
	Id_Rol INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Persona] ( 
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Telefono nvarchar(50) NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL,
	
	PRIMARY KEY (Tipo_Documento, Nro_Documento),	
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

	FOREIGN KEY (Tipo_Documento, Nro_Documento) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento) ON UPDATE CASCADE,
	
	);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Hotel] ( 
	Id_Hotel INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Mail nvarchar(255),
	Telefono nvarchar(50),
	Direccion nvarchar(255) NOT NULL,
	Cant_Estrellas INT NOT NULL,
	Ciudad nvarchar(255) NOT NULL,
	Pais nvarchar(255) NOT NULL,
	Fecha_Creacion datetime);

CREATE TABLE [LA_QUERY_DE_PAPEL].[Hotel_Baja](
        Id_Baja INT  PRIMARY KEY IDENTITY(1,1),
        Id_Hotel INT NOT NULL,
        Fecha_inicio datetime NOT NULL,
        Fecha_fin datetime NOT NULL,
		Descripcion nvarchar(255),
 FOREIGN KEY (Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Hotel] (Id_Hotel)
 );

CREATE TABLE [LA_QUERY_DE_PAPEL].[Habitacion](
        Nro_Habitacion INT,-- PRIMARY KEY IDENTITY(1,1),
        Id_Hotel INT NOT NULL,
		Piso INT NOT NULL,
        Ubicacion nvarchar(255),
        Tipo_Hab numeric(18),
        Descripcion nvarchar(255),
FOREIGN KEY (Id_Hotel) REFERENCES [LA_QUERY_DE_PAPEL].[Hotel] (Id_Hotel),
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
	FOREIGN KEY (Id_Regimen) REFERENCES [LA_QUERY_DE_PAPEL].[Regimen] (Id_Regimen));	

CREATE TABLE [LA_QUERY_DE_PAPEL].[Reserva] ( 
	Id_Reserva INT NOT NULL PRIMARY KEY,
	Id_Regimen INT DEFAULT NULL,
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches INT NOT NULL,
	Id_Hotel INT NOT NULL,
	Fecha_Inicio datetime,
	Fecha_Fin datetime,	
	Estado numeric(18) NOT NULL DEFAULT 1,
	Id_Usuario INT NOT NULL, 

	FOREIGN KEY (Id_Regimen) REFERENCES [LA_QUERY_DE_PAPEL].[Regimen] (Id_Regimen),
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

	CREATE TABLE [LA_QUERY_DE_PAPEL].[Factura] ( 
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento INT NOT NULL,
	Fecha_Emision datetime NOT NULL,
	Forma_Pago nvarchar(255) NOT NULL,
	FOREIGN KEY (Tipo_Documento, Nro_Documento) REFERENCES [LA_QUERY_DE_PAPEL].[Persona] (Tipo_Documento, Nro_Documento));


	CREATE TABLE [LA_QUERY_DE_PAPEL].[Funcionalidad] ( 
	Id_Funcion INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);	


CREATE TABLE [LA_QUERY_DE_PAPEL].[FuncionalidadxRol] ( 
	Id_Rol INT NOT NULL,
	Id_Funcion INT NOT NULL,
	PRIMARY KEY (Id_Rol, Id_Funcion),
	FOREIGN KEY (Id_Funcion) REFERENCES [LA_QUERY_DE_PAPEL].[Funcionalidad] (Id_Funcion),
	FOREIGN KEY (Id_Rol) REFERENCES [LA_QUERY_DE_PAPEL].[Rol] (Id_Rol));
	--Conviene crear otra entidad Forma de Pago con id y descripcion??
	--

GO

INSERT INTO LA_QUERY_DE_PAPEL.Rol (Nombre)
VALUES ('Administrador General')

INSERT INTO LA_QUERY_DE_PAPEL.Funcionalidad (Descripcion)
VALUES ('ABM de rol'), ('ABM de usuario')

INSERT INTO LA_QUERY_DE_PAPEL.FuncionalidadxRol(Id_Rol, Id_Funcion)
VALUES (1, 1), (1, 2) --el unico rol y la unica funcionalidad que hay por ahora

INSERT INTO LA_QUERY_DE_PAPEL.Persona (Tipo_Documento, Nro_Documento, Apellido, Nombre,	Direccion, Fecha_Nacimiento, Telefono, Habilitado)
VALUES ('', 1, '', '', '', GETDATE(), '', 1)

INSERT INTO LA_QUERY_DE_PAPEL.Usuario (Tipo_Documento, Nro_Documento, Username,	Password, Id_Rol, Mail)
VALUES ('', 1, 'admin', CONVERT(varbinary(255),HASHBYTES('SHA2_256','w23e' ),2), 1, '')

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

CREATE TRIGGER LA_QUERY_DE_PAPEL.insertUsuarios ON LA_QUERY_DE_PAPEL.usuarios
INSTEAD OF INSERT
AS
BEGIN
INSERT INTO LA_QUERY_DE_PAPEL.Persona (Tipo_Documento, Nro_Documento, Apellido, Nombre, Direccion, Fecha_Nacimiento, Telefono, Habilitado)
	SELECT i.Tipo_Documento, i.Nro_Documento, i.Apellido, i.Nombre, i.Direccion, i.Fecha_Nacimiento, i.Telefono, i.Habilitado
	FROM inserted i

INSERT INTO LA_QUERY_DE_PAPEL.Usuario (Tipo_Documento, Nro_Documento, Username, Password, Id_Rol, Mail)
	SELECT i.Tipo_Documento, i.Nro_Documento, i.Username, i.Password, i.Id_Rol, i.Mail
	FROM inserted i
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
UPDATE LA_QUERY_DE_PAPEL.Persona
	SET Tipo_Documento = i.Tipo_Documento, Nro_Documento = i.Nro_Documento, Apellido = i.Apellido, Nombre = i.Nombre, Direccion = i.Direccion,
		Fecha_Nacimiento = i.Fecha_Nacimiento, Telefono = i.Telefono, Habilitado = i.Habilitado
	FROM inserted i
	WHERE LA_QUERY_DE_PAPEL.Persona.Tipo_Documento IN (SELECT Tipo_Documento FROM deleted) AND LA_QUERY_DE_PAPEL.Persona.Nro_Documento IN (SELECT Nro_Documento FROM deleted)

UPDATE LA_QUERY_DE_PAPEL.Usuario
	SET Username = i.Username, Password = i.Password, Id_Rol = i.Id_Rol, Mail = i.Mail
	FROM inserted i
	WHERE LA_QUERY_DE_PAPEL.Usuario.Username IN (SELECT Username FROM deleted)
END

GO

CREATE TRIGGER LA_QUERY_DE_PAPEL.deletePersonas ON LA_QUERY_DE_PAPEL.Persona
INSTEAD OF DELETE
AS
BEGIN
UPDATE LA_QUERY_DE_PAPEL.Persona
	SET Habilitado = 0
	WHERE LA_QUERY_DE_PAPEL.Persona.Tipo_Documento IN (SELECT Tipo_Documento FROM deleted) AND LA_QUERY_DE_PAPEL.Persona.Nro_Documento IN (SELECT Nro_Documento FROM deleted)
END
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
		DECLARE @error varchar(100)= 'Contraseņa incorrecta. Le quedan ' + str(2 - @intentos) + ' intentos'
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



BEGIN TRANSACTION

INSERT INTO [LA_QUERY_DE_PAPEL].[Hotel] (Nombre, Pais, Ciudad, Direccion, Cant_Estrellas) 
SELECT DISTINCT 'Hotel ' + M.Hotel_Ciudad, 'Desconocido', M.Hotel_Ciudad, M.Hotel_Calle + ' ' + CAST(M.Hotel_Nro_Calle AS VARCHAR), M.Hotel_CantEstrella
FROM gd_esquema.Maestra M


SELECT * FROM [LA_QUERY_DE_PAPEL].Hotel




INSERT INTO [LA_QUERY_DE_PAPEL].[Habitacion] (Nro_Habitacion, Id_Hotel, Piso, Ubicacion, Tipo_Hab, Descripcion)
SELECT DISTINCT M.Habitacion_Numero, 
				(SELECT DISTINCT Id_Hotel FROM [LA_QUERY_DE_PAPEL].[Hotel] H WHERE H.Ciudad = M.Hotel_Ciudad AND H.Direccion = M.Hotel_Calle + ' ' + CAST(M.Hotel_Nro_Calle AS VARCHAR)), 
				M.Habitacion_Piso, M.Habitacion_Frente, M.Habitacion_Tipo_Codigo, M.Habitacion_Tipo_Descripcion
FROM gd_esquema.Maestra M

SELECT * FROM [LA_QUERY_DE_PAPEL].[Habitacion]

ROLLBACK TRANSACTION
