-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 04-03-2025 a las 03:20:15
-- Versión del servidor: 8.0.41
-- Versión de PHP: 8.2.12
use asistenciadb;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `asistenciadb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asociados`
--
CREATE TABLE Usuarios (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL,
    Correo VARCHAR(100) NOT NULL UNIQUE,
    Contraseña VARCHAR(256) NOT NULL,
    Rol ENUM('Administrador', 'Asociado') NOT NULL,
    Estado ENUM('Activo', 'Inactivo') NOT NULL,
    FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Insertando usuarios en la tabla Usuarios
INSERT INTO `Usuarios` (`NombreUsuario`, `Correo`, `Contraseña`, `Rol`, `Estado`, `FechaRegistro`, `FechaModificacion`)
VALUES
('Juan Pérez', 'juan.perez@email.com', 'password1', 'Administrador', 'Activo', '2025-01-30 05:16:11', '2025-01-30 05:16:11'),
('María López', 'maria.lopez@email.com', 'password2', 'Asociado', 'Inactivo', '2025-01-30 05:16:11', '2025-01-30 05:16:11'),
('Pedro Quintero Artavia', 'quinarpe26@gmail.com', 'password3', 'Asociado', 'Activo', '2025-02-01 03:05:24', '2025-01-30 05:16:11'),
('GONZALEZ QUIROS PAOLA DANIELA', '1ab@aso.co.cr', 'password4', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('GRANADOS CORDERO MARIA JOSE', '1ab@aso.co.cr', 'password5', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('HERNANDEZ RODRIGUEZ DAVID JAVIER', '1ab@aso.co.cr', 'password6', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('HERRERA OVIEDO FEDERICO', '1ab@aso.co.cr', 'password7', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('HERRERA QUIROS JOSE MIGUEL', '1ab@aso.co.cr', 'password8', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('HIDALGO CALDERON IGNACIO', '1ab@aso.co.cr', 'password9', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('JARA CARBALLO GRACIELA', '1ab@aso.co.cr', 'password10', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('JIMENEZ VILLEGAS ALVARO', '1ab@aso.co.cr', 'password11', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('JOHNSON MATA ANGIE JACKELINE', '1ab@aso.co.cr', 'password12', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('LAITANO RODRIGUEZ MARIO', '1ab@aso.co.cr', 'password13', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('LEIVA OROZCO CINDY PATRICIA', '1ab@aso.co.cr', 'password14', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MARIN ARRIETA JUAN CARLOS', '1ab@aso.co.cr', 'password15', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MEZA LEANDRO HENRY', '1ab@aso.co.cr', 'password16', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MONDRAGON ROJAS JUAN PABLO', '1ab@aso.co.cr', 'password17', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MONGE AGUILAR NIDYA ISABEL', '1ab@aso.co.cr', 'password18', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MONGE GARRO RODOLFO ALEXANDER', '1ab@aso.co.cr', 'password19', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MONGE MARIN MONICA', '1ab@aso.co.cr', 'password20', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MORA MIRANDA RAUL', '1ab@aso.co.cr', 'password21', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MUNOZ LEIVA MICHAEL', '1ab@aso.co.cr', 'password22', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('MURILLO LORIA JACQUELINE', '1ab@aso.co.cr', 'password23', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('NAVARRO OLIVER GERMAN', '1ab@aso.co.cr', 'password24', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('NAVARRO RODRIGUEZ CHRISTOPHER', '1ab@aso.co.cr', 'password25', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('ORTEGA VILLALOBOS ISABEL', '1ab@aso.co.cr', 'password26', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('OVARES CORDOBA ADRIAN', '1ab@aso.co.cr', 'password27', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('OVARES VILLAR JOHANNA', '1ab@aso.co.cr', 'password28', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('PICADO REYES ABY', '1ab@aso.co.cr', 'password29', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('QUESADA MOYA OMAR EMILIO', '1ab@aso.co.cr', 'password30', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('RAMOS NAVARRO CHRISTIAN', '1ab@aso.co.cr', 'password31', 'Asociado', 'Activo', '2025-02-01 04:33:24', '2025-01-30 05:16:11'),
('RETANA BONILLA ALFREDO', '1ab@aso.co.cr', 'password32', 'Asociado', 'Inactivo', '2025-02-01 04:33:24', '2025-01-30 05:16:11');



CREATE TABLE Asociados (
    IdAsociado INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    NumeroCedula VARCHAR(20) NOT NULL UNIQUE,
    Estatus1 ENUM('Activo', 'Inactivo') NOT NULL,
    Estado2 ENUM('Verificado', 'Confirmado', 'Pendiente', 'No') NOT NULL,
    Correo VARCHAR(100) NOT NULL UNIQUE,
    Telefono VARCHAR(20) NOT NULL,
    FechaRegistro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaModificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    IdUsuario INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

--
-- Volcado de datos para la tabla `asociados`
--

INSERT INTO `asociados` ( `Nombre`, `NumeroCedula`, `Estatus1`, `Estado2`, `Correo`, `Telefono`, `FechaRegistro`,`FechaModificacion`,`IdUsuario`) VALUES
( 'Juan Pérez', '123456789', 'Activo', 'Verificado', 'juan.perez@email.com', '555-1234', '2025-01-30 05:16:11','2025-01-30 05:16:11',1),
( 'María López', '987654321', 'Inactivo', 'Pendiente', 'maria.lopez@email.com', '555-5678', '2025-01-30 05:16:11','2025-01-30 05:16:11',2),
( 'Pedro Quintero Artavia ', '117390526', 'Activo', 'Verificado', 'quinarpe26@gmail.com', '83035390', '2025-02-01 03:05:24','2025-01-30 05:16:11',3),
( 'GONZALEZ QUIROS PAOLA DANIELA', '111111222', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-199', '2025-02-01 04:33:24','2025-01-30 05:16:11',4),
( 'GRANADOS CORDERO MARIA JOSE', '111111223', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-200', '2025-02-01 04:33:24','2025-01-30 05:16:11',5),
( 'HERNANDEZ RODRIGUEZ DAVID JAVIER', '111111224', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-201', '2025-02-01 04:33:24','2025-01-30 05:16:11',6),
( 'HERRERA OVIEDO FEDERICO', '111111225', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-202', '2025-02-01 04:33:24','2025-01-30 05:16:11',7),
( 'HERRERA QUIROS JOSE MIGUEL', '111111226', 'Inactivo', 'Confirmado', '1ab@aso.co.cr', '8888-88-203', '2025-02-01 04:33:24','2025-01-30 05:16:11',8),
( 'HIDALGO CALDERON IGNACIO', '111111227', 'Inactivo', 'No', '1ab@aso.co.cr', '8888-88-204', '2025-02-01 04:33:24','2025-01-30 05:16:11',9),
( 'JARA CARBALLO GRACIELA', '111111228', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-205', '2025-02-01 04:33:24','2025-01-30 05:16:11',10),
( 'JIMENEZ VILLEGAS ALVARO', '111111229', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-206', '2025-02-01 04:33:24','2025-01-30 05:16:11',11),
( 'JOHNSON MATA ANGIE JACKELINE', '111111230', 'Inactivo', 'Confirmado', '1ab@aso.co.cr', '8888-88-207', '2025-02-01 04:33:24','2025-01-30 05:16:11',12),
( 'LAITANO RODRIGUEZ MARIO', '111111231', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-208', '2025-02-01 04:33:24','2025-01-30 05:16:11',13),
( 'LEIVA OROZCO CINDY PATRICIA', '111111232', 'Activo', 'No', '1ab@aso.co.cr', '8888-88-209', '2025-02-01 04:33:24','2025-01-30 05:16:11',14),
( 'MARIN ARRIETA JUAN CARLOS', '111111233', 'Inactivo', 'No', '1ab@aso.co.cr', '8888-88-210', '2025-02-01 04:33:24','2025-01-30 05:16:11',15),
( 'MEZA LEANDRO HENRY', '111111234', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-211', '2025-02-01 04:33:24','2025-01-30 05:16:11',16),
( 'MONDRAGON ROJAS JUAN PABLO', '111111235', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-212', '2025-02-01 04:33:24','2025-01-30 05:16:11',17),
( 'MONGE AGUILAR NIDYA ISABEL', '111111236', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-213', '2025-02-01 04:33:24','2025-01-30 05:16:11',18),
( 'MONGE GARRO RODOLFO ALEXANDER', '111111237', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-214', '2025-02-01 04:33:24','2025-01-30 05:16:11',19),
( 'MONGE MARIN MONICA', '111111238', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-215', '2025-02-01 04:33:24','2025-01-30 05:16:11',20),
( 'MORA MIRANDA RAUL', '111111239', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-216', '2025-02-01 04:33:24','2025-01-30 05:16:11',21),
( 'MUNOZ LEIVA MICHAEL', '111111240', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-217', '2025-02-01 04:33:24','2025-01-30 05:16:11',22),
( 'MURILLO LORIA JACQUELINE', '111111241', 'Inactivo', 'No', '1ab@aso.co.cr', '8888-88-218', '2025-02-01 04:33:24','2025-01-30 05:16:11',23),
( 'NAVARRO OLIVER GERMAN', '111111242', 'Inactivo', 'Confirmado', '1ab@aso.co.cr', '8888-88-219', '2025-02-01 04:33:24','2025-01-30 05:16:11',24),
( 'NAVARRO RODRIGUEZ CHRISTOPHER', '111111243', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-220', '2025-02-01 04:33:24','2025-01-30 05:16:11',25),
( 'ORTEGA VILLALOBOS ISABEL', '111111244', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-221', '2025-02-01 04:33:24','2025-01-30 05:16:11',26),
( 'OVARES CORDOBA ADRIAN', '111111245', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-222', '2025-02-01 04:33:24','2025-01-30 05:16:11',27),
( 'OVARES VILLAR JOHANNA', '111111246', 'Activo', 'Confirmado', '1ab@aso.co.cr', '8888-88-223', '2025-02-01 04:33:24','2025-01-30 05:16:11',28),
( 'PICADO REYES ABY', '111111247', 'Activo', 'No', '1ab@aso.co.cr', '8888-88-224', '2025-02-01 04:33:24','2025-01-30 05:16:11',29),
( 'QUESADA MOYA OMAR EMILIO', '111111248', 'Activo', 'No', '1ab@aso.co.cr', '8888-88-225', '2025-02-01 04:33:24','2025-01-30 05:16:11',30),
( 'RAMOS NAVARRO CHRISTIAN', '111111249', 'Activo', 'No', '1ab@aso.co.cr', '8888-88-226', '2025-02-01 04:33:24','2025-01-30 05:16:11',31),
( 'RETANA BONILLA ALFREDO', '111111250', 'Inactivo', 'Confirmado', '1ab@aso.co.cr', '8888-88-227', '2025-02-01 04:33:24','2025-01-30 05:16:11',32);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `padron_asociados`
--

CREATE TABLE `padron_asociados` (
  `COL 1` varchar(109) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Volcado de datos para la tabla `padron_asociados`
--

INSERT INTO `padron_asociados` (`COL 1`) VALUES
('Id;Nombre;Número Cédula;Estatus 1;Estado 2 ;Correo;Telefono'),
('00000111;GONZALEZ QUIROS PAOLA DANIELA               ;111111222;Activo;Confirmado;1ab@aso.co.cr;8888-88-199'),
('00000112;GRANADOS CORDERO MARIA JOSE                 ;111111223;Activo;Confirmado;1ab@aso.co.cr;8888-88-200'),
('00000113;HERNANDEZ RODRIGUEZ DAVID JAVIER            ;111111224;Activo;Confirmado;1ab@aso.co.cr;8888-88-201'),
('00000114;HERRERA OVIEDO FEDERICO                     ;111111225;Activo;Confirmado;1ab@aso.co.cr;8888-88-202'),
('00000115;HERRERA QUIROS JOSE MIGUEL                  ;111111226;Inactivo;Confirmado;1ab@aso.co.cr;8888-88-203'),
('00000116;HIDALGO CALDERON IGNACIO                    ;111111227;Inactivo;No;1ab@aso.co.cr;8888-88-204'),
('00000117;JARA CARBALLO GRACIELA                      ;111111228;Activo;Confirmado;1ab@aso.co.cr;8888-88-205'),
('00000118;JIMENEZ VILLEGAS ALVARO                     ;111111229;Activo;Confirmado;1ab@aso.co.cr;8888-88-206'),
('00000119;JOHNSON MATA ANGIE JACKELINE                ;111111230;Inactivo;Confirmado;1ab@aso.co.cr;8888-88-207'),
('00000120;LAITANO RODRIGUEZ MARIO                     ;111111231;Activo;Confirmado;1ab@aso.co.cr;8888-88-208'),
('00000121;LEIVA OROZCO CINDY PATRICIA                 ;111111232;Activo;No;1ab@aso.co.cr;8888-88-209'),
('00000122;MARIN ARRIETA JUAN CARLOS                   ;111111233;Inactivo;No;1ab@aso.co.cr;8888-88-210'),
('00000123;MEZA LEANDRO HENRY                          ;111111234;Activo;Confirmado;1ab@aso.co.cr;8888-88-211'),
('00000124;MONDRAGON ROJAS JUAN PABLO                  ;111111235;Activo;Confirmado;1ab@aso.co.cr;8888-88-212'),
('00000125;MONGE AGUILAR NIDYA ISABEL                  ;111111236;Activo;Confirmado;1ab@aso.co.cr;8888-88-213'),
('00000126;MONGE GARRO RODOLFO ALEXANDER               ;111111237;Activo;Confirmado;1ab@aso.co.cr;8888-88-214'),
('00000127;MONGE MARIN MONICA                          ;111111238;Activo;Confirmado;1ab@aso.co.cr;8888-88-215'),
('00000128;MORA MIRANDA RAUL                           ;111111239;Activo;Confirmado;1ab@aso.co.cr;8888-88-216'),
('00000129;MUNOZ LEIVA MICHAEL                         ;111111240;Activo;Confirmado;1ab@aso.co.cr;8888-88-217'),
('00000130;MURILLO LORIA JACQUELINE                    ;111111241;Inactivo;No;1ab@aso.co.cr;8888-88-218'),
('00000131;NAVARRO OLIVER GERMAN                       ;111111242;Inactivo;Confirmado;1ab@aso.co.cr;8888-88-219'),
('00000132;NAVARRO RODRIGUEZ CHRISTOPHER               ;111111243;Activo;Confirmado;1ab@aso.co.cr;8888-88-220'),
('00000133;ORTEGA VILLALOBOS ISABEL                    ;111111244;Activo;Confirmado;1ab@aso.co.cr;8888-88-221'),
('00000134;OVARES CORDOBA ADRIAN                       ;111111245;Activo;Confirmado;1ab@aso.co.cr;8888-88-222'),
('00000135;OVARES VILLAR JOHANNA                       ;111111246;Activo;Confirmado;1ab@aso.co.cr;8888-88-223'),
('00000136;PICADO REYES ABY                            ;111111247;Activo;No;1ab@aso.co.cr;8888-88-224'),
('00000137;QUESADA MOYA OMAR EMILIO                    ;111111248;Activo;No;1ab@aso.co.cr;8888-88-225'),
('00000138;RAMOS NAVARRO CHRISTIAN                     ;111111249;Activo;No;1ab@aso.co.cr;8888-88-226'),
('00000139;RETANA BONILLA ALFREDO                      ;111111250;Inactivo;Confirmado;1ab@aso.co.cr;8888-88-227');

CREATE TABLE Eventos (
    IdEvento INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Fecha DATETIME NOT NULL,
    Descripcion TEXT,
    Lugar VARCHAR(255),
    Cupo INT NOT NULL,
    Estado ENUM('Activo', 'Inactivo') DEFAULT 'Activo',
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Eventos (Nombre, Fecha, Descripcion, Lugar, Cupo, Estado)
VALUES
('Conferencia: El Arte de Ser Mangoneado', '2025-04-15 10:00:00', 'Un espacio para compartir experiencias sobre cómo manejar las dinámicas del hogar bajo la guía experta de un mangoneador.', 'Centro de Convenciones Mangoneados', 100, 'Activo'),
('Taller: Cómo Decir "Sí Querida"', '2025-04-20 14:00:00', 'Un taller intensivo para aprender a ser un excelente seguidor de las órdenes de la jefa del hogar.', 'Auditorio Asociación Hombre Mangoneados', 50, 'Activo'),
('Feria: Tecnología y Mangoneo', '2025-05-05 09:00:00', 'Explora las herramientas tecnológicas que ayudan a los mangoneados a cumplir tareas con eficiencia.', 'Plaza Central de Mangoneados', 150, 'Activo'),
('Competencia: El Mangoneado del Año', '2025-06-10 17:00:00', 'Evento de premiación para el hombre que mejor cumple su papel en casa.', 'Estadio Mangoneado 2025', 300, 'Activo'),
('Charla: Cómo Sobrevivir al Mandato', '2025-06-25 15:00:00', 'Un orador experto compartirá técnicas avanzadas de adaptación y supervivencia bajo el mandato.', 'Centro Cultural Mangoneado', 200, 'Activo'),
('Encuentro: Hermanos Mangoneados Unidos', '2025-07-10 10:00:00', 'Reunión de hombres que buscan apoyo mutuo y comparten sus historias de éxito en la mangoneada.', 'Salón Mangoneados Unidos', 80, 'Activo'),
('Taller Avanzado: Cómo Ser el Mejor Mangoneado', '2025-08-01 09:00:00', 'Un curso avanzado para perfeccionar tus habilidades y ser el orgullo del hogar.', 'Centro de Innovación Mangoneados', 60, 'Activo');

CREATE TABLE Asistencias (
    IdAsistencia INT AUTO_INCREMENT PRIMARY KEY,
    IdAsociado INT NOT NULL,
    IdEvento INT NOT NULL,
    EstadoAsistencia ENUM('Pendiente', 'Confirmada', 'Cancelada') DEFAULT 'Pendiente',
    CodigoQR VARCHAR(255),
    FechaConfirmacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdAsociado) REFERENCES Asociados(IdAsociado) ON DELETE CASCADE,
    FOREIGN KEY (IdEvento) REFERENCES Eventos(IdEvento) ON DELETE CASCADE
);


INSERT INTO Asistencias (IdAsociado, IdEvento, EstadoAsistencia, CodigoQR)
VALUES
-- Asociado 1
(1, 1, 'Confirmada', 'QR12345'),
(1, 2, 'Pendiente', 'QR12346'),
(1, 3, 'Cancelada', 'QR12347'),

-- Asociado 2
(2, 1, 'Pendiente', 'QR22345'),
(2, 4, 'Confirmada', 'QR22346'),
(2, 5, 'Pendiente', 'QR22347'),

-- Asociado 3
(3, 2, 'Confirmada', 'QR32345'),
(3, 3, 'Pendiente', 'QR32346'),
(3, 5, 'Confirmada', 'QR32347');


CREATE TABLE PlantillasCorreo (
    IdPlantilla INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL, -- Nombre descriptivo de la plantilla
    Asunto VARCHAR(150) NOT NULL, -- Asunto del correo
    Cuerpo TEXT NOT NULL,         -- Contenido del correo con variables
    Tipo ENUM('Registro', 'Asistencia', 'Recordatorio') NOT NULL,
    IdUsuario INT, -- Relación con el usuario que creó la plantilla
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) ON DELETE SET NULL
);


INSERT INTO PlantillasCorreo (Nombre, Asunto, Cuerpo, Tipo, IdUsuario)
VALUES
-- Plantillas de tipo 'Registro'
('Bienvenida a la plataforma', 
 '¡Bienvenido a nuestra comunidad!', 
 'Hola {Nombre},\n\nGracias por unirte a nuestra plataforma. Estamos encantados de tenerte con nosotros.\n\nTu número de asociado es: {NumeroAsociado}.\n\nSaludos,\nEl equipo', 
 'Registro', 
 1),

('Confirmación de registro', 
 'Confirmación de tu cuenta en nuestra plataforma', 
 'Hola {Nombre},\n\nTe confirmamos que tu cuenta ha sido registrada exitosamente. Puedes acceder a todos los beneficios de nuestra plataforma.\n\nSaludos,\nEl equipo', 
 'Registro', 
 2),

-- Plantillas de tipo 'Asistencia'
('Confirmación de asistencia', 
 'Tu asistencia ha sido confirmada', 
 'Hola {Nombre},\n\nTe confirmamos que tu asistencia al evento "{Evento}" ha sido registrada con éxito. Te esperamos en {Lugar} el día {FechaEvento}.\n\nGracias,\nEl equipo', 
 'Asistencia', 
 3),

('Invitación a un evento', 
 'Te invitamos al evento: {Evento}', 
 'Hola {Nombre},\n\nQueremos invitarte al evento "{Evento}". Tendrá lugar en {Lugar} el día {FechaEvento}. Regístrate ahora para asegurar tu lugar.\n\nGracias,\nEl equipo', 
 'Asistencia', 
 4),

-- Plantillas de tipo 'Recordatorio'
('Recordatorio de evento', 
 'Recordatorio: Evento "{Evento}"', 
 'Hola {Nombre},\n\nEste es un recordatorio del evento "{Evento}". Se llevará a cabo en {Lugar} el día {FechaEvento}. Por favor, no olvides traer tu código QR para confirmar tu asistencia.\n\nGracias,\nEl equipo', 
 'Recordatorio', 
 5),

('Recordatorio de actualización de datos', 
 'Por favor, actualiza tus datos', 
 'Hola {Nombre},\n\nQueremos recordarte que es importante mantener tus datos actualizados para seguir disfrutando de nuestros servicios. Visita tu perfil para actualizar tu información.\n\nSaludos,\nEl equipo', 
 'Recordatorio', 
 2);

CREATE TABLE CorreosEnviados (
    IdCorreos INT AUTO_INCREMENT PRIMARY KEY,
    IdAsociado INT NOT NULL,
    IdPlantilla INT NOT NULL,
    FechaEnvio DATETIME DEFAULT CURRENT_TIMESTAMP,
    Estado ENUM('Enviado', 'Fallido') DEFAULT 'Enviado',
    FOREIGN KEY (IdAsociado) REFERENCES Asociados(IdAsociado),
    FOREIGN KEY (IdPlantilla) REFERENCES PlantillasCorreo(IdPlantilla)
);


INSERT INTO CorreosEnviados (IdAsociado, IdPlantilla, FechaEnvio, Estado)
VALUES
-- Correos de bienvenida enviados con éxito
(1, 1, '2025-03-01 08:00:00', 'Enviado'),
(2, 1, '2025-03-01 08:30:00', 'Enviado'),
(3, 1, '2025-03-01 09:00:00', 'Enviado'),

-- Correos de confirmación de registro (algunos fallidos)
(4, 2, '2025-03-02 10:00:00', 'Enviado'),
(5, 2, '2025-03-02 10:30:00', 'Fallido'),
(6, 2, '2025-03-02 11:00:00', 'Enviado'),

-- Invitaciones a eventos
(7, 4, '2025-03-03 14:00:00', 'Enviado'),
(8, 4, '2025-03-03 14:30:00', 'Fallido'),
(9, 4, '2025-03-03 15:00:00', 'Enviado'),
(10, 4, '2025-03-03 15:30:00', 'Enviado'),

-- Recordatorios de eventos
(11, 5, '2025-03-04 16:00:00', 'Enviado'),
(12, 5, '2025-03-04 16:30:00', 'Enviado'),
(13, 5, '2025-03-04 17:00:00', 'Fallido'),

-- Recordatorios de actualización de datos
(14, 6, '2025-03-05 09:00:00', 'Enviado'),
(15, 6, '2025-03-05 09:30:00', 'Fallido'),
(16, 6, '2025-03-05 10:00:00', 'Enviado');



CREATE TABLE HistorialEventos (
    IdHistorialEventos INT AUTO_INCREMENT PRIMARY KEY,
    IdEvento INT NOT NULL,
    IdAsociado INT,
    Accion ENUM('Creación', 'Modificación', 'Confirmación Asistencia', 'Cancelación') NOT NULL, -- Acción realizada
    IdUsuario INT NOT NULL, -- Usuario que realizó la acción
    FechaAccion DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de la acción
    Descripcion TEXT, -- Detalles adicionales
    FOREIGN KEY (IdEvento) REFERENCES Eventos(IdEvento) ON DELETE CASCADE,
    FOREIGN KEY (IdAsociado) REFERENCES Asociados(IdAsociado) ON DELETE CASCADE,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) ON DELETE CASCADE
);

INSERT INTO HistorialEventos (IdEvento, IdAsociado, Accion, IdUsuario, FechaAccion, Descripcion)
VALUES
(1, 5, 'Confirmación Asistencia', 1, '2025-03-18 08:30:00', 'El asociado asistió al evento.'),
(1, 6, 'Confirmación Asistencia', 1, '2025-03-18 09:00:00', 'El asociado asistió al evento.'),
(2, 7, 'Confirmación Asistencia', 2, '2025-03-19 10:00:00', 'El asociado asistió al evento.'),
(2, 8, 'Confirmación Asistencia', 2, '2025-03-19 10:30:00', 'El asociado asistió al evento.');



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
