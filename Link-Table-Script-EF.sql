CREATE DATABASE db_link_ef

CREATE TABLE illnesses(
   id int IDENTITY, 
   name varchar(40) NOT NULL,
   description varchar(40) NULL,
   creator_id int NULL
   PRIMARY KEY (id),
);

DROP TABLE illnesses

CREATE TABLE users(
	id int IDENTITY,
	code nvarchar(8) UNIQUE NOT NULL,
	username nvarchar(40),
	password nvarchar(max)
	PRIMARY KEY (id)
)

ALTER TABLE users
ALTER COLUMN code nvarchar(40) PERSISTED PRIMARY KEY;

CREATE TABLE users_data
(
	id				int IDENTITY,
	activo			bit NOT NULL,
	email			varchar(80) NOT NULL,
	name			varchar(80) NOT NULL,
	lastname		varchar(80) NOT NULL,
	user_photo		varchar(max) NULL, 
	user_id			int NOT NULL,
	PRIMARY KEY (id),
    CONSTRAINT FK_user_id FOREIGN KEY (user_id)
    REFERENCES users(id)
)

CREATE TABLE patients
(
	id					int IDENTITY,
	active				varchar(80) NOT NULL,
	weight				decimal(5,2) NULL,
	height				decimal(5,2) NULL,
	country				varchar(56) NULL,
	user_data_id		int NOT NULL,
	PRIMARY KEY (id),
    CONSTRAINT FK_user_data_id FOREIGN KEY (user_data_id)
    REFERENCES users_data(id)
) 

CREATE TABLE heart_rhythm_records
(
	id					int IDENTITY,
	lectureDate			datetime NOT NULL,
	bpm					int NOT	NULL,
	user_data_id		int NOT NULL,
	PRIMARY KEY (id),
    CONSTRAINT FK_user_data_id_1 FOREIGN KEY (user_data_id)
    REFERENCES users_data(id)
)

CREATE TABLE heart_issue_records
(
	id					int IDENTITY,
	fecha_lectura		datetime NOT NULL,
	severity			varchar(20) NOT	NULL,
	user_data_id		int NOT NULL,
	PRIMARY KEY (id),
    CONSTRAINT FK_user_data_id_2 FOREIGN KEY (user_data_id)
    REFERENCES users_data(id)
) 

CREATE TABLE fall_records
(
	id				int IDENTITY,
	lectureDate		datetime NOT NULL,
	severity		varchar(20) NOT	NULL,
	user_data_id	int NOT NULL,
	PRIMARY KEY (id),
    CONSTRAINT FK_user_data_id_3 FOREIGN KEY (user_data_id)
    REFERENCES users_data(id)
) 

CREATE TABLE illnesses_list
(
	user_data_id		int NOT NULL,
	illness_id			int NOT NULL,
	PRIMARY KEY (user_data_id, illness_id),
    CONSTRAINT FK_Usuario_Datos_Id_List FOREIGN KEY (user_data_id)
    REFERENCES users_data(id),
	CONSTRAINT FK_Enfermedad_Id FOREIGN KEY (illness_id)
    REFERENCES illnesses(id)
) 

DROP TABLE userms

CREATE TABLE userms(
	id int IDENTITY,
	code		varchar(50) UNIQUE  NOT	NULL,
	username	nvarchar(50),
	password	nvarchar(max)
	PRIMARY KEY (id)
)


DROP TABLE friendship
CREATE TABLE friendship
(
	user1_code				varchar(8) UNIQUE NOT	NULL,
	user2_code				varchar(8) UNIQUE NOT NULL,
	active					bit NOT NULL,
	PRIMARY KEY (user1_code,user2_code),
	CONSTRAINT FK_user_code_1 FOREIGN KEY (user1_code)
    REFERENCES users(code),
	CONSTRAINT FK_user_2_code FOREIGN KEY (user2_code)
    REFERENCES users(code),
	CONSTRAINT FriendsAreDistinct_CK    CHECK  (user1_code <> user2_code)
) 