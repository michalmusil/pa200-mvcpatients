CREATE DATABASE patientsdb;

CREATE USER patientuser WITH PASSWORD 'SuperSecretPassword1234';

GRANT ALL PRIVILEGES ON DATABASE patientsdb TO patientuser;

