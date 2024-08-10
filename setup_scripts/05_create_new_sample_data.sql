
CREATE TABLE Patient (
    Id SERIAL PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    SocialSecurityNumber CHAR(11),
    CreatedDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Patient (FirstName, LastName, DateOfBirth, SocialSecurityNumber) VALUES
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

