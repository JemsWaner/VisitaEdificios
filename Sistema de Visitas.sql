	create database VisitasSistema;

	use VisitasSistema;

	create table carrera(
	id_carrera int primary key auto_increment,
	carrera_nombre varchar(100)
	);

	create table edificio(
	id_edificio int primary key auto_increment,
	edificio_nombre varchar(100)
	);

	create table aula(
	id_aula int primary key auto_increment,
	aula_nombre varchar(100)
	);

	create table tipo_usuario(
	id_tipo int primary key auto_increment,
	tipo_usuario varchar(100)
	);

	create table solicitud(
	id_solicitud int primary key auto_increment comment '1- pendiente, 2- aprovada, 3-cancelada',
	estado_solicitud varchar(100)
	);

	create table usuario(
	id_usuario int primary key auto_increment,
	id_carrera int,
	id_edificio int,
	id_aula int,
	id_tipo int default 1,
	id_solicitud int default 1,
	nombre varchar(100),
	apellido varchar(100),
	correo varchar(200),
	contrasena varchar(20),
	motivo_visita varchar(1000),
	hora_entrada date,
	hora_salida date,
	fecha_nacimiento date,

	constraint `carrera` foreign key(id_carrera) references carrera(id_carrera),
	constraint `edificio` foreign key(id_edificio) references edificio(id_edificio),
	constraint `aula` foreign key(id_aula) references aula(id_aula),
	constraint `tipousuario` foreign key(id_tipo) references tipo_usuario(id_tipo),
	constraint `solicitud` foreign key(id_solicitud) references solicitud(id_solicitud)
	);

	-- Los inserts
	INSERT INTO carrera (carrera_nombre) VALUES
	('Ingeniería en Sistemas de Información'),
	('Ingeniería en Computación'),
	('Ingeniería en Software'),
	('Tecnología en Desarrollo de Aplicaciones Web'),
	('Tecnología en Redes y Comunicaciones');

	INSERT INTO edificio (edificio_nombre) VALUES
	('Edificio 1'),('Edificio 2'),('Edificio 3'),('Edificio 4');

	INSERT INTO aula (aula_nombre) VALUES
	('Aula 101'),
	('Aula 102'),
	('Aula 103'),
	('Laboratorio 1'),
	('Laboratorio 2');

	INSERT INTO tipo_usuario (tipo_usuario) VALUES
	('Usuario'),
	('Admin');

	INSERT INTO solicitud(estado_solicitud) Values
	('pendiente'),('aprovada'),('cancelada');

	-- Los procedures

	-- ////////////////// Insertar usuarios
	DELIMITER //
	CREATE PROCEDURE InsertarUsuario(
		IN nombreUsuario VARCHAR(100),
		IN apellidoUsuario VARCHAR(100),
		IN correoUsuario VARCHAR(200),
		IN contrasenaUsuario VARCHAR(20),
		IN motivoVisita VARCHAR(1000),
		IN idCarrera VARCHAR(200),
		IN idEdificio VARCHAR(200),
		IN idAula VARCHAR(200),
		IN horaentrada date,
		IN horasalida date
	)
	BEGIN
		declare idCarreraModifi int;
		declare idEdificioModifi int;
		declare idAulaModifi int;
		
		select id_carrera into idCarreraModifi from carrera where carrera_nombre= idCarrera;
		select id_edificio into idEdificioModifi from edificio where edificio_nombre= idEdificio;
		select id_aula into idAulaModifi from aula where aula_nombre= idAula;
		
		INSERT INTO usuario (nombre, apellido, correo, contrasena, motivo_visita, id_carrera, id_edificio, id_aula, hora_entrada, hora_salida)
		VALUES (nombreUsuario, apellidoUsuario, correoUsuario, contrasenaUsuario, motivoVisita, idCarreraModifi, idEdificioModifi, idAulaModifi, horaentrada,horasalida);
	END;
	//
	DELIMITER ;

	CALL InsertarUsuario('Juan', 'Pérez', 'juan@gmail.com', '123456', 'Visita de orientación', 1, 1, 1,'2004-12-24','2024-12-24');

	-- /////////////// Crear nuevo usuario
	DELIMITER //
	CREATE PROCEDURE InsertarNuevoUsuario(
		IN nombre VARCHAR(100),
		IN apellido VARCHAR(100),
		IN contrasenaUsuario VARCHAR(20),
		IN fechaNacimiento DATE,
		IN tipoUsuario VARCHAR(20)
	)
	BEGIN
		DECLARE idTipo INT;

		-- Obtener el ID del tipo de usuario
		SELECT id_tipo INTO idTipo FROM tipo_usuario WHERE tipo_usuario = tipoUsuario;

		-- Insertar el nuevo usuario en la tabla
		INSERT INTO usuario (nombre, apellido,contrasena, fecha_nacimiento, id_tipo)
		VALUES (nombre, apellido, contrasenaUsuario, fechaNacimiento, idTipo);
	END;
	//
	DELIMITER ;

	CALL InsertarNuevoUsuario('AdminNuevo', 'ApellidoAdminNuevo', 'admin123', '2000-01-11', 'Admin');

	DELIMITER //
	CREATE PROCEDURE ActualizarUsuario(
		IN idUsuario INT,
		IN nombreUsuario VARCHAR(100),
		IN apellidoUsuario VARCHAR(100),
		IN correoUsuario VARCHAR(200),
		IN contrasenaUsuario VARCHAR(20),
		IN motivoVisita VARCHAR(1000),
		IN idCarrera varchar(200),
		IN idEdificio varchar(200),
		IN idAula VARCHAR(200),
		IN horaEntrada DATE,
		IN horaSalida DATE
	)
	BEGIN
		declare idCarreraModifi int;
		declare idEdificioModifi int;
		declare idAulaModifi int;
		
		select id_carrera into idCarreraModifi from carrera where carrera_nombre= idCarrera;
		select id_edificio into idEdificioModifi from edificio where edificio_nombre= idEdificio;
		select id_aula into idAulaModifi from aula where aula_nombre= idAula;

		UPDATE usuario
		SET nombre = nombreUsuario,
			apellido = apellidoUsuario,
			correo = correoUsuario,
			contrasena = contrasenaUsuario,
			motivo_visita = motivoVisita,
			id_carrera = idCarreraModifi,
			id_edificio = idEdificioModifi,
			id_aula = idAulaModifi,
			hora_entrada = horaEntrada,
			hora_salida = horaSalida
		WHERE id_usuario = idUsuario;
	END;
	//
	DELIMITER ;

	DELIMITER //
	CREATE PROCEDURE ActualizarTipoYSolicitud(
		IN idUsuario INT,
		IN tipoSolicitud varchar(50),
		IN tipoUsuario varchar(50)
	)
	BEGIN
		declare SolicitudModifi int;
		declare UsuarioModifi int;
		
		select id_solicitud into SolicitudModifi from solicitud where estado_solicitud= tipoSolicitud;
		select id_tipo into UsuarioModifi from tipo_usuario where tipo_usuario = tipoUsuario;

		UPDATE usuario
		SET id_solicitud= SolicitudModifi,  
			id_tipo= UsuarioModifi
		WHERE id_usuario = idUsuario;
		
	END;
	//
	DELIMITER ;

	-- //////////////Obtener usuarios por cada edicio
	DELIMITER //
	CREATE PROCEDURE ObtenerUsuariosPorEdificio(
		IN idEdificio INT
	)
	BEGIN
		SELECT u.id_usuario, u.nombre, u.apellido, u.correo, u.motivo_visita
		FROM usuario u
		WHERE u.id_edificio = idEdificio;
	END;
	//
	DELIMITER ;

	DELIMITER //
	CREATE PROCEDURE ObtenerListaUsuarios()
	BEGIN
		SELECT u.id_usuario, u.nombre, u.apellido
		FROM usuario u;
	END;
	//
	DELIMITER ;

	DELIMITER //
	CREATE PROCEDURE ObtenerEstado(id_nuevo int)
	BEGIN
		SELECT TipoUser.tipo_usuario from usuario 
		inner join tipo_usuario as TipoUser on usuario.id_tipo= TipoUser.id_tipo where id_usuario=id_nuevo;
	END;
	//
	DELIMITER ;

	DELIMITER //
	CREATE PROCEDURE ObtenerSolicitud()
	BEGIN
		SELECT estado_solicitud
		FROM solicitud;

	END;
	//
	DELIMITER ;

DELIMITER //
CREATE PROCEDURE IniciarSesion(
    IN nombreUsuario VARCHAR(200),
    IN contrasenaUsuario VARCHAR(20)
)
BEGIN
    DECLARE usuarioEncontrado INT;
    DECLARE idUsuario INT;

    -- Verificar si el correo y la contraseña coinciden
    SELECT COUNT(*) INTO usuarioEncontrado
    FROM usuario
    WHERE nombre = nombreUsuario AND contrasena = contrasenaUsuario;

    -- Si se encuentra un usuario con el correo y contraseña proporcionados, devolver 1 y el ID del usuario
    -- De lo contrario, devolver 0 y NULL como ID del usuario
    IF usuarioEncontrado > 0 THEN
        SELECT 1 AS 'Inicio de sesión exitoso', id_usuario
        FROM usuario
        WHERE nombre = nombreUsuario AND contrasena = contrasenaUsuario
        GROUP BY id_usuario;
    ELSE
        SELECT 0 AS 'Correo o contraseña incorrectos', NULL;
    END IF;
END;
//
DELIMITER ;

	call ObtenerCamposUsuario(1);
	call ObtenerSolicitud();
	select * from usuario;

-- drop database VisitasSistema;