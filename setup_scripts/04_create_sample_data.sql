CREATE TABLE patientdata (
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    date_of_birth DATE,
    social_security_number CHAR(11),
    createdDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO patientdata (first_name, last_name, date_of_birth, social_security_number) VALUES
('John', 'Doe', '1985-05-15', '123-45-6789'),
('Jane', 'Smith', '1990-07-22', '987-65-4321'),
('Alice', 'Johnson', '1978-03-10', '111-22-3333'),
('Bob', 'Brown', '1982-11-30', '444-55-6666'),
('Charlie', 'Davis', '1995-01-25', '777-88-9999'),
('Diana', 'Miller', '1988-09-14', '222-33-4444'),
('Eve', 'Wilson', '1992-06-18', '555-66-7777'),
('Frank', 'Moore', '1980-12-05', '888-99-0000'),
('Grace', 'Taylor', '1983-04-27', '333-44-5555'),
('Hank', 'Anderson', '1975-08-19', '666-77-8888');

