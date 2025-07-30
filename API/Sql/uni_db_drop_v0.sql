ALTER TABLE AcademicSemester DROP CONSTRAINT AcademicSemester_AcademicYear;

ALTER TABLE Address DROP CONSTRAINT Address_Country;

ALTER TABLE Class DROP CONSTRAINT Class_Course;
ALTER TABLE Class DROP CONSTRAINT Class_Group;
ALTER TABLE Class DROP CONSTRAINT Class_Lecturer;
ALTER TABLE Class DROP CONSTRAINT Class_Room;

ALTER TABLE Clerk DROP CONSTRAINT Clerk_Person;

ALTER TABLE Course DROP CONSTRAINT Course_Lecturer;
ALTER TABLE Course DROP CONSTRAINT Course_Subject;

ALTER TABLE FinalGrade DROP CONSTRAINT FinalGrade_Course;
ALTER TABLE FinalGrade DROP CONSTRAINT FinalGrade_Student;

ALTER TABLE GradeComponent DROP CONSTRAINT GradeComponent_FinalGrade;
ALTER TABLE GradeComponent DROP CONSTRAINT GradeComponent_GradeType;

ALTER TABLE "Group" DROP CONSTRAINT Group_AcademicSemester;
ALTER TABLE "Group" DROP CONSTRAINT Group_GroupType;

ALTER TABLE Lecturer DROP CONSTRAINT Lecturer_Degree;
ALTER TABLE Lecturer DROP CONSTRAINT Lecturer_Faculty;

ALTER TABLE Person DROP CONSTRAINT Person_CorrespondenceAddress;
ALTER TABLE Person DROP CONSTRAINT Person_PermanentAddress;
ALTER TABLE Person DROP CONSTRAINT Person_User;

ALTER TABLE PetitionStatus DROP CONSTRAINT PetitionStatus_Petition;
ALTER TABLE PetitionStatus DROP CONSTRAINT PetitionStatus_Status;

ALTER TABLE Petition DROP CONSTRAINT Petition_Clerk;
ALTER TABLE Petition DROP CONSTRAINT Petition_Student;

ALTER TABLE StudentGroup DROP CONSTRAINT StudentGroup_Group;
ALTER TABLE StudentGroup DROP CONSTRAINT StudentGroup_Student;

ALTER TABLE Subject DROP CONSTRAINT Subject_Faculty;

ALTER TABLE UserRole DROP CONSTRAINT Table_33_Role;
ALTER TABLE UserRole DROP CONSTRAINT Table_33_User;

ALTER TABLE Lecturer DROP CONSTRAINT lecturer_person;

ALTER TABLE Person DROP CONSTRAINT person_country;

ALTER TABLE Student DROP CONSTRAINT student_person;

IF OBJECT_ID('dbo.AcademicSemester', 'U') IS NOT NULL DROP TABLE dbo.AcademicSemester;
IF OBJECT_ID('dbo.AcademicYear', 'U') IS NOT NULL DROP TABLE dbo.AcademicYear;
IF OBJECT_ID('dbo.Address', 'U') IS NOT NULL DROP TABLE dbo.Address;
IF OBJECT_ID('dbo.Class', 'U') IS NOT NULL DROP TABLE dbo.Class;
IF OBJECT_ID('dbo.Clerk', 'U') IS NOT NULL DROP TABLE dbo.Clerk;
IF OBJECT_ID('dbo.Country', 'U') IS NOT NULL DROP TABLE dbo.Country;
IF OBJECT_ID('dbo.Course', 'U') IS NOT NULL DROP TABLE dbo.Course;
IF OBJECT_ID('dbo.Degree', 'U') IS NOT NULL DROP TABLE dbo.Degree;
IF OBJECT_ID('dbo.Faculty', 'U') IS NOT NULL DROP TABLE dbo.Faculty;
IF OBJECT_ID('dbo.FinalGrade', 'U') IS NOT NULL DROP TABLE dbo.FinalGrade;
IF OBJECT_ID('dbo.GradeComponent', 'U') IS NOT NULL DROP TABLE dbo.GradeComponent;
IF OBJECT_ID('dbo.GradeType', 'U') IS NOT NULL DROP TABLE dbo.GradeType;
IF OBJECT_ID('dbo.[Group]', 'U') IS NOT NULL DROP TABLE dbo.[Group];
IF OBJECT_ID('dbo.GroupType', 'U') IS NOT NULL DROP TABLE dbo.GroupType;
IF OBJECT_ID('dbo.Lecturer', 'U') IS NOT NULL DROP TABLE dbo.Lecturer;
IF OBJECT_ID('dbo.Person', 'U') IS NOT NULL DROP TABLE dbo.Person;
IF OBJECT_ID('dbo.Petition', 'U') IS NOT NULL DROP TABLE dbo.Petition;
IF OBJECT_ID('dbo.PetitionStatus', 'U') IS NOT NULL DROP TABLE dbo.PetitionStatus;
IF OBJECT_ID('dbo.[Role]', 'U') IS NOT NULL DROP TABLE dbo.[Role];
IF OBJECT_ID('dbo.Room', 'U') IS NOT NULL DROP TABLE dbo.Room;
IF OBJECT_ID('dbo.[Status]', 'U') IS NOT NULL DROP TABLE dbo.[Status];
IF OBJECT_ID('dbo.Student', 'U') IS NOT NULL DROP TABLE dbo.Student;
IF OBJECT_ID('dbo.StudentGroup', 'U') IS NOT NULL DROP TABLE dbo.StudentGroup;
IF OBJECT_ID('dbo.Subject', 'U') IS NOT NULL DROP TABLE dbo.Subject;
IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL DROP TABLE dbo.[User];
IF OBJECT_ID('dbo.UserRole', 'U') IS NOT NULL DROP TABLE dbo.UserRole;