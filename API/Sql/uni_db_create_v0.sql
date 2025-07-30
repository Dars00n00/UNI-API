CREATE TABLE AcademicSemester (
                                  IdAcademicSemester INT IDENTITY(1,1) NOT NULL,
                                  IdAcademicYear INT NOT NULL,
                                  BeginDate DATE NOT NULL,
                                  EndDate DATE NOT NULL,
                                  CONSTRAINT AcademicSemester_pk PRIMARY KEY (IdAcademicSemester)
);

CREATE TABLE AcademicYear (
                              IdAcademicYear INT IDENTITY(1,1) NOT NULL,
                              BeginDate DATE NOT NULL,
                              EndDate DATE NOT NULL,
                              CONSTRAINT AcademicYear_pk PRIMARY KEY (IdAcademicYear)
);

CREATE TABLE Address (
                         IdAddress INT IDENTITY(1,1) NOT NULL,
                         StreetName VARCHAR(100) NOT NULL,
                         BuildingNumber VARCHAR(10) NOT NULL,
                         ApartmentNumber VARCHAR(10) NULL,
                         PostalCode VARCHAR(10) NOT NULL,
                         CityName VARCHAR(100) NOT NULL,
                         IdCountry INT NOT NULL,
                         CONSTRAINT Address_pk PRIMARY KEY (IdAddress)
);

CREATE TABLE Class (
                       IdClass INT IDENTITY(1,1) NOT NULL,
                       IdLecturer INT NOT NULL,
                       IdGroup INT NOT NULL,
                       IdCourse INT NOT NULL,
                       IdRoom INT NOT NULL,
                       BeginTime DATETIME NOT NULL,
                       DurationMinutes INT NOT NULL,
                       CONSTRAINT Class_pk PRIMARY KEY (IdClass)
);

CREATE TABLE Clerk (
                       IdClerk INT IDENTITY(1,1) NOT NULL,
                       CONSTRAINT Clerk_pk PRIMARY KEY (IdClerk)
);

CREATE TABLE Country (
                         IdCountry INT IDENTITY(1,1) NOT NULL,
                         CountryName VARCHAR(100) NOT NULL,
                         NationalityName VARCHAR(100) NOT NULL,
                         CONSTRAINT Country_pk PRIMARY KEY (IdCountry)
);

CREATE TABLE Course (
                        IdCourse INT IDENTITY(1,1) NOT NULL,
                        IdSubject INT NOT NULL,
                        IdMainLecturer INT NOT NULL,
                        BeginDate DATE NOT NULL,
                        EndDate DATE NOT NULL,
                        CONSTRAINT Course_pk PRIMARY KEY (IdCourse)
);

CREATE TABLE Degree (
                        IdDegree INT IDENTITY(1,1) NOT NULL,
                        DegreeName VARCHAR(100) NOT NULL,
                        CONSTRAINT Degree_pk PRIMARY KEY (IdDegree)
);

CREATE TABLE Faculty (
                         IdFaculty INT IDENTITY(1,1) NOT NULL,
                         FacultyName VARCHAR(255) NOT NULL,
                         CONSTRAINT Faculty_pk PRIMARY KEY (IdFaculty)
);

CREATE TABLE FinalGrade (
                            IdFinalGrade INT IDENTITY(1,1) NOT NULL,
                            IdStudent INT NOT NULL,
                            IdCourse INT NOT NULL,
                            FinalGrade DECIMAL(2,1) NOT NULL,
                            CONSTRAINT FinalGrade_pk PRIMARY KEY (IdFinalGrade)
);

CREATE TABLE GradeComponent (
                                IdGradeComponent INT IDENTITY(1,1) NOT NULL,
                                IdFinalGrade INT NOT NULL,
                                IdGradeType INT NOT NULL,
                                Grade DECIMAL(2,1) NOT NULL,
                                CONSTRAINT GradeComponent_pk PRIMARY KEY (IdGradeComponent)
);

CREATE TABLE GradeType (
                           IdGradeType INT IDENTITY(1,1) NOT NULL,
                           GradeType VARCHAR(255) NOT NULL,
                           CONSTRAINT GradeType_pk PRIMARY KEY (IdGradeType)
);

CREATE TABLE "Group" (
                         IdGroup INT IDENTITY(1,1) NOT NULL,
                         IdGroupType INT NOT NULL,
                         IdAcademicSemester INT NOT NULL,
                         CONSTRAINT Group_pk PRIMARY KEY (IdGroup)
);

CREATE TABLE GroupType (
                           IdGroupType INT IDENTITY(1,1) NOT NULL,
                           GroupType VARCHAR(100) NOT NULL,
                           CONSTRAINT GroupType_pk PRIMARY KEY (IdGroupType)
);

CREATE TABLE Lecturer (
                          IdLecturer INT IDENTITY(1,1) NOT NULL,
                          IdDegree INT NOT NULL,
                          IdFaculty INT NOT NULL,
                          CONSTRAINT Lecturer_pk PRIMARY KEY (IdLecturer)
);

CREATE TABLE Person (
                        IdPerson INT IDENTITY(1,1) NOT NULL,
                        FirstName VARCHAR(100) NOT NULL,
                        LastName VARCHAR(100) NOT NULL,
                        Email VARCHAR(100) NOT NULL,
                        Gender CHAR(1) NOT NULL,
                        Birthdate DATE NOT NULL,
                        IdNationality INT NOT NULL,
                        IdCorrespondenceAddress INT NOT NULL,
                        IdPermanentAddress INT NOT NULL,
                        IdUser INT NOT NULL,
                        CONSTRAINT Person_pk PRIMARY KEY (IdPerson)
);

CREATE TABLE Petition (
                          IdPetition INT IDENTITY(1,1) NOT NULL,
                          Content VARCHAR(500) NOT NULL,
                          FilingDatetime DATETIME NOT NULL,
                          DecisionDatetime DATETIME NULL,
                          DecisionDetails VARCHAR(500) NULL,
                          IdClerk INT NOT NULL,
                          IdStudent INT NOT NULL,
                          CONSTRAINT Petition_pk PRIMARY KEY (IdPetition)
);

CREATE TABLE PetitionStatus (
                                IdPetition INT NOT NULL,
                                IdStatus INT NOT NULL,
                                UpdateDatetime DATETIME NOT NULL,
                                CONSTRAINT PetitionStatus_pk PRIMARY KEY (IdPetition, IdStatus)
);

CREATE TABLE Role (
                      IdRole INT IDENTITY(1,1) NOT NULL,
                      Role VARCHAR(100) NOT NULL,
                      CONSTRAINT Role_pk PRIMARY KEY (IdRole)
);

CREATE TABLE Room (
                      IdRoom INT IDENTITY(1,1) NOT NULL,
                      RoomNumber INT NOT NULL,
                      BuildingSymbol VARCHAR(3) NOT NULL,
                      MaxStudents INT NOT NULL,
                      ComputerRoom BIT NOT NULL,
                      HasProjector BIT NOT NULL,
                      HasInteractiveWhiteboard BIT NOT NULL,
                      HasAirConditioning BIT NOT NULL,
                      OtherFacilities VARCHAR(200) NULL,
                      CONSTRAINT Room_pk PRIMARY KEY (IdRoom)
);

CREATE TABLE Status (
                        IdStatus INT IDENTITY(1,1) NOT NULL,
                        Status VARCHAR(100) NOT NULL,
                        CONSTRAINT Status_pk PRIMARY KEY (IdStatus)
);

CREATE TABLE Student (
                         IdStudent INT IDENTITY(1,1) NOT NULL,
                         EnrollmentDate DATE NOT NULL,
                         GraduationDate DATE NULL,
                         CONSTRAINT Student_pk PRIMARY KEY (IdStudent)
);

CREATE TABLE StudentGroup (
                              IdGroup INT NOT NULL,
                              IdStudent INT NOT NULL,
                              CONSTRAINT StudentGroup_pk PRIMARY KEY (IdGroup, IdStudent)
);

CREATE TABLE Subject (
                         IdSubject INT IDENTITY(1,1) NOT NULL,
                         SubjectName VARCHAR(100) NOT NULL,
                         SubjectSymbol VARCHAR(5) NOT NULL,
                         EctsPoints INT NOT NULL,
                         FinalExam BIT NOT NULL,
                         IdFaculty INT NOT NULL,
                         CONSTRAINT Subject_pk PRIMARY KEY (IdSubject)
);

CREATE TABLE "User" (
                        IdUser INT IDENTITY(1,1) NOT NULL,
                        Username VARCHAR(100) NOT NULL,
                        HashedPassword NVARCHAR(MAX) NOT NULL,
                        CreatedAt DATETIME NOT NULL,
                        CONSTRAINT User_pk PRIMARY KEY (IdUser)
);

CREATE TABLE UserRole (
                          IdRole INT NOT NULL,
                          IdUser INT NOT NULL,
                          CONSTRAINT UserRole_pk PRIMARY KEY (IdRole, IdUser)
);

ALTER TABLE AcademicSemester ADD CONSTRAINT AcademicSemester_AcademicYear
    FOREIGN KEY (IdAcademicYear) REFERENCES AcademicYear (IdAcademicYear);

ALTER TABLE Address ADD CONSTRAINT Address_Country
    FOREIGN KEY (IdCountry) REFERENCES Country (IdCountry);

ALTER TABLE Class ADD CONSTRAINT Class_Course
    FOREIGN KEY (IdCourse) REFERENCES Course (IdCourse);

ALTER TABLE Class ADD CONSTRAINT Class_Group
    FOREIGN KEY (IdGroup) REFERENCES "Group" (IdGroup);

ALTER TABLE Class ADD CONSTRAINT Class_Lecturer
    FOREIGN KEY (IdLecturer) REFERENCES Lecturer (IdLecturer);

ALTER TABLE Class ADD CONSTRAINT Class_Room
    FOREIGN KEY (IdRoom) REFERENCES Room (IdRoom);

ALTER TABLE Clerk ADD CONSTRAINT Clerk_Person
    FOREIGN KEY (IdClerk) REFERENCES Person (IdPerson);

ALTER TABLE Course ADD CONSTRAINT Course_Lecturer
    FOREIGN KEY (IdMainLecturer) REFERENCES Lecturer (IdLecturer);

ALTER TABLE Course ADD CONSTRAINT Course_Subject
    FOREIGN KEY (IdSubject) REFERENCES Subject (IdSubject);

ALTER TABLE FinalGrade ADD CONSTRAINT FinalGrade_Course
    FOREIGN KEY (IdCourse) REFERENCES Course (IdCourse);

ALTER TABLE FinalGrade ADD CONSTRAINT FinalGrade_Student
    FOREIGN KEY (IdStudent) REFERENCES Student (IdStudent);

ALTER TABLE GradeComponent ADD CONSTRAINT GradeComponent_FinalGrade
    FOREIGN KEY (IdFinalGrade) REFERENCES FinalGrade (IdFinalGrade);

ALTER TABLE GradeComponent ADD CONSTRAINT GradeComponent_GradeType
    FOREIGN KEY (IdGradeType) REFERENCES GradeType (IdGradeType);

ALTER TABLE "Group" ADD CONSTRAINT Group_AcademicSemester
    FOREIGN KEY (IdAcademicSemester) REFERENCES AcademicSemester (IdAcademicSemester);

ALTER TABLE "Group" ADD CONSTRAINT Group_GroupType
    FOREIGN KEY (IdGroupType) REFERENCES GroupType (IdGroupType);

ALTER TABLE Lecturer ADD CONSTRAINT Lecturer_Degree
    FOREIGN KEY (IdDegree) REFERENCES Degree (IdDegree);

ALTER TABLE Lecturer ADD CONSTRAINT Lecturer_Faculty
    FOREIGN KEY (IdFaculty) REFERENCES Faculty (IdFaculty);

ALTER TABLE Person ADD CONSTRAINT Person_CorrespondenceAddress
    FOREIGN KEY (IdCorrespondenceAddress) REFERENCES Address (IdAddress);

ALTER TABLE Person ADD CONSTRAINT Person_PermanentAddress
    FOREIGN KEY (IdPermanentAddress) REFERENCES Address (IdAddress);

ALTER TABLE Person ADD CONSTRAINT Person_User
    FOREIGN KEY (IdUser) REFERENCES "User" (IdUser);

ALTER TABLE PetitionStatus ADD CONSTRAINT PetitionStatus_Petition
    FOREIGN KEY (IdPetition) REFERENCES Petition (IdPetition);

ALTER TABLE PetitionStatus ADD CONSTRAINT PetitionStatus_Status
    FOREIGN KEY (IdStatus) REFERENCES Status (IdStatus);

ALTER TABLE Petition ADD CONSTRAINT Petition_Clerk
    FOREIGN KEY (IdClerk) REFERENCES Clerk (IdClerk);

ALTER TABLE Petition ADD CONSTRAINT Petition_Student
    FOREIGN KEY (IdStudent) REFERENCES Student (IdStudent);

ALTER TABLE StudentGroup ADD CONSTRAINT StudentGroup_Group
    FOREIGN KEY (IdGroup) REFERENCES "Group" (IdGroup);

ALTER TABLE StudentGroup ADD CONSTRAINT StudentGroup_Student
    FOREIGN KEY (IdStudent) REFERENCES Student (IdStudent);

ALTER TABLE Subject ADD CONSTRAINT Subject_Faculty
    FOREIGN KEY (IdFaculty) REFERENCES Faculty (IdFaculty);

ALTER TABLE UserRole ADD CONSTRAINT Table_33_Role
    FOREIGN KEY (IdRole) REFERENCES Role (IdRole);

ALTER TABLE UserRole ADD CONSTRAINT Table_33_User
    FOREIGN KEY (IdUser) REFERENCES "User" (IdUser);

ALTER TABLE Lecturer ADD CONSTRAINT lecturer_person
    FOREIGN KEY (IdLecturer) REFERENCES Person (IdPerson);

ALTER TABLE Person ADD CONSTRAINT person_country
    FOREIGN KEY (IdNationality) REFERENCES Country (IdCountry);

ALTER TABLE Student ADD CONSTRAINT student_person
    FOREIGN KEY (IdStudent) REFERENCES Person (IdPerson);