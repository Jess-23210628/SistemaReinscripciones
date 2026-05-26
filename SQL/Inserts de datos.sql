
INSERT INTO dbo.materias (Clave_Materia, Prerequisito, Prioridad, Nombre, Creditos) VALUES
('A', NULL, 1, 'Matemáticas I', 5),
('B', 'A', 2, 'Matemáticas II', 5),
('C', NULL, 1, 'Historia', 4),
('D', NULL, 2, 'Ética', 4),
('E', 'B', 3, 'Estadística', 5),
('F', NULL, 1, 'Programación I', 5),
('G', 'F', 2, 'Programación II', 5),
('H', NULL, 2, 'Dibujo', 4),
('I', 'H', 3, 'Diseño Gráfico', 4),
('J', NULL, 1, 'Música', 4),
('K', NULL, 3, 'Taller de Lectura', 4),
('L', NULL, 3, 'Base de datos', 5);


INSERT INTO dbo.horaMaterias
(Clave_Horario, Clave_Materia, Hor_lun, Hor_mar, Hor_mie, Hor_jue, Hor_vie) VALUES
('AA01', 'A', '08:00', '08:00', '08:00', '08:00', NULL),
('AB01', 'A', '11:00', '11:00', '11:00', '11:00', NULL),
('AC01', 'A', '10:00', '10:00', '10:00', '10:00', NULL),
('BA01', 'B', '08:00', '08:00', '08:00', '08:00', NULL),
('BB01', 'B', '10:00', '10:00', '10:00', '10:00', NULL),
('CA01', 'C', '09:00', '09:00', '09:00', '09:00', NULL),
('CB01', 'C', '08:00', '08:00', '08:00', '08:00', NULL),
('CC01', 'C', '11:00', '11:00', '11:00', '11:00', NULL),
('DA01', 'D', '09:00', '09:00', '09:00', '09:00', NULL),
('DB01', 'D', '11:00', '11:00', '11:00', '11:00', NULL),
('EA01', 'E', '08:00', '08:00', '08:00', '08:00', NULL),
('FA01', 'F', '10:00', '10:00', '10:00', '10:00', NULL),
('FB01', 'F', '09:00', '09:00', '09:00', '09:00', NULL),
('FC01', 'F', '08:00', '08:00', '08:00', '08:00', NULL),
('GA01', 'G', '10:00', '10:00', '10:00', '10:00', NULL),
('GB01', 'G', '08:00', '08:00', '08:00', '08:00', NULL),
('HA01', 'H', '11:00', '11:00', '11:00', '11:00', NULL),
('HB01', 'H', '09:00', '09:00', '09:00', '09:00', NULL),
('IA01', 'I', '11:00', '11:00', '11:00', '11:00', NULL),
('JA01', 'J', '11:00', '11:00', '11:00', '11:00', NULL),
('JB01', 'J', '10:00', '10:00', '10:00', '10:00', NULL),
('JC01', 'J', '09:00', '09:00', '09:00', '09:00', NULL),
('KA01', 'K', '09:00', '09:00', '09:00', '09:00', NULL),
('LA01', 'L', '10:00', '10:00', '10:00', '10:00', NULL);


INSERT INTO dbo.alumnos
(Num_control, Nombre, Apellido_Paterno, Apellido_Materno, Carrera, Semestre, Curp, Clave_Paquete) VALUES
('A001', 'Oliver', 'Aguilar', 'Saavedra', 'Sistemas', 1, 'RUPM050727HNEBRNA1', null),
('A002', 'Jessica', 'Mendoza', 'Salgado', 'Sistemas', 1, 'RUPM050727HNEBRNA1', null),
('A003', 'Yasmin', 'Sal', 'Facudo', 'Sistemas', 1, 'RUPM050727HNEBRNA1', null),
('A004', 'Sarahy', 'Arambula', 'Garcia', 'Sistemas', 1, 'RUPM050727HNEBRNA1', null);
('A005', 'Sofía', 'González', 'Mendoza', 'Sistemas', 1, 'SOGM060101HDFNRL01', NULL),
('A006', 'Diego', 'Luna', 'Castillo', 'Sistemas', 1, 'DILC060202HDFNRL02', NULL);


INSERT INTO dbo.registro_calificaciones
(Num_control, Clave_materia, Calificacion, Tipo_acred) VALUES
('A002', 'A', 87, 3),
('A002', 'F', 87, 3),
('A002', 'J', 87, 3),
('A002', 'C', 42, 2);


INSERT INTO maestros (Num_empleado, Nombre, Apellido_Paterno, Apellido_Materno, Email, Especialidad, Activo, Password_hash)
VALUES 
('M001', 'Carlos', 'Hernández', 'López', 'carlos.hernandez@escuela.edu', 'Matemáticas', 1, '123456'),
('M002', 'María', 'Gómez', 'Pérez', 'maria.gomez@escuela.edu', 'Programación', 1, '123456');
('M003', 'Laura', 'Fernández', 'Reyes', 'laura.fernandez@escuela.edu', 'Bases de Datos', 1, '123456'),
('M004', 'Jorge', 'Ramírez', 'Soto', 'jorge.ramirez@escuela.edu', 'Redes', 1, '123456');


INSERT INTO maestro_horario (Num_empleado, Clave_Horario, Periodo, Anio)
VALUES 
('M001', 'FA01', 'Enero-Junio', 2025),
('M001', 'GA01', 'Enero-Junio', 2025),
('M002', 'FB01', 'Enero-Junio', 2025),
('M002', 'LA01', 'Enero-Junio', 2025);


-- Usuario Administrador
INSERT INTO usuarios (Username, Password_hash, Rol, Id_referencia, Activo, Ultimo_acceso)
VALUES ('admin', '3058', 'Admin', 'ADMIN01', 1, NULL);

-- Usuario Maestro
INSERT INTO usuarios (Username, Password_hash, Rol, Id_referencia, Activo)
VALUES ('carlos.hernandez', '123456', 'Maestro', 'M001', 1);

-- Usuario Alumno
INSERT INTO usuarios (Username, Password_hash, Rol, Id_referencia, Activo)
VALUES
('A001', '123456', 'Alumno', 'A001', 1);
('A002', '123456', 'Alumno', 'A002', 1),
('A003', '123456', 'Alumno', 'A003', 1),
('A004', '123456', 'Alumno', 'A004', 1);

Asignar un paquete activo a cada alumno 
UPDATE alumnos SET Clave_Paquete = 'A001-P01' WHERE Num_control = 'A001';
UPDATE alumnos SET Clave_Paquete = 'A002-P01' WHERE Num_control = 'A002';
UPDATE alumnos SET Clave_Paquete = 'A003-P01' WHERE Num_control = 'A003';
UPDATE alumnos SET Clave_Paquete = 'A004-P01' WHERE Num_control = 'A004';

INSERT INTO registro_calificaciones (Num_control, Clave_materia, Calificacion, Tipo_acred)
VALUES 
('A001', 'A', 85, 3),
('A001', 'F', 90, 3),
('A001', 'J', 70, 2);   -- Música reprobada
('A002', 'G', 78, 3),
('A002', 'L', 95, 3);
('A004', 'A', 60, 3),
('A004', 'C', 45, 2);


-- Asignar al maestro 'M001' (Carlos Hernández) al horario 'FA01' (Programación I)
EXEC dbo.AsignarMaestroAHorario @Num_empleado = 'M001',
                                @Clave_Horario = 'FA01',
                                @Periodo = 'Enero-Junio 2025',
                                @Anio = 2025;

-- Asignar al mismo maestro otro horario
EXEC dbo.AsignarMaestroAHorario 'M001', 'GA01', 'Enero-Junio 2025', 2025;

-- Intentar asignar duplicado sin sobrescribir (solo mostrará mensaje)
EXEC dbo.AsignarMaestroAHorario 'M001', 'FA01', 'Agosto-Diciembre 2025', 2025, 0;

-- Sobrescribir el período del horario FA01 para el maestro M001
EXEC dbo.AsignarMaestroAHorario 'M001', 'FA01', 'Agosto-Diciembre 2025', 2025, 1;
