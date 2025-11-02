-- StudentDB_CreateAndSPs.sql
CREATE DATABASE  StudentCourseDB;
GO
USE  StudentCourseDB;
GO
 
IF OBJECT_ID('Students') IS NOT NULL DROP TABLE Students;
IF OBJECT_ID('Courses') IS NOT NULL DROP TABLE Courses;
GO

CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Age INT CHECK (Age >= 1 AND Age <= 100),
    Grade NVARCHAR(5),
    CourseId INT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO

INSERT INTO Courses (CourseName) VALUES 
('C# Fundamentals'), ('ASP.NET Core Development'),
('SQL & Database Management'), ('ReactJS Frontend Development');

INSERT INTO Students (Name, Age, Grade, CourseId) VALUES
('Udaya Kumar Shetty', 22, 'A', 1),
('Prajwal M', 23, 'B', 2),
('Sneha R', 21, 'A', 3);
GO

-- Stored Procedures --------------------------------------------------

IF OBJECT_ID('sp_GetStudents') IS NOT NULL DROP PROCEDURE sp_GetStudents;
GO
CREATE PROCEDURE sp_GetStudents
AS
BEGIN
    SELECT s.Id, s.Name, s.Age, s.Grade, s.CourseId, c.CourseName
    FROM Students s
    LEFT JOIN Courses c ON s.CourseId = c.CourseId;
END;
GO

IF OBJECT_ID('sp_GetStudentById') IS NOT NULL DROP PROCEDURE sp_GetStudentById;
GO
CREATE PROCEDURE sp_GetStudentById @Id INT
AS
BEGIN
    SELECT s.Id, s.Name, s.Age, s.Grade, s.CourseId, c.CourseName
    FROM Students s
    LEFT JOIN Courses c ON s.CourseId = c.CourseId
    WHERE s.Id = @Id;
END;
GO

IF OBJECT_ID('sp_AddStudent') IS NOT NULL DROP PROCEDURE sp_AddStudent;
GO
CREATE PROCEDURE sp_AddStudent
    @Name NVARCHAR(100),
    @Age INT,
    @Grade NVARCHAR(5),
    @CourseId INT
AS
BEGIN
    INSERT INTO Students (Name, Age, Grade, CourseId)
    VALUES (@Name, @Age, @Grade, @CourseId);
END;
GO

IF OBJECT_ID('sp_UpdateStudent') IS NOT NULL DROP PROCEDURE sp_UpdateStudent;
GO
CREATE PROCEDURE sp_UpdateStudent
    @Id INT,
    @Name NVARCHAR(100),
    @Age INT,
    @Grade NVARCHAR(5),
    @CourseId INT
AS
BEGIN
    UPDATE Students
    SET Name = @Name, Age = @Age, Grade = @Grade, CourseId = @CourseId
    WHERE Id = @Id;
END;
GO

IF OBJECT_ID('sp_DeleteStudent') IS NOT NULL DROP PROCEDURE sp_DeleteStudent;
GO
CREATE PROCEDURE sp_DeleteStudent
    @Id INT
AS
BEGIN
    DELETE FROM Students WHERE Id = @Id;
END;
GO

SELECT * FROM Students