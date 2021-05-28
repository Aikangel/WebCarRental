CREATE TABLE Car_brands
(
  Brand_code INT NOT NULL,
  Description VARCHAR(150) NOT NULL,
  Technical_specifications VARCHAR(100) NOT NULL,
  Name VARCHAR(50) NOT NULL,
  PRIMARY KEY (Brand_code)
);

CREATE TABLE Positions
(
  Requirements VARCHAR(100) NOT NULL,
  Responsibilities VARCHAR(100) NOT NULL,
  Salary INT NOT NULL,
  Name_of_the_position VARCHAR(50) NOT NULL,
  Position_code INT NOT NULL,
  PRIMARY KEY (Position_code)
);

CREATE TABLE Customers
(
  Client_Code INT NOT NULL,
  Full_name VARCHAR(50) NOT NULL,
  Paul VARCHAR(10) NOT NULL,
  Date_of_birth INT NOT NULL,
  Address VARCHAR NOT NULL,
  Phone INT NOT NULL,
  Passport_details INT NOT NULL,
  PRIMARY KEY (Client_Code)
);

CREATE TABLE Additional_services
(
  Service_code INT NOT NULL,
  Price INT NOT NULL,
  Description VARCHAR NOT NULL,
  Title INT NOT NULL,
  PRIMARY KEY (Service_code)
);

CREATE TABLE Staff
(
  Phone INT NOT NULL,
  Passport_details INT NOT NULL,
  Address VARCHAR NOT NULL,
  Paul VARCHAR(10) NOT NULL,
  Age INT NOT NULL,
  Full_name VARCHAR(50) NOT NULL,
  Employee_Code INT NOT NULL,
  Position_code INT NOT NULL,
  PRIMARY KEY (Employee_Code),
  FOREIGN KEY (Position_code) REFERENCES Positions(Position_code)
);

CREATE TABLE Cars
(
  Vehicle_code INT NOT NULL,
  Date_of_last_maintenance DATE NOT NULL,
  Return_mark INT NOT NULL,
  Registration_number INT NOT NULL,
  Special_marks VARCHAR(50) NOT NULL,
  Rental_day_price INT NOT NULL,
  Car_price INT NOT NULL,
  Mileage INT NOT NULL,
  Body_number INT NOT NULL,
  Engine_number VARCHAR(50) NOT NULL,
  Year_of_release INT NOT NULL,
  Brand_code INT NOT NULL,
  Employee_Code INT NOT NULL,
  PRIMARY KEY (Vehicle_code),
  FOREIGN KEY (Brand_code) REFERENCES Car_brands(Brand_code),
  FOREIGN KEY (Employee_Code) REFERENCES Staff(Employee_Code)
);

CREATE TABLE Rental_services
(
  Date_of_issue INT NOT NULL,
  Rental_period VARCHAR(50) NOT NULL,
  Payment_mark VARCHAR(50) NOT NULL,
  Rental_price INT NOT NULL,
  Return_Date DATE NOT NULL,
  Vehicle_code INT NOT NULL,
  Client_Code INT NOT NULL,
  Service_code_1 INT NOT NULL,
  Service_code_2 INT NOT NULL,
  Service_code_3 INT NOT NULL,
  FOREIGN KEY (Vehicle_code) REFERENCES Cars(Vehicle_code),
  FOREIGN KEY (Client_Code) REFERENCES Customers(Client_Code),
  FOREIGN KEY (Service_code_1) REFERENCES Additional_services(Service_code),
  FOREIGN KEY (Service_code_2) REFERENCES Additional_services(Service_code),
  FOREIGN KEY (Service_code_3) REFERENCES Additional_services(Service_code)
);
