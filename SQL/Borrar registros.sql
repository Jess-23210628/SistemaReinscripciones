-- 1. Deshabilitar todas las llaves foráneas
EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';

-- 2. Borrar datos de todas las tablas
EXEC sp_MSforeachtable 'DELETE FROM ?';

-- 3. Reiniciar los IDENTITY de las tablas que tengan columnas autoincrementables
DECLARE @tableName NVARCHAR(255)
DECLARE tables_cursor CURSOR FOR
    SELECT TABLE_NAME
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1
    GROUP BY TABLE_NAME

OPEN tables_cursor
FETCH NEXT FROM tables_cursor INTO @tableName

WHILE @@FETCH_STATUS = 0
BEGIN
    EXEC('DBCC CHECKIDENT (''' + @tableName + ''', RESEED, 0)');
    FETCH NEXT FROM tables_cursor INTO @tableName
END

CLOSE tables_cursor
DEALLOCATE tables_cursor

-- 4. Volver a habilitar las llaves foráneas
EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL';
