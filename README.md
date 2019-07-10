# SystemBook

SELECT * FROM libros.dbo.escritor

SELECT es.nombre, es.apellido FROM libros.dbo.poema a 
INNER JOIN escritor es ON es.id_escritor = a.id_escritor
WHERE DATALENGTH(a.contenido) > 100

SELECT * FROM libros.dbo.escritor es
INNER JOIN poema a ON es.id_escritor = a.id_escritor


SELECT DISTINCT nombre_completo = es.nombre + ' ' + es.apellido, lib.titulo  FROM libros.dbo.escritor es
INNER JOIN poema a ON es.id_escritor = a.id_escritor
INNER JOIN poema_libro alib ON alib.id_poema = a.id_poema
INNER JOIN libro lib ON lib.id_libro = alib.id_libro

SELECT * FROM libros.dbo.poema WHERE poema.contenido LIKE '%cielo%' 

UPDATE escritor SET direccion = 'hasta alla' WHERE escritor.id_escritor = 5;

INSERT INTO escritor(nombre, apellido) VALUES('jhon', 'smith');

SELECT * FROM libros.dbo.escritor order by apellido

SELECT titulo, oferta = precio - precio*0.15 FROM libros.dbo.libro

SELECT TOP(5) nombre_completo = es.nombre + ' ' + es.apellido, a.titulo  FROM libros.dbo.poema a 
INNER JOIN escritor es ON es.id_escritor = a.id_escritor
where a.contenido like '%cielo%'
order by es.apellido
------
CREATE PROCEDURE poemasDelibro
@idLibro int

AS
BEGIN
	SELECT p.titulo, p.contenido FROM libros.dbo.poema_libro pl 
	INNER JOIN poema p ON p.id_poema = pl.id_poema
	WHERE pl.id_libro = @idLibro
END
GO
---------

alter PROCEDURE splitUp(@Temp VarChar(1000))

AS
BEGIN
	Declare @KeepValues as varchar(50)
    Set @KeepValues = '%[^ ][A-Z]%'
    While PatIndex(@KeepValues collate Latin1_General_Bin, @Temp) > 0
        Set @Temp = Stuff(@Temp, PatIndex(@KeepValues collate Latin1_General_Bin, @Temp) + 1, 0, ' ')
	
	select SUBSTRING(@Temp, 0, LEN(@Temp)- 3) + ' ' + SUBSTRING(@Temp, LEN(@Temp)- 3, LEN(@Temp))

END
GO

-----
ALTER PROCEDURE reverso(@Temp VarChar(1000))

AS
BEGIN
	DECLARE	@cantidad AS INT
	SET @cantidad = LEN(@Temp)
	DECLARE @tempB AS VARCHAR(1000)
	SET @tempB = ''
	WHILE (@cantidad != 0)
	BEGIN
		print(@tempB)
		SET @tempB += SUBSTRING(@temp, @cantidad, 1)
		SET @cantidad -= 1
	END
	
	SELECT @tempB
END
------
