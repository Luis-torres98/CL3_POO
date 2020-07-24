CREATE PROCEDURE SP_TIPODOCUMENTO_LISTAR

AS
	SELECT P.IdTipoDocumento , P.Nombre FROM DBO.TipoDocumento P
GO




CREATE or Alter PROCEDURE SP_CONDUCTOR_LISTAR
AS
	SELECT c.ConductorId, C.Dni, C.Nombre, C.ApellidoPaterno , C.ApellidoMaterno, C.Brevete, C.Telefono, C.Estado , C.IdTipoDocumento , td.Nombre NombreDoc
	FROM dbo.Conductor C INNER JOIN DBO.TipoDocumento TD ON  C.IdTipoDocumento = TD.IdTipoDocumento
GO





CREATE PROCEDURE SP_CONDUCTOR_INSERTAR
@DNI VARCHAR (10),
@NOMBRE VARCHAR(30),
@APE_PAT VARCHAR(30),
@APE_MAT VARCHAR(30),
@BREVETE VARCHAR(20),
@TLF VARCHAR(20),
@EDO CHAR(1),
@ID_TD INT
AS
	INSERT INTO DBO.Conductor(Dni,Nombre,ApellidoPaterno,ApellidoMaterno,Brevete,Telefono,Estado,IdTipoDocumento)
	VALUES (@DNI,@NOMBRE,@APE_PAT,@APE_MAT,@BREVETE,@TLF,@EDO,@ID_TD)

GO




CREATE PROCEDURE SP_ACTUALIZAR_CONDUCTOR
@DNI VARCHAR (10),
@NOMBRE VARCHAR(30),
@APE_PAT VARCHAR(30),
@APE_MAT VARCHAR(30),
@BREVETE VARCHAR(20),
@TLF VARCHAR(20),
@EDO CHAR(1),
@ID_TD INT,
@ID_CONDUCTOR INT
AS
	UPDATE DBO.Conductor
	SET Dni = @DNI,Nombre = @NOMBRE ,ApellidoPaterno=@APE_PAT,ApellidoMaterno=@APE_MAT,Brevete=@BREVETE,Telefono=@TLF,
	Estado=@EDO,IdTipoDocumento=@ID_TD
	WHERE ConductorId = @ID_CONDUCTOR

GO





CREATE PROCEDURE SP_CONDUCTOR_X_TIPODOCUMENTO
@IdTD	int
AS
	SELECT *
	FROM dbo.Conductor C
	WHERE c.IdTipoDocumento = @IdTD 
GO
