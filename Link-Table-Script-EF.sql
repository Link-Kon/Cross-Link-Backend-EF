DROP TABLE users_data

CREATE TABLE devices(
    id int IDENTITY, 
    nickname varchar(40) NULL,
    mac_address varchar(20),
    model varchar(40) NULL,
    version decimal(5,2) NULL,
    creation_date datetime,
    last_update_date datetime NULL,
    PRIMARY KEY (id)
);
	

CREATE TABLE illnesses(
	id int IDENTITY, 
	name varchar(40) NOT NULL,
	description varchar(40) NULL,
	creator_id int NULL,
	creation_date datetime,
	last_update_date datetime NULL,
	PRIMARY KEY (id)
);

CREATE TABLE users (
	id int IDENTITY,
	code varchar(40) NOT NULL,
	username nvarchar(40),
	token nvarchar(max),
	device_token nvarchar(40) NULL,
	attempt int,
	creation_date datetime,
	last_update_date datetime NULL,
	PRIMARY KEY (id),
	UNIQUE (code)
);

CREATE TABLE users_data (
	id int IDENTITY,
	state bit NOT NULL,
	email varchar(80) NOT NULL,
	name varchar(80) NOT NULL,
	lastname varchar(80) NOT NULL,
	user_photo varchar(max) NULL,
	creation_date datetime,
	last_update_date datetime NULL,
	user_id int NOT NULL,
	user_code varchar(40) NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (user_id) REFERENCES users (id),
	FOREIGN KEY (user_code) REFERENCES users (code)
);	


CREATE TABLE friendship (
    shared_id int IDENTITY NOT NULL,
    user1_code varchar(40) NOT NULL,
    user2_code varchar(40) NOT NULL,
    state bit NOT NULL,
    creation_date datetime NOT NULL,
    last_update_date datetime NULL,
    PRIMARY KEY (shared_id),
    CONSTRAINT FK_user_code_1 FOREIGN KEY (user1_code) REFERENCES users (code),
    CONSTRAINT FK_user_2_code FOREIGN KEY (user2_code) REFERENCES users (code),
    CHECK (user1_code <> user2_code)
);


CREATE TABLE users_devices(
    id int IDENTITY,
    user_data_id int NOT NULL,
    device_id int NOT NULL,
    state bit NOT NULL,
    creation_date datetime,
    last_update_date datetime NULL,
    PRIMARY KEY (id),
    CONSTRAINT FK_user_data_id FOREIGN KEY (user_data_id) REFERENCES users_data(id),
    CONSTRAINT FK_device_id FOREIGN KEY (device_id) REFERENCES devices(id)
);

CREATE TABLE illnesses_list
(
	id int IDENTITY,
	user_data_id		int NOT NULL,
	illness_id			int NOT NULL,
	state bit NOT NULL,
	creation_date datetime,
	last_update_date datetime,
	PRIMARY KEY (id),
    CONSTRAINT FK_Usuario_Datos_Id_List FOREIGN KEY (user_data_id)
    REFERENCES users_data(id),
	CONSTRAINT FK_Enfermedad_Id FOREIGN KEY (illness_id)
    REFERENCES illnesses(id)
) 

CREATE TABLE patients
(
	id					int IDENTITY,
	state				bit NOT NULL,
	weight				decimal(5,2) NULL,
	height				decimal(5,2) NULL,
	country				varchar(56) NULL,
	user_data_id		int NOT NULL,
	creation_date datetime,
	last_update_date datetime,
	PRIMARY KEY (id),
    CONSTRAINT FK_user_data_id_2 FOREIGN KEY (user_data_id)
    REFERENCES users_data(id)
) 

CREATE TABLE heart_rhythm_records
(
	id					int IDENTITY,
	lecture_date			datetime NOT NULL,
	bpm					int NOT	NULL,
	patient_id			int NOT NULL,
	creation_date datetime,
	last_update_date datetime,
	PRIMARY KEY (id),
    CONSTRAINT FK_patient_user_1 FOREIGN KEY (patient_id)
    REFERENCES patients(id)
)

CREATE TABLE heart_issue_records
(
	id					int IDENTITY,
	lecture_date		datetime NOT NULL,
	severity			varchar(20) NOT	NULL,
	patient_id		int NOT NULL,
	creation_date datetime,
	last_update_date datetime,
	PRIMARY KEY (id),
    CONSTRAINT FK_patient_user_2 FOREIGN KEY (patient_id)
    REFERENCES patients(id)
) 

CREATE TABLE fall_records
(
	id				int IDENTITY,
	lecture_date		datetime NOT NULL,
	severity		varchar(20) NOT	NULL,
	patient_id	int NOT NULL,
	creation_date datetime,
	last_update_date datetime,
	PRIMARY KEY (id),
    CONSTRAINT FK_patient_user_3 FOREIGN KEY (patient_id)
    REFERENCES patients(id)
)

