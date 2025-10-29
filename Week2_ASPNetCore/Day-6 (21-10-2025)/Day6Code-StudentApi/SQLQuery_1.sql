CREATE DATABASE StudentCourseDB;
GO

USE StudentCourseDB;
GO

-- Drop existing tables if re-running
IF OBJECT_ID('Students') IS NOT NULL DROP TABLE Students;
IF OBJECT_ID('Courses') IS NOT NULL DROP TABLE Courses;
GO

-- Create Courses Table
CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL
);
GO

-- Create Students Table
CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Age INT CHECK (Age >= 1 AND Age <= 100),
    Grade NVARCHAR(5),
    CourseId INT,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);
GO

SELECT * FROM Students;
GO

SELECT * FROM Courses;
GO

-- Insert Sample Data
INSERT INTO Courses (CourseName) VALUES 
('C# Fundamentals'), ('ASP.NET Core Development'),
('SQL & Database Management'), ('ReactJS Frontend Development');

INSERT INTO Students (Name, Age, Grade, CourseId) VALUES
('Udaya Kumar Shetty', 22, 'A', 1),
('Prajwal M', 23, 'B', 2),
('Sneha R', 21, 'A', 3),
('Nikhil Rao', 22, 'B', 2),
('Lavanya K', 21, 'A', 4);
GO

-- STORED PROCEDURES
USE StudentCourseDB;
GO

-- Drop old version if exists
IF OBJECT_ID('GetAllStudents') IS NOT NULL 
    DROP PROCEDURE GetAllStudents;
GO

-- Correct version
CREATE PROCEDURE GetAllStudents
AS
BEGIN
    SELECT 
        s.Id, 
        s.Name, 
        s.Age, 
        s.Grade, 
        s.CourseId,     -- include CourseId column explicitly
        c.CourseName    -- join to get CourseName
    FROM Students s
    INNER JOIN Courses c ON s.CourseId = c.CourseId;
END;
GO

EXEC GetAllStudents;


CREATE PROCEDURE sp_GetStudentById @Id INT
AS
BEGIN
    SELECT s.Id, s.Name, s.Age, s.Grade, c.CourseName
    FROM Students s
    JOIN Courses c ON s.CourseId = c.CourseId
    WHERE s.Id = @Id;
END;
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

CREATE PROCEDURE sp_DeleteStudent
    @Id INT
AS
BEGIN
    DELETE FROM Students WHERE Id = @Id;
END;
GO

