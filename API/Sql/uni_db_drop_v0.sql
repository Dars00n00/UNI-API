ALTER TABLE AcademicSemester DROP CONSTRAINT AcademicSemester_AcademicYear;

ALTER TABLE Address DROP CONSTRAINT Address_Country;

ALTER TABLE Class DROP CONSTRAINT Class_Course;
ALTER TABLE Class DROP CONSTRAINT Class_Group;
ALTER TABLE Class DROP CONSTRAINT Class_Lecturer;
ALTER TABLE Class DROP CONSTRAINT Class_Room;

ALTER TABLE ClerkAdministrativeRole DROP CONSTRAINT ClerkAdministrativeRole_Clerk;
ALTER TABLE ClerkAdministrativeRole DROP CONSTRAINT ClerkAdministrativeRole_Role;

ALTER TABLE Clerk DROP CONSTRAINT Clerk_Clerk;
ALTER TABLE Clerk DROP CONSTRAINT Clerk_Person;

ALTER TABLE Course DROP CONSTRAINT Course_Lecturer;
ALTER TABLE Course DROP CONSTRAINT Course_Subject;

ALTER TABLE Faculty DROP CONSTRAINT Faculty_Lecturer;

ALTER TABLE FinalGrade DROP CONSTRAINT FinalGrade_Course;
ALTER TABLE FinalGrade DROP CONSTRAINT FinalGrade_Lecturer;
ALTER TABLE FinalGrade DROP CONSTRAINT FinalGrade_Student;

ALTER TABLE GradeComponent DROP CONSTRAINT GradeComponent_FinalGrade;
ALTER TABLE GradeComponent DROP CONSTRAINT GradeComponent_GradeType;

ALTER TABLE "Group" DROP CONSTRAINT Group_AcademicSemester;
ALTER TABLE "Group" DROP CONSTRAINT Group_GroupType;

ALTER TABLE Lecturer DROP CONSTRAINT Lecturer_Degree;
ALTER TABLE Lecturer DROP CONSTRAINT Lecturer_Faculty;
ALTER TABLE Lecturer DROP CONSTRAINT Lecturer_Lecturer;

ALTER TABLE Person DROP CONSTRAINT Person_CorrespondenceAddress;
ALTER TABLE Person DROP CONSTRAINT Person_PermanentAddress;

ALTER TABLE PetitionStatus DROP CONSTRAINT PetitionStatus_Petition;
ALTER TABLE PetitionStatus DROP CONSTRAINT PetitionStatus_Status;

ALTER TABLE Petition DROP CONSTRAINT Petition_Clerk;
ALTER TABLE Petition DROP CONSTRAINT Petition_Student;

ALTER TABLE StudentGroup DROP CONSTRAINT StudentGroup_Group;
ALTER TABLE StudentGroup DROP CONSTRAINT StudentGroup_Student;

ALTER TABLE Subject DROP CONSTRAINT Subject_Faculty;

ALTER TABLE Lecturer DROP CONSTRAINT Lecturer_Person;
ALTER TABLE Person DROP CONSTRAINT Person_Country;
ALTER TABLE Student DROP CONSTRAINT Student_Person;


DROP TABLE AcademicSemester;
DROP TABLE AcademicYear;
DROP TABLE AdministrativeRole;
DROP TABLE Address;
DROP TABLE Class;
DROP TABLE Clerk;
DROP TABLE ClerkAdministrativeRole;
DROP TABLE Country;
DROP TABLE Course;
DROP TABLE Degree;
DROP TABLE Faculty;
DROP TABLE FinalGrade;
DROP TABLE GradeComponent;
DROP TABLE GradeType;
DROP TABLE "Group";
DROP TABLE GroupType;
DROP TABLE Lecturer;
DROP TABLE Person;
DROP TABLE Petition;
DROP TABLE PetitionStatus;
DROP TABLE Role;
DROP TABLE Room;
DROP TABLE Status;
DROP TABLE Student;
DROP TABLE StudentGroup;
DROP TABLE Subject;
DROP TABLE "User";
Drop table UserRole;
