CREATE DATABASE FinetDB;

USE FinetDB;

CREATE TABLE MsUser(
	[UserID] UNIQUEIDENTIFIER PRIMARY KEY,
	[Username] VARCHAR(255) UNIQUE,
	[Email] VARCHAR(255) UNIQUE,
	[Password] VARCHAR(255)
);

SELECT *FROM MsUser;

DROP TABLE MsUser;