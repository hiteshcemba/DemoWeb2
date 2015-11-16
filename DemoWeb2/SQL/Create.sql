CREATE TABLE Employee
(
EmpId int IDENTITY(1,1) PRIMARY KEY,
F_Name varchar(50) NOT NULL,
L_Name varchar(50) NOT NULL,
City varchar(50),
EmailId varchar(50),
EmpJoining date
)