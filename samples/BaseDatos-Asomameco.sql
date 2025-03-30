
#create schema asomameco;

-- use asomameco;

CREATE TABLE Asociated (
    UserIdentity 	VARCHAR(9)		NOT NULL PRIMARY KEY,
    FullName		VARCHAR(100)	NOT NULL,
    Email			VARCHAR(320)	NOT NULL UNIQUE,
    Phone			VARCHAR(20)		NOT NULL,
    CreatedDate		TIMESTAMP		NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ModifiedDate	TIMESTAMP 		NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE Events (
    EventID			INT				NOT NULL PRIMARY KEY AUTO_INCREMENT,
    EventName		VARCHAR(100) 	NOT NULL,
    EventDate		DATETIME		NOT NULL,
    Description		VARCHAR(500)	NOT NULL,
    Location		VARCHAR(200)	NOT NULL,
    Capacity 		INT				NOT NULL,
    IsActive		BIT				NOT NULL 	DEFAULT 1,
    FechaCreacion	DATETIME 		NOT NULL	DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Asistance (
    AssistanceId        INT 					NOT NULL PRIMARY KEY AUTO_INCREMENT,
    UserIdentity        VARCHAR(9)				NOT NULL,
    EventID             INT						NOT NULL,
    State               ENUM('P', 'C', 'R')     NOT NULL	DEFAULT 'P',
    ConfirmationDate    TIMESTAMP               NOT NULL	DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT AsistanceAsociated_FK	FOREIGN KEY (UserIdentity)
    REFERENCES Asociated(UserIdentity) 	ON DELETE CASCADE,
    CONSTRAINT AsistanceEvents_FK		FOREIGN KEY (EventID)
    REFERENCES Events(EventID) 			ON DELETE CASCADE
);




INSERT INTO Asociated (FullName, UserIdentity, Email, Phone, CreatedDate, ModifiedDate) VALUES
( 'Juan Pérez', '123456789', 'juan.perez@aso.co.cr', '555-1234', '2025-01-30 05:16:11','2025-01-30 05:16:11'),
( 'María López', '987654321', 'maria.lopez@aso.co.cr', '555-5678', '2025-01-30 05:16:11','2025-01-30 05:16:11'),
( 'Pedro Quintero Artavia', '117390526', 'pedro.quintero@aso.co.cr', '83035390', '2025-02-01 03:05:24','2025-01-30 05:16:11'),
( 'GONZALEZ QUIROS PAOLA DANIELA', '111111222', 'paola.gonzalez@aso.co.cr', '8888-88-199', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'GRANADOS CORDERO MARIA JOSE', '111111223', 'maria.granados@aso.co.cr', '8888-88-200', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'HERNANDEZ RODRIGUEZ DAVID JAVIER', '111111224', 'david.hernandez@aso.co.cr', '8888-88-201', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'HERRERA OVIEDO FEDERICO', '111111225', 'federico.herrera@aso.co.cr', '8888-88-202', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'HERRERA QUIROS JOSE MIGUEL', '111111226', 'jose.herrera@aso.co.cr', '8888-88-203', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'HIDALGO CALDERON IGNACIO', '111111227', 'ignacio.hidalgo@aso.co.cr', '8888-88-204', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'JARA CARBALLO GRACIELA', '111111228', 'graciela.jara@aso.co.cr', '8888-88-205', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'JIMENEZ VILLEGAS ALVARO', '111111229', 'alvaro.jimenez@aso.co.cr', '8888-88-206', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'JOHNSON MATA ANGIE JACKELINE', '111111230', 'angie.johnson@aso.co.cr', '8888-88-207', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'LAITANO RODRIGUEZ MARIO', '111111231', 'mario.laitano@aso.co.cr', '8888-88-208', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'LEIVA OROZCO CINDY PATRICIA', '111111232', 'cindy.leiva@aso.co.cr', '8888-88-209', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MARIN ARRIETA JUAN CARLOS', '111111233', 'juan.marin@aso.co.cr', '8888-88-210', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MEZA LEANDRO HENRY', '111111234', 'henry.meza@aso.co.cr', '8888-88-211', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MONDRAGON ROJAS JUAN PABLO', '111111235', 'juan.mondragon@aso.co.cr', '8888-88-212', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MONGE AGUILAR NIDYA ISABEL', '111111236', 'nidya.monge@aso.co.cr', '8888-88-213', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MONGE GARRO RODOLFO ALEXANDER', '111111237', 'rodolfo.monge@aso.co.cr', '8888-88-214', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MONGE MARIN MONICA', '111111238', 'monica.monge@aso.co.cr', '8888-88-215', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MORA MIRANDA RAUL', '111111239', 'raul.mora@aso.co.cr', '8888-88-216', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MUNOZ LEIVA MICHAEL', '111111240', 'michael.munoz@aso.co.cr', '8888-88-217', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'MURILLO LORIA JACQUELINE', '111111241', 'jacqueline.murillo@aso.co.cr', '8888-88-218', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'NAVARRO OLIVER GERMAN', '111111242', 'german.navarro@aso.co.cr', '8888-88-219', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'NAVARRO RODRIGUEZ CHRISTOPHER', '111111243', 'christopher.navarro@aso.co.cr', '8888-88-220', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'ORTEGA VILLALOBOS ISABEL', '111111244', 'isabel.ortega@aso.co.cr', '8888-88-221', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'OVARES CORDOBA ADRIAN', '111111245', 'adrian.ovares@aso.co.cr', '8888-88-222', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'OVARES VILLAR JOHANNA', '111111246', 'johanna.ovares@aso.co.cr', '8888-88-223', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'PICADO REYES ABY', '111111247', 'aby.picado@aso.co.cr', '8888-88-224', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'QUESADA MOYA OMAR EMILIO', '111111248', 'omar.quesada@aso.co.cr', '8888-88-225', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'RAMOS NAVARRO CHRISTIAN', '111111249', 'christian.ramos@aso.co.cr', '8888-88-226', '2025-02-01 04:33:24','2025-01-30 05:16:11'),
( 'RETANA BONILLA ALFREDO', '111111250', 'alfredo.retana@aso.co.cr', '8888-88-227', '2025-02-01 04:33:24','2025-01-30 05:16:11');



INSERT INTO Events (EventName, EventDate, Description, Location, Capacity, IsActive)
VALUES
('Conferencia: El Arte de Ser Mangoneado', '2025-04-15 10:00:00', 'Un espacio para compartir experiencias sobre cómo manejar las dinámicas del hogar bajo la guía experta de un mangoneador.', 'Centro de Convenciones Mangoneados', 100, 1),
('Taller: Cómo Decir "Sí Querida"', '2025-04-20 14:00:00', 'Un taller intensivo para aprender a ser un excelente seguidor de las órdenes de la jefa del hogar.', 'Auditorio Asociación Hombre Mangoneados', 50, 1),
('Feria: Tecnología y Mangoneo', '2025-05-05 09:00:00', 'Explora las herramientas tecnológicas que ayudan a los mangoneados a cumplir tareas con eficiencia.', 'Plaza Central de Mangoneados', 150, 1),
('Competencia: El Mangoneado del Año', '2025-06-10 17:00:00', 'Evento de premiación para el hombre que mejor cumple su papel en casa.', 'Estadio Mangoneado 2025', 300, 1),
('Charla: Cómo Sobrevivir al Mandato', '2025-06-25 15:00:00', 'Un orador experto compartirá técnicas avanzadas de adaptación y supervivencia bajo el mandato.', 'Centro Cultural Mangoneado', 200, 1),
('Encuentro: Hermanos Mangoneados Unidos', '2025-07-10 10:00:00', 'Reunión de hombres que buscan apoyo mutuo y comparten sus historias de éxito en la mangoneada.', 'Salón Mangoneados Unidos', 80, 1),
('Taller Avanzado: Cómo Ser el Mejor Mangoneado', '2025-08-01 09:00:00', 'Un curso avanzado para perfeccionar tus habilidades y ser el orgullo del hogar.', 'Centro de Innovación Mangoneados', 60, 1);




