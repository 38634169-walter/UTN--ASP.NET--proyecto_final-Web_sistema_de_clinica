CREATE DATABASE sistemaTurnosTPFinal

GO
USE sistemaTurnosTPFinal

select * from Empleados as e
inner join Datos_Personales as dp on dp.IDDatosPersonales=e.ID_DatosPersonales


select * from Pacientes as p
inner join Datos_Personales as dp on dp.IDDatosPersonales=p.ID_DatosPersonales

select * from Turnos

select * FROM Datos_Personales where IDDatosPersonales =38
update Datos_Personales set email = 'walter.diaz@alumnos.frgp.utn.edu.ar' where IDDatosPersonales=38

select * from Pacientes

select * from Turnos

SELECT dp.nombre,dp.apellido,dp.dni,t.fecha,t.hora FROM Turnos t, Pacientes p, Datos_Personales dp WHERE t.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales  AND t.ID_Doctor=1 AND (t.ID_EstadoTurno=4 OR t.ID_EstadoTurno=2)

UPDATE Turnos set ID_EstadoTurno=1 WHERE IDTurno=7

SELECT * FROM Turnos WHERE ID_Doctor=1

SELECT * FROM Turnos AS t
INNER JOIN Estados_Turno AS et ON et.IDEstadoTurno=t.ID_EstadoTurno

SELECT * FROM Estados_Turno
SELECT t.IDTurno,t.ID_EstadoTurno,dp.nombre,dp.apellido,dp.dni,t.fecha,t.hora FROM Turnos t, Pacientes p, Datos_Personales dp WHERE t.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales  AND t.ID_Doctor=1 AND (t.ID_EstadoTurno=4 OR t.ID_EstadoTurno=2 OR t.ID_EstadoTurno=3)
SELECT dp.nombre AS nombreP,dp.apellido,dp.dni,t.fecha,t.hora,et.nombre AS nombreE FROM Turnos t, Estados_Turno et, Pacientes p, Datos_Personales dp WHERE t.ID_EstadoTurno=et.IDEstadoTurno AND t.ID_Paciente=p.IDPaciente AND p.ID_DatosPersonales=dp.IDDatosPersonales  AND t.ID_Doctor=1 AND (t.ID_EstadoTurno=4 OR t.ID_EstadoTurno=2 OR t.ID_EstadoTurno=1)





-------------------------------------------------------------------------

CREATE TABLE Datos_Personales(
	IDDatosPersonales BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(30) NOT NULL,
	apellido VARCHAR(30) NOT NULL,
	email VARCHAR(50) NOT NULL,
	telefono VARCHAR(15) NOT NULL,
	dni VARCHAR(11) NOT NULL UNIQUE,
	estado BIT DEFAULT 1
)

CREATE TABLE Empleados(
	IDEmpleado BIGINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	ID_DatosPersonales BIGINT NOT NULL FOREIGN KEY REFERENCES Datos_Personales(IDDatosPersonales),
	sueldo MONEY NOT NULL,
	estado BIT NULL DEFAULT 1
)

CREATE TABLE Roles(
	IDRol TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(25) NOT NULL,
)

CREATE TABLE Usuarios(
	IDUsuario BIGINT NOT NULL FOREIGN KEY REFERENCES Empleados(IDEmpleado),
	ID_Rol TINYINT NOT NULL FOREIGN KEY REFERENCES Roles(IDRol),
	usuario VARCHAR(25) NOT NULL,
	clave VARCHAR(20) NOT NULL,
	estado BIT DEFAULT 1,
	PRIMARY KEY(IDUsuario)
)

CREATE TABLE Especialidades(
	IDEspecialidad SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(30) NOT NULL
)

CREATE TABLE Horarios(
	IDHorario BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Especialidad SMALLINT NULL FOREIGN KEY REFERENCES Especialidades(IDEspecialidad),
	ID_Empleado BIGINT NOT NULL FOREIGN KEY REFERENCES Empleados(IDEmpleado),
	horarioInicio TINYINT NOT NULL CHECK(horarioInicio BETWEEN 0 AND 24),
	horarioFin TINYINT NOT NULL CHECK(horarioFin BETWEEN 0 AND 24),
	CHECK (horarioFin > horarioInicio)
)

CREATE TABLE Secretarias(
	IDSecretaria SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Empleado BIGINT NOT NULL FOREIGN KEY REFERENCES Empleados(IDEmpleado)
)

CREATE TABLE Doctores(
	IDDoctor SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Empleado BIGINT NOT NULL FOREIGN KEY REFERENCES Empleados(IDEmpleado)
)

CREATE TABLE Administradores(
	IDAdministrador SMALLINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Empleado BIGINT NOT NULL FOREIGN KEY REFERENCES Empleados(IDEmpleado)
)

CREATE TABLE Pacientes(
	IDPaciente BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_DatosPersonales BIGINT NOT NULL FOREIGN KEY REFERENCES Datos_Personales(IDDatosPersonales)
)

CREATE TABLE Doctores_Especialidades(
	ID_Doctor SMALLINT NOT NULL FOREIGN KEY REFERENCES Doctores(IDDoctor),
	ID_Especialidad SMALLINT NOT NULL FOREIGN KEY REFERENCES Especialidades(IDEspecialidad),
	PRIMARY KEY (ID_Doctor,ID_Especialidad)
)

CREATE TABLE Estados_Turno(
	IDEstadoTurno TINYINT NOT NULL PRIMARY KEY IDENTITY (1,1),
	nombre VARCHAR(20) NOT NULL 
)

CREATE TABLE Turnos(
	IDTurno BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_Paciente BIGINT NOT NULL FOREIGN KEY REFERENCES Pacientes(IDPaciente),
	ID_Especialidad SMALLINT NOT NULL FOREIGN KEY REFERENCES Especialidades(IDEspecialidad),
	ID_Doctor SMALLINT NOT NULL FOREIGN KEY REFERENCES Doctores(IDDoctor),
	ID_Empleado BIGINT NOT NULL FOREIGN KEY REFERENCES Empleados(IDEmpleado),
	ID_EstadoTurno TINYINT NOT NULL FOREIGN KEY REFERENCES Estados_Turno(IDEstadoTurno),
	fecha DATE NULL CHECK(fecha >= GETDATE()),
	hora TINYINT NOT NULL CHECK(hora BETWEEN 0 AND 24)
)

CREATE TABLE Historiales(
	IDHistorial BIGINT NOT NULL FOREIGN KEY REFERENCES Turnos(IDTurno),
	fecha DATE NOT NULL,
	observaciones VARCHAR(300) NOT NULL,
	PRIMARY KEY(IDHistorial)
)

CREATE TABLE Permisos(
	IDPermiso TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(50) NOT NULL
)

CREATE TABLE Roles_Permisos(
	ID_Rol TINYINT NOT NULL FOREIGN KEY REFERENCES Roles(IDRol),
	ID_Permiso TINYINT NOT NULL FOREIGN KEY REFERENCES Permisos(IDPermiso),
	PRIMARY KEY (ID_Rol,ID_Permiso)
)

---------------------------------------------------
-------------------------DATOS---------------------
---------------------------------------------------

INSERT INTO Datos_Personales(nombre,apellido,dni,email,telefono) VALUES
('Ramon','Valdez',1234,'valdez@gmail.com',15779328),
('Sofia','Diaz',12345,'diaz@gmail.com',157796456),
('Romina','Ramirez',123456,'ramirez@gmail.com',1576634332),
('Raul','Valdez',1234567,'valdezr@gmail.com',15754812),
('Walter','Diaz',12345678,'walter@gmail.com',1577667638),
('Rosario','Vasquez',1234074,'r-vasquez@gmail.com',1577937466),
('Wal','Waldo',1233,'waldo@gmail.com',1574778788),
('Manu','Chao',12333,'manu@gmail.com',157897908)

INSERT INTO Empleados (ID_DatosPersonales,SueldO) VALUES
(1,120000),
(2,120000),
(3,70000),
(4,120000),
(5,150000),
(6,70000)

INSERT INTO Especialidades(nombre)VALUES 
('Kinesiologia'),
('Pediatria'),
('Traumatologo'),
('Cardiologia')

INSERT INTO Secretarias(ID_Empleado)VALUES
(3),
(6)

INSERT INTO Doctores(ID_Empleado)VALUES
(1),
(2),
(4)

INSERT INTO Administradores(ID_Empleado)VALUES
(5)

INSERT INTO Doctores_Especialidades(ID_Especialidad,ID_Doctor) VALUES
(1,1),
(1,2),
(1,3),
(2,2),
(3,1),
(4,1),
(4,3)

INSERT INTO Horarios(horarioInicio,horarioFin,ID_Empleado,ID_Especialidad)VALUES
(12,16,1,1),
(16,20,2,2),
(8,12,3,4),
(10,14,2,1),
(18,21,1,3)

INSERT INTO Pacientes(ID_DatosPersonales)VALUES
(7),
(8)

INSERT INTO Roles(nombre)VALUES 
('Doctor'),
('Secretaria'),
('Administrador')

INSERT INTO Usuarios (IDUsuario,ID_Rol,usuario,clave) VALUES
(1,1,'ramon','1234'),
(2,1,'sofia','1234'),
(3,2,'romina','1234'),
(4,1,'raul','1234'),
(5,3,'walter','1234'),
(6,2,'rosario','1234')

INSERT INTO Estados_Turno (nombre) VALUES 
('Atendido'),
('Esperando'),
('Cancelado')

INSERT INTO Turnos(ID_Especialidad,ID_Doctor,ID_Paciente,fecha,hora,ID_EstadoTurno,ID_Empleado) VALUES
(1,1,1,CAST('10-10-2023' AS DATE),10,2,3),
(2,2,2,CAST('08-11-2023' AS DATE),9,2,3),
(3,2,1,CAST('10-12-2022' AS DATE),19,2,3),
(3,3,2,CAST('10-12-2022' AS DATE),19,2,3),
(3,1,1,CAST('10-12-2022' AS DATE),19,2,3)


INSERT INTO Permisos (nombre) VALUES
('Ver pacientes'),
('Agregar pacientes'),
('Editar pacientes'),
('Ver turnos'),
('Agregar turnos'),
('Editar turnos'),
('Eliminar turnos'),
('Ver doctores'),
('Agregar doctores'),
('Editar doctores'),
('Asignar horarios doctores'),
('Asignar categoria doctores'),
('Agregar especialidades'),
('Ver historiales'),
('Agregar historiales'),
('Ver turnos para doctor'),
('Ver pacientes para doctor'),
('Ver horarios doctores'),
('Ver especialidades doctores'),
('Eliminar horarios doctores'),
('Quitar especialidades doctores'),
('Asignar especilidades doctores')

INSERT INTO Roles_Permisos(ID_Rol,ID_Permiso)VALUES
(2,1),
(2,2),
(2,3),
(2,4),
(2,5),
(2,6),
(2,7),
(3,8),
(3,9),
(3,10),
(3,11),
(3,12),
(3,13),
(3,18),
(3,19),
(3,20),
(3,21),
(3,22),
(1,14),
(1,15),
(1,16),
(1,17)





--------------------------------------------------------------------
---------------------PROCEDIMIENTOS ALMACENADOS---------------------
--------------------------------------------------------------------


EXEC SP_INSERTAR_PACIENTE 'test','apeTest','emailTest','telTest','dniTest' 
CREATE PROCEDURE SP_INSERTAR_PACIENTE 
(
	@nombre VARCHAR(30),
	@apellido VARCHAR(30),
	@email VARCHAR(30),
	@telefono VARCHAR(15),
	@dni VARCHAR(11) 
)
AS
BEGIN 
	BEGIN TRY
		
		DECLARE @ID BIGINT
		INSERT INTO Datos_Personales (nombre,apellido,dni,email,telefono) VALUES
		(@nombre,@apellido,@dni,@email,@telefono)

		SELECT TOP 1 @ID=IDDatosPersonales FROM Datos_Personales ORDER BY IDDatosPersonales DESC

		INSERT INTO Pacientes(ID_DatosPersonales) VALUES (@ID)

	END TRY
	BEGIN CATCH 
		--RAISERROR('ERROR AL INSERTAR',16,1)
		PRINT ERROR_MESSAGE()
	END CATCH
END

select  *  from Turnos

CREATE PROCEDURE SP_AGREGAR_DOCTOR(
	@nombre VARCHAR(30),
	@apellido VARCHAR(30),
	@dni VARCHAR(11),
	@email VARCHAR(30),
	@telefono VARCHAR(15),
	@sueldo MONEY,
	@IDEspecialidad SMALLINT,
	@horarioInicio TINYINT,
	@horarioFin TINYINT,
	@usuario VARCHAR(25),
	@clave VARCHAR(20)
)
AS 
BEGIN 
	BEGIN TRY 
		BEGIN TRANSACTION
			DECLARE @IDDatosPersonales BIGINT
			INSERT INTO Datos_Personales(nombre,apellido,dni,email,telefono) VALUES
			(@nombre,@apellido,@dni,@email,@telefono)

			SELECT TOP 1 @IDDatosPersonales =IDDatosPersonales FROM Datos_Personales ORDER BY IDDatosPersonales DESC

			DECLARE @IDEmpleado BIGINT
			INSERT INTO Empleados(ID_DatosPersonales,sueldo,estado) VALUES (@IDDatosPersonales,@sueldo,1)
			SELECT TOP 1 @IDEmpleado = IDEmpleado FROM Empleados ORDER BY IDEmpleado DESC

			DECLARE @IDRol TINYINT
			SELECT @IDRol=IDRol FROM Roles WHERE nombre = 'Doctor'
			INSERT INTO Usuarios(IDUsuario,ID_Rol,usuario,clave,estado) VALUES(@IDEmpleado,@IDRol,@usuario,@clave,1)

			INSERT INTO Doctores(ID_Empleado) VALUES (@IDEmpleado)

			INSERT INTO Horarios (horarioInicio,horarioFin,ID_Empleado,ID_Especialidad) VALUES
			(@horarioInicio,@horarioFin,@IDEmpleado,@IDEspecialidad)

			DECLARE @IDDoctor SMALLINT
			SELECT @IDDoctor=IDDoctor FROM Doctores WHERE ID_Empleado=@IDEmpleado
			INSERT INTO Doctores_Especialidades(ID_Doctor,ID_Especialidad) VALUES
			(@IDDoctor,@IDEspecialidad)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR('NO SE PUDO AGREGAR',16,1)
	END CATCH
END


CREATE PROCEDURE SP_MODIFICAR_DOCTOR(
	@IDDoctor SMALLINT,
	@nombre VARCHAR(30),
	@apellido VARCHAR(30),
	@email VARCHAR(30),
	@telefono VARCHAR(15),
	@sueldo MONEY,
	@usuario VARCHAR(25),
	@clave VARCHAR(20)
)
AS 
BEGIN 
	BEGIN TRY 
		BEGIN TRANSACTION
			
			DECLARE @IDEmpleado BIGINT
			DECLARE @IDDatosPersonales BIGINT
			DECLARE @IDUsuario BIGINT

			SELECT @IDEmpleado=IDEmpleado, @IDDatosPersonales=IDDatosPersonales,@IDUsuario=IDUsuario
			FROM Doctores AS d
			INNER JOIN Empleados AS e ON e.IDEmpleado = d.ID_Empleado
			INNER JOIN Datos_Personales AS dp ON dp.IDDatosPersonales=e.ID_DatosPersonales
			INNER JOIN Usuarios AS u ON u.IDUsuario = e.IDEmpleado WHERE d.IDDoctor=@IDDoctor

			UPDATE Empleados SET sueldo=@sueldo WHERE IDEmpleado = @IDEmpleado
			UPDATE Datos_Personales SET nombre=@nombre WHERE IDDatosPersonales = @IDDatosPersonales
			UPDATE Datos_Personales SET apellido=@apellido WHERE IDDatosPersonales = @IDDatosPersonales
			UPDATE Datos_Personales SET telefono=@telefono WHERE IDDatosPersonales = @IDDatosPersonales
			UPDATE Datos_Personales SET email=@email WHERE IDDatosPersonales = @IDDatosPersonales

			UPDATE Usuarios SET usuario=@usuario WHERE IDUsuario = @IDUsuario
			UPDATE Usuarios SET clave=@clave WHERE IDUsuario = @IDUsuario

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION
		RAISERROR('NO SE PUDO MODIFICAR',16,1)
	END CATCH
END 

CREATE PROCEDURE SP_AGREGAR_HORARIO_A_DOCTOR(
	@ID_Doctor SMALLINT,
	@horaInicio TINYINT,
	@horaFin TINYINT,
	@ID_Especialidad SMALLINT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @IDEmpleado BIGINT
			SELECT @IDEmpleado=ID_Empleado FROM Doctores WHERE IDDoctor=@ID_Doctor
			
			INSERT INTO Horarios(horarioInicio,horarioFin,ID_Especialidad,ID_Empleado)VALUES
			(@horaInicio,@horaFin,@ID_Especialidad,@IDEmpleado)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR('NO SE PUDO AGREGAR',16,1)
	END CATCH
END
----------------------------------------------------------
-------------------------TRIGGERS-------------------------
----------------------------------------------------------


CREATE TRIGGER TR_BAJA_LOGICA_TURNOS ON Turnos
INSTEAD OF DELETE
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @ID_Turno BIGINT
			SELECT @ID_Turno = IDTurno FROM deleted
			UPDATE Turnos SET ID_EstadoTurno=3 WHERE IDTurno=@ID_Turno
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR('No se pudo dar la baja',16,1)
	END CATCH
END

CREATE TRIGGER TR_AGREGAR_HISTORIAL ON Historiales
INSTEAD OF INSERT 
AS
BEGIN 
	BEGIN TRY
		BEGIN TRANSACTION
			DECLARE @IDHistorial BIGINT
			SELECT @IDHistorial = IDHistorial FROM inserted
			
			UPDATE Turnos SET ID_EstadoTurno=1 WHERE IDTurno=@IDHistorial
			INSERT INTO Historiales(IDHistorial,fecha,observaciones)
			SELECT IDHistorial,fecha,observaciones FROM inserted
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		RAISERROR('No se pudo insertar',16,1)
	END CATCH
END


----------------------------------
----------------------------------
-------PRUEBAS CON PERMISOS-------
----------------------------------
----------------------------------

select * from Permisos
insert into Permisos(nombre) values('Ver horarios doctores')
insert into Permisos(nombre) values('Eliminar horarios doctores')

insert into Permisos(nombre) values('Ver especialidades doctores')
insert into Permisos(nombre) values('Quitar especialidades doctores')
insert into Permisos(nombre) values('Asignar especilidades doctores')

select * from Roles AS r
inner join Roles_Permisos AS rp ON rp.ID_Rol=r.IDRol
inner join Permisos AS p On p.IDPermiso=rp.ID_Permiso
WHERE r.nombre = 'Secretaria'


delete from Roles_Permisos WHERE ID_Permiso=18 AND ID_Rol=1
delete from Roles_Permisos WHERE ID_Permiso=19 AND ID_Rol=1
delete from Roles_Permisos WHERE ID_Permiso=21 AND ID_Rol=3
INSERT INTO Roles_Permisos (ID_Permiso,ID_Rol) values(7,2)
INSERT INTO Roles_Permisos (ID_Permiso,ID_Rol) values(6,2)
INSERT INTO Roles_Permisos (ID_Permiso,ID_Rol) values(21,3)







-----------------------------------------------------------------
-------------------------VACIAR PROGRAMA-------------------------
-----------------------------------------------------------------

--Eliminar tambien los datos personales que no tienen pacientes ni empleados relacionados

DELETE FROM Especialidades
DELETE FROM Horarios
DELETE FROM Doctores_Especialidades
DELETE FROM Historiales
DELETE FROM Turnos
DELETE FROM Pacientes
DELETE FROM Datos_Personales where IDDatosPersonales=23

SELECT * FROM Horarios
SELECT * FROM Especialidades
SELECT * FROM Doctores_Especialidades
SELECT * FROM Historiales
SELECT * FROM Turnos
SELECT * FROM Pacientes
SELECT * From Datos_Personales
SELECT * FROM Pacientes AS p
INNER JOIN Datos_Personales AS dp ON dp.IDDatosPersonales=p.ID_DatosPersonales