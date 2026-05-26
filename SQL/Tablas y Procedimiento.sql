CREATE DATABASE Proyecto_Final_Horarios;
GO

USE Proyecto_Final_Horarios;
GO

CREATE TABLE [dbo].[materias](
    Clave_Materia CHAR(5) PRIMARY KEY,
    Prerequisito CHAR(5) NULL,
    Prioridad INT,
    Nombre VARCHAR(80), 
    Creditos INT,

);
GO

-- Desglose de calificaciones
CREATE TABLE detalle_calificaciones (
    Id INT IDENTITY PRIMARY KEY,
    Num_control VARCHAR(10),
    Clave_Materia VARCHAR(5),
    Asistencia DECIMAL(5,2),   -- porcentaje
    Trabajos DECIMAL(5,2),
    Examenes DECIMAL(5,2),
    Calificacion_final AS (Asistencia*0.1 + Trabajos*0.3 + Examenes*0.6)
);

-- Usuarios y roles
CREATE TABLE usuarios (
    Username VARCHAR(50) PRIMARY KEY,
    Password_hash VARCHAR(256),
    Rol VARCHAR(20) CHECK (Rol IN ('Admin','Maestro','Alumno')),
    Id_referencia VARCHAR(10)  -- Num_control o Num_empleado
);


CREATE TABLE [dbo].[horaMaterias](
    Clave_Horario CHAR(5) PRIMARY KEY,
    Clave_Materia CHAR(5),
    Hor_lun TIME,
    Hor_mar TIME,
    Hor_mie TIME,
    Hor_jue TIME,
    Hor_vie TIME,
    CONSTRAINT FK_hora_Materia
        FOREIGN KEY (Clave_Materia) REFERENCES dbo.materias(Clave_Materia)
);
GO


CREATE TABLE [dbo].[paquetes] (
    Clave_Paquete VARCHAR(20) PRIMARY KEY
);
GO

CREATE TABLE [dbo].[alumnos] (
    Num_control VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(80),
    Apellido_Paterno VARCHAR(50),
    Apellido_Materno VARCHAR(50),
    Carrera VARCHAR(50),
    Semestre INT,
    Curp VARCHAR(20),
    Clave_Paquete VARCHAR(20) NULL,
    CONSTRAINT FK_Alumno_Paquete
        FOREIGN KEY (Clave_Paquete) REFERENCES dbo.paquetes(Clave_Paquete)
);
GO

CREATE TABLE [dbo].[materia_paquete] (
    Id_materia_paquete INT IDENTITY(1,1) PRIMARY KEY,
    Clave_Paquete VARCHAR(20),
    Clave_Horario CHAR(5),
    CONSTRAINT FK_Materia_Paquete
        FOREIGN KEY (Clave_Paquete) REFERENCES dbo.paquetes(Clave_Paquete),
    CONSTRAINT FK_Paquete_Hora
        FOREIGN KEY (Clave_Horario) REFERENCES dbo.horaMaterias(Clave_Horario)
);
GO

CREATE TABLE dbo.registro_calificaciones (
    Id_registro INT IDENTITY(1,1) PRIMARY KEY,
    Num_control VARCHAR(10),
    Clave_materia CHAR(5),
    Calificacion INT,
	 Tipo_acred INT, -- 1: no cursado, 2: reprobado, 3: aprobado
    CONSTRAINT FK_Registro_Materia
        FOREIGN KEY (Clave_materia) REFERENCES dbo.materias(Clave_Materia),
    CONSTRAINT FK_Registro_Alumno
        FOREIGN KEY (Num_control) REFERENCES dbo.alumnos(Num_control)
);
GO

CREATE TABLE maestros (
    Num_empleado VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(80),
    Apellido_Paterno VARCHAR(50),
    Apellido_Materno VARCHAR(50),
    Email VARCHAR(100),
    Especialidad VARCHAR(80),
    Activo BIT DEFAULT 1,
    Password_hash VARCHAR(256)  
);

-- Tabla de bitácora de accesos
CREATE TABLE bitacora_accesos (
    Id INT IDENTITY PRIMARY KEY,
    Username VARCHAR(50),
    Rol VARCHAR(20),
    Accion VARCHAR(100),
    IP_equipo VARCHAR(50),
    Fecha DATETIME DEFAULT GETDATE()
);

-- Tabla de relación maestro
CREATE TABLE maestro_horario (
    Id INT IDENTITY PRIMARY KEY,
    Num_empleado VARCHAR(10) FOREIGN KEY REFERENCES maestros(Num_empleado),
    Clave_Horario CHAR(5) FOREIGN KEY REFERENCES horaMaterias(Clave_Horario),
    Periodo VARCHAR(20),   -- ej. "Enero-Junio 2025"
    Anio INT
);



CREATE PROCEDURE dbo.GenerarPaquetesAlumno
    @Num_control VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @i INT = 1;
    DECLARE @Clave_Paquete VARCHAR(20);
    DECLARE @CreditosAcumulados INT;
    DECLARE @Clave_Horario CHAR(5);
    DECLARE @Clave_Materia CHAR(5);
    DECLARE @CreditosMateria INT;
    DECLARE @Prioridad INT;

    ---------------------------------------------------------
    -- Tabla temporal de materias elegibles
    ---------------------------------------------------------
    DECLARE @MateriasElegibles TABLE (
        Clave_Horario CHAR(5),
        Clave_Materia CHAR(5),
        Prioridad INT
    );

    INSERT INTO @MateriasElegibles
    SELECT 
        h.Clave_Horario,
        m.Clave_Materia,
        m.Prioridad
    FROM dbo.materias m
    JOIN dbo.horaMaterias h ON h.Clave_Materia = m.Clave_Materia
    LEFT JOIN dbo.registro_calificaciones r
        ON r.Clave_materia = m.Clave_Materia
       AND r.Num_control = @Num_control
    WHERE 
        (r.Tipo_acred IS NULL OR r.Tipo_acred = 2) -- no cursada o reprobada
        AND (
            m.Prerequisito IS NULL 
            OR EXISTS (
                SELECT 1 
                FROM dbo.registro_calificaciones rc
                WHERE rc.Num_control = @Num_control
                  AND rc.Clave_materia = m.Prerequisito
                  AND rc.Tipo_acred = 3 -- prerequisito aprobado
            )
        );

    ---------------------------------------------------------
    -- Generar 4 paquetes
    ---------------------------------------------------------
    WHILE @i <= 4
    BEGIN
        SET @Clave_Paquete = @Num_control + '-P' + RIGHT('00' + CAST(@i AS VARCHAR(2)), 2);

        INSERT INTO dbo.paquetes(Clave_Paquete)
        VALUES (@Clave_Paquete);

        SET @CreditosAcumulados = 0;

        DECLARE cur CURSOR FOR
            SELECT Clave_Horario, Clave_Materia, Prioridad
            FROM @MateriasElegibles
            ORDER BY Prioridad ASC, NEWID();

        OPEN cur;
        FETCH NEXT FROM cur INTO @Clave_Horario, @Clave_Materia, @Prioridad;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SELECT @CreditosMateria = Creditos
            FROM dbo.materias
            WHERE Clave_Materia = @Clave_Materia;

            ---------------------------------------------------------
            -- VALIDACIÓN 1: No repetir CLAVE_MATERIA en el paquete
            ---------------------------------------------------------
            IF EXISTS (
                SELECT 1
                FROM dbo.materia_paquete mp
                JOIN dbo.horaMaterias h1 ON mp.Clave_Horario = h1.Clave_Horario
                WHERE mp.Clave_Paquete = @Clave_Paquete
                AND h1.Clave_Materia = @Clave_Materia
            )
            BEGIN
                FETCH NEXT FROM cur INTO @Clave_Horario, @Clave_Materia, @Prioridad;
                CONTINUE;
            END

            ---------------------------------------------------------
            -- VALIDACIÓN 2: Choques de horario
            ---------------------------------------------------------
            IF EXISTS (
                SELECT 1
                FROM dbo.materia_paquete mp
                JOIN dbo.horaMaterias h1 ON mp.Clave_Horario = h1.Clave_Horario
                JOIN dbo.horaMaterias h2 ON h2.Clave_Horario = @Clave_Horario
                WHERE mp.Clave_Paquete = @Clave_Paquete
                AND (
                        (h1.Hor_lun IS NOT NULL AND h2.Hor_lun IS NOT NULL AND h1.Hor_lun = h2.Hor_lun)
                     OR (h1.Hor_mar IS NOT NULL AND h2.Hor_mar IS NOT NULL AND h1.Hor_mar = h2.Hor_mar)
                     OR (h1.Hor_mie IS NOT NULL AND h2.Hor_mie IS NOT NULL AND h1.Hor_mie = h2.Hor_mie)
                     OR (h1.Hor_jue IS NOT NULL AND h2.Hor_jue IS NOT NULL AND h1.Hor_jue = h2.Hor_jue)
                     OR (h1.Hor_vie IS NOT NULL AND h2.Hor_vie IS NOT NULL AND h1.Hor_vie = h2.Hor_vie)
                )
            )
            BEGIN
                FETCH NEXT FROM cur INTO @Clave_Horario, @Clave_Materia, @Prioridad;
                CONTINUE;
            END

            ---------------------------------------------------------
            -- VALIDACIÓN 3: Créditos ≤ 28
            ---------------------------------------------------------
            IF (@CreditosAcumulados + @CreditosMateria <= 28)
            BEGIN
                INSERT INTO dbo.materia_paquete(Clave_Paquete, Clave_Horario)
                VALUES (@Clave_Paquete, @Clave_Horario);

                SET @CreditosAcumulados = @CreditosAcumulados + @CreditosMateria;
            END

            FETCH NEXT FROM cur INTO @Clave_Horario, @Clave_Materia, @Prioridad;
        END

        CLOSE cur;
        DEALLOCATE cur;

        SET @i = @i + 1;
    END
END;
GO

-- Procedimiento: AsignarMaestroAHorario
-- Si la asignación ya existe, no la duplica 
CREATE PROCEDURE dbo.AsignarMaestroAHorario
    @Num_empleado   VARCHAR(10),   -- Clave del maestro
    @Clave_Horario  CHAR(5),       -- Clave del horario (grupo)
    @Periodo        VARCHAR(20),   -- Ej. 'Enero-Junio 2025'
    @Anio           INT,           -- Año académico
    @Sobrescribir   BIT = 0        -- Si 1, actualiza periodo/año si ya existe; si 0, no hace nada si ya existe
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el maestro exista y esté activo
    IF NOT EXISTS (SELECT 1 FROM maestros WHERE Num_empleado = @Num_empleado AND Activo = 1)
    BEGIN
        RAISERROR('El maestro no existe o está inactivo.', 16, 1);
        RETURN;
    END

    -- Validar que el horario exista
    IF NOT EXISTS (SELECT 1 FROM horaMaterias WHERE Clave_Horario = @Clave_Horario)
    BEGIN
        RAISERROR('El horario no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si ya existe la asignación
    IF EXISTS (SELECT 1 FROM maestro_horario WHERE Num_empleado = @Num_empleado AND Clave_Horario = @Clave_Horario)
    BEGIN
        IF @Sobrescribir = 1
        BEGIN
            UPDATE maestro_horario
            SET Periodo = @Periodo,
                Anio = @Anio
            WHERE Num_empleado = @Num_empleado AND Clave_Horario = @Clave_Horario;
            PRINT 'Asignación actualizada.';
        END
        ELSE
        BEGIN
            PRINT 'La asignación ya existe. Use @Sobrescribir=1 para actualizar.';
        END
    END
    ELSE
    BEGIN
        INSERT INTO maestro_horario (Num_empleado, Clave_Horario, Periodo, Anio)
        VALUES (@Num_empleado, @Clave_Horario, @Periodo, @Anio);
        PRINT 'Asignación creada exitosamente.';
    END
END;
GO
