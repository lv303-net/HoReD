create database HORED;
use HORED;

CREATE TABLE ROLES(IDRoles INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ROLENAME NVARCHAR(15));

CREATE TABLE USERS (IDUsers INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	FIRSTNAME NVARCHAR(30) NOT NULL, 
	LASTNAME NVARCHAR(30) NOT NULL,
	IDROLE INT FOREIGN KEY REFERENCES ROLES(IDRoles),
	--ROLE NVARCHAR(15) NOT NULL, -- OR ROLE INT 1 - ADMIN, 2 - DOCTOR, 3 - PATIENT
	LOGIN NVARCHAR(15) NOT NULL,
	PASSWORD NVARCHAR(30) NOT NULL,
	EMAIL NVARCHAR(40) NOT NULL);

CREATE TABLE PROFESSIONS(IDProfessins INT PRIMARY KEY NOT NULL IDENTITY(1,1), 
	PROFESSINNAME NVARCHAR(30) UNIQUE,
	ISSTATIC BIT);

CREATE TABLE DOCTORS (IDDoctors INT PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES USERS(IDUsers),
	IDPROFESSION INT FOREIGN KEY REFERENCES PROFESSIONS(IDProfessins),
	HOURSTART TIME(0),
	HOURFINISH TIME(0),
	DATEOFEMPLOYING DATE,
	IMAGEDOC NVARCHAR(100)); --??????
				
				--INSERT INTO ROLES
INSERT INTO ROLES VALUES ('admin');
INSERT INTO ROLES VALUES ('doctor');
INSERT INTO ROLES VALUES ('patient');

SELECT * FROM ROLES;
				--INSER INTO USERS
INSERT INTO USERS VALUES ('Petrov', 'Ivan', 2, 'ipetrovdoc', 'w2f30n7f?', 'petrovivan1245@gmail.com');
INSERT INTO USERS VALUES ('Tuz', 'Oleh', 2, 'otuzdoc', 'ja4>f[hs5bG', 'tuztuzzz@gmail.com');
INSERT INTO USERS VALUES ('Buga', 'Mykola', 2, 'mbugadoc', 'gR6d5[(jNl', 'nicolasbbb@ukr.net');
INSERT INTO USERS VALUES ('Popova', 'Natalia', 2, 'npopovadoc', 'bu75KJ[*fr5df', 'popovanatusia@gmail.com');
INSERT INTO USERS VALUES ('Veres', 'Myroslav', 2, 'mveresdoc', 'vtJ76(ih', 'doctorveres@gmail.com');
INSERT INTO USERS VALUES ('Bebeshko', 'Olena', 2, 'obebeshkodoc', 'v5HG6*N8kh', 'younggirl@ukr.net');
INSERT INTO USERS VALUES ('Zinchuk', 'Ihor', 2, 'izinchukdoc', 'vftR%4Hfn0(k)', 'zzinchukihor@gmail.com');
INSERT INTO USERS VALUES ('Zhydchuk', 'Ivan', 2, 'izhydchukdoc', 'hgKJ7&hjv*', 'zhydchuk.work@gmail.com');
INSERT INTO USERS VALUES ('Bobalo', 'Inokentii', 2, 'ibobalodoc', 'v%jd$h23GF', 'superdoctor007@ukr.net');
INSERT INTO USERS VALUES ('Burova', 'Iryna', 2, 'iburovadoc', 'hgtK87M^9fcv]', 'burova.policlinica@gmail.com');
INSERT INTO USERS VALUES ('Petrov', 'Taras', 2, 'tpetrovdoc', 'hf*5g$bFD02H', 'pppetrov@gmail.com');
INSERT INTO USERS VALUES ('Pack', 'Myron', 2, 'mpackdoc', 'bf25*$hf#4fGt', 'ukrainian.ilonmask@gmail.com');
INSERT INTO USERS VALUES ('Shondir', 'Iryna', 2, 'ishpondirdoc', 'bfj54$fG6S4[SD?', 'ishpondir.lviv@gmail.com');
INSERT INTO USERS VALUES ('Nytrebych', 'Yason', 2, 'ynytrebychdoc', 'gf(uD4V}gfE?', 'yason57@gmail.com');
INSERT INTO USERS VALUES ( 'Stolyar', 'Maria', 2, 'mstolyardoc', 'gtd5(y5H&5', 'm.stolyar@gmail.com');

SELECT * FROM USERS;

--INSERT INTO PROFESSIONS
INSERT INTO PROFESSIONS VALUES('therapist', 1);
INSERT INTO PROFESSIONS VALUES('ophthalmologist', 1);
INSERT INTO PROFESSIONS VALUES('obstetrician-gynecologistt', 1);
INSERT INTO PROFESSIONS VALUES('surgeon', 0);
INSERT INTO PROFESSIONS VALUES('cardiologist', 0);
INSERT INTO PROFESSIONS VALUES('dermatologist', 0);
INSERT INTO PROFESSIONS VALUES('gastroenterologist', 0);
INSERT INTO PROFESSIONS VALUES('momologist', 0);
INSERT INTO PROFESSIONS VALUES('neurologist', 0);
INSERT INTO PROFESSIONS VALUES('oncologist', 0);
INSERT INTO PROFESSIONS VALUES('otorhinolaryngologist', 1); --?????
INSERT INTO PROFESSIONS VALUES('orthodontist', 0);
INSERT INTO PROFESSIONS VALUES('pediatrician', 0);
INSERT INTO PROFESSIONS VALUES('proctologist', 0);
INSERT INTO PROFESSIONS VALUES('pulmonologist', 0);
INSERT INTO PROFESSIONS VALUES('dentist', 1);
INSERT INTO PROFESSIONS VALUES('traumatologist', 0);
INSERT INTO PROFESSIONS VALUES('urologist', 0);
INSERT INTO PROFESSIONS VALUES('hematologist', 0);

SELECT * FROM PROFESSIONS;

			--INSER INTO DOCTORS
INSERT INTO DOCTORS VALUES (8, 1, '10:00:00', '16:00:00', '1998-10-14', 'D:\Photo\photo1.jpg');
INSERT INTO DOCTORS VALUES (10, 1, '9:00:00', '17:00:00', '2010-08-10', 'D:\Photo\photo2.jpg');
INSERT INTO DOCTORS VALUES (2, 3, '10:30:00', '17:00:00', '2004-09-10', 'D:\Photo\photo3.jpg');
INSERT INTO DOCTORS VALUES (15, 5, '12:00:00', '18:00:00', '2012-08-17', 'D:\Photo\photo4.jpg');
INSERT INTO DOCTORS VALUES (6, 19, '10:00:00', '18:00:00', '2006-11-12', 'D:\Photo\photo5.jpg');
INSERT INTO DOCTORS VALUES (13, 10, '11:00:00', '17:30:00', '2008-02-02', 'D:\Photo\photo6.jpg');
INSERT INTO DOCTORS VALUES (3, 8, '10:00:00', '15:45:00', '1985-01-22', 'D:\Photo\photo7.jpg');
INSERT INTO DOCTORS VALUES (1, 4, '11:00:00', '18:00:00', '2007-01-22', 'D:\Photo\photo8.jpg');
INSERT INTO DOCTORS VALUES (4, 7, '10:00:00', '16:30:00', '2000-11-12', 'D:\Photo\photo9.jpg');
INSERT INTO DOCTORS VALUES (11, 17, '8:00:00', '16:00:00', '2009-12-10', 'D:\Photo\photo10.jpg');
INSERT INTO DOCTORS VALUES (5, 6, '9:00:00', '17:00:00', '1995-11-12', 'D:\Photo\photo11.jpg');
INSERT INTO DOCTORS VALUES (7, 1, '9:00:00', '16:00:00', '2015-9-14', 'D:\Photo\photo12.jpg');
INSERT INTO DOCTORS VALUES (14, 15, '11:00:00', '18:00:00', '2013-11-25', 'D:\Photo\photo13.jpg');
INSERT INTO DOCTORS VALUES (9, 16, '10:00:00', '17:00:00', '2006-11-12', 'D:\Photo\photo14.jpg');
SELECT * FROM DOCTORS;

/*
CREATE TABLE CARDS (ID INT PRIMARY KEY NOT NULL,
			IDUSER int FOREIGN KEY REFERENCES USERS(ID), 
		DATEOFBIRTHDAY DATE,
			HEIGHT INT,
			WEIGHT INT,
			SEX BIT, --1 - MAN, 0 - WOMAN
			TYPEBLOOD INT, -- ?????
			REACTFACTOR BIT,); --?????*/
		
