SELECT * FROM dbo.materia_paquete;
SELECT * FROM dbo.materias;
SELECT * FROM [Proyecto_Final_Horarios].dbo.alumnos;
SELECT * FROM dbo.paquetes;
SELECT * FROM dbo.registro_calificaciones
SELECT * FROM dbo.horaMaterias;

SELECT * FROM dbo.materia_paquete;
SELECT 
    p.Clave_Paquete,
    mp.Clave_Horario,
    m.Nombre AS Nombre_Materia,
    h.Hor_lun,
    h.Hor_mar,
    h.Hor_mie,
    h.Hor_jue,
    h.Hor_vie
FROM dbo.paquetes p
JOIN dbo.materia_paquete mp
    ON p.Clave_Paquete = mp.Clave_Paquete
JOIN dbo.horaMaterias h
    ON mp.Clave_Horario = h.Clave_Horario
JOIN dbo.materias m
    ON h.Clave_Materia = m.Clave_Materia
	WHERE p.Clave_Paquete LIKE 'A001%'
	ORDER BY h.Hor_lun ASC


SELECT TOP 1
    (SELECT MAX(h)
     FROM (VALUES (h.Hor_lun),
                  (h.Hor_mar),
                  (h.Hor_mie),
                  (h.Hor_jue),
                  (h.Hor_vie)) AS AllDays(h)
    ) AS HoraMasTarde
FROM dbo.paquetes p
JOIN dbo.materia_paquete mp
    ON p.Clave_Paquete = mp.Clave_Paquete
JOIN dbo.horaMaterias h
    ON mp.Clave_Horario = h.Clave_Horario
WHERE p.Clave_Paquete LIKE 'A001%'
ORDER BY HoraMasTarde DESC;

SELECT TOP 1
    (SELECT MIN(h)
     FROM (VALUES (h.Hor_lun),
                  (h.Hor_mar),
                  (h.Hor_mie),
                  (h.Hor_jue),
                  (h.Hor_vie)) AS AllDays(h)
    ) AS HoraMasTemprana
FROM dbo.paquetes p
JOIN dbo.materia_paquete mp
    ON p.Clave_Paquete = mp.Clave_Paquete
JOIN dbo.horaMaterias h
    ON mp.Clave_Horario = h.Clave_Horario
WHERE p.Clave_Paquete LIKE 'A001%'
ORDER BY HoraMasTemprana ASC;


SELECT 
    m.Nombre
FROM paquetes p
JOIN materia_paquete mp
    ON p.Clave_Paquete = mp.Clave_Paquete
JOIN horaMaterias h
    ON mp.Clave_Horario = h.Clave_Horario
JOIN materias m
    ON h.Clave_Materia = m.Clave_Materia
WHERE p.Clave_Paquete LIKE 'A001%'
  AND h.Hor_lun = '08:00';



  SELECT Clave_Materia, Nombre, Creditos
FROM materias
WHERE Prioridad = 1
ORDER BY Creditos DESC;


  SELECT Clave_Materia, Nombre, Creditos
FROM materias
WHERE Prioridad = 2
ORDER BY Creditos DESC;


  SELECT Clave_Materia, Nombre, Creditos
FROM materias
WHERE Prioridad = 3
ORDER BY Creditos DESC;

SELECT MAX(Prioridad) AS PrioridadMaxima
FROM materias;


SELECT Tipo_acred 
FROM registro_calificaciones
WHERE Num_control LIKE 'A002' AND Clave_materia LIKE 'A'


SELECT 
    Num_control,
    Nombre,
    Apellido_Paterno,
    Apellido_Materno,
    Carrera,
    Semestre
FROM alumnos
WHERE Num_control LIKE 'A002' 