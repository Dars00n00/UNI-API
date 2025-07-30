using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class UniversityContext : DbContext
{
    public UniversityContext()
    {
    }

    public UniversityContext(DbContextOptions<UniversityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicSemester> AcademicSemesters { get; set; }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Clerk> Clerks { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<FinalGrade> FinalGrades { get; set; }

    public virtual DbSet<GradeComponent> GradeComponents { get; set; }

    public virtual DbSet<GradeType> GradeTypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupType> GroupTypes { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Petition> Petitions { get; set; }

    public virtual DbSet<PetitionStatus> PetitionStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicSemester>(entity =>
        {
            entity.HasKey(e => e.IdAcademicSemester).HasName("AcademicSemester_pk");

            entity.ToTable("AcademicSemester");

            entity.HasOne(d => d.IdAcademicYearNavigation).WithMany(p => p.AcademicSemesters)
                .HasForeignKey(d => d.IdAcademicYear)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("AcademicSemester_AcademicYear");
        });

        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.IdAcademicYear).HasName("AcademicYear_pk");

            entity.ToTable("AcademicYear");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("Address_pk");

            entity.ToTable("Address");

            entity.Property(e => e.ApartmentNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BuildingNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StreetName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_Country");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.IdClass).HasName("Class_pk");

            entity.ToTable("Class");

            entity.Property(e => e.BeginTime).HasColumnType("datetime");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Class_Course");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Class_Group");

            entity.HasOne(d => d.IdLecturerNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdLecturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Class_Lecturer");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Class_Room");
        });

        modelBuilder.Entity<Clerk>(entity =>
        {
            entity.HasKey(e => e.IdClerk).HasName("Clerk_pk");

            entity.ToTable("Clerk");

            entity.Property(e => e.IdClerk).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdClerkNavigation).WithOne(p => p.Clerk)
                .HasForeignKey<Clerk>(d => d.IdClerk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Clerk_Person");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("Country_pk");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NationalityName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.IdCourse).HasName("Course_pk");

            entity.ToTable("Course");

            entity.HasOne(d => d.IdMainLecturerNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdMainLecturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Course_Lecturer");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Course_Subject");
        });

        modelBuilder.Entity<Degree>(entity =>
        {
            entity.HasKey(e => e.IdDegree).HasName("Degree_pk");

            entity.ToTable("Degree");

            entity.Property(e => e.DegreeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.IdFaculty).HasName("Faculty_pk");

            entity.ToTable("Faculty");

            entity.Property(e => e.FacultyName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FinalGrade>(entity =>
        {
            entity.HasKey(e => e.IdFinalGrade).HasName("FinalGrade_pk");

            entity.ToTable("FinalGrade");

            entity.Property(e => e.FinalGrade1)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("FinalGrade");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.FinalGrades)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FinalGrade_Course");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.FinalGrades)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FinalGrade_Student");
        });

        modelBuilder.Entity<GradeComponent>(entity =>
        {
            entity.HasKey(e => e.IdGradeComponent).HasName("GradeComponent_pk");

            entity.ToTable("GradeComponent");

            entity.Property(e => e.Grade).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.IdFinalGradeNavigation).WithMany(p => p.GradeComponents)
                .HasForeignKey(d => d.IdFinalGrade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GradeComponent_FinalGrade");

            entity.HasOne(d => d.IdGradeTypeNavigation).WithMany(p => p.GradeComponents)
                .HasForeignKey(d => d.IdGradeType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GradeComponent_GradeType");
        });

        modelBuilder.Entity<GradeType>(entity =>
        {
            entity.HasKey(e => e.IdGradeType).HasName("GradeType_pk");

            entity.ToTable("GradeType");

            entity.Property(e => e.GradeType1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GradeType");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup).HasName("Group_pk");

            entity.ToTable("Group");

            entity.HasOne(d => d.IdAcademicSemesterNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdAcademicSemester)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Group_AcademicSemester");

            entity.HasOne(d => d.IdGroupTypeNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdGroupType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Group_GroupType");

            entity.HasMany(d => d.IdStudents).WithMany(p => p.IdGroups)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentGroup",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("StudentGroup_Student"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("StudentGroup_Group"),
                    j =>
                    {
                        j.HasKey("IdGroup", "IdStudent").HasName("StudentGroup_pk");
                        j.ToTable("StudentGroup");
                    });
        });

        modelBuilder.Entity<GroupType>(entity =>
        {
            entity.HasKey(e => e.IdGroupType).HasName("GroupType_pk");

            entity.ToTable("GroupType");

            entity.Property(e => e.GroupType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GroupType");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.IdLecturer).HasName("Lecturer_pk");

            entity.ToTable("Lecturer");

            entity.Property(e => e.IdLecturer).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdDegreeNavigation).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.IdDegree)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecturer_Degree");

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Lecturers)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lecturer_Faculty");

            entity.HasOne(d => d.IdLecturerNavigation).WithOne(p => p.Lecturer)
                .HasForeignKey<Lecturer>(d => d.IdLecturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lecturer_person");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("Person_pk");

            entity.ToTable("Person");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCorrespondenceAddressNavigation).WithMany(p => p.PersonIdCorrespondenceAddressNavigations)
                .HasForeignKey(d => d.IdCorrespondenceAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Person_CorrespondenceAddress");

            entity.HasOne(d => d.IdNationalityNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdNationality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_country");

            entity.HasOne(d => d.IdPermanentAddressNavigation).WithMany(p => p.PersonIdPermanentAddressNavigations)
                .HasForeignKey(d => d.IdPermanentAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Person_PermanentAddress");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Person_User");
        });

        modelBuilder.Entity<Petition>(entity =>
        {
            entity.HasKey(e => e.IdPetition).HasName("Petition_pk");

            entity.ToTable("Petition");

            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DecisionDatetime).HasColumnType("datetime");
            entity.Property(e => e.DecisionDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FilingDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.IdClerkNavigation).WithMany(p => p.Petitions)
                .HasForeignKey(d => d.IdClerk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Petition_Clerk");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Petitions)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Petition_Student");
        });

        modelBuilder.Entity<PetitionStatus>(entity =>
        {
            entity.HasKey(e => new { e.IdPetition, e.IdStatus }).HasName("PetitionStatus_pk");

            entity.ToTable("PetitionStatus");

            entity.Property(e => e.UpdateDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.IdPetitionNavigation).WithMany(p => p.PetitionStatuses)
                .HasForeignKey(d => d.IdPetition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PetitionStatus_Petition");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.PetitionStatuses)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PetitionStatus_Status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("Role_pk");

            entity.ToTable("Role");

            entity.Property(e => e.Role1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Role");

            entity.HasMany(d => d.IdUsers).WithMany(p => p.IdRoles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_33_User"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Table_33_Role"),
                    j =>
                    {
                        j.HasKey("IdRole", "IdUser").HasName("UserRole_pk");
                        j.ToTable("UserRole");
                    });
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.IdRoom).HasName("Room_pk");

            entity.ToTable("Room");

            entity.Property(e => e.BuildingSymbol)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.OtherFacilities)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("Status_pk");

            entity.ToTable("Status");

            entity.Property(e => e.Status1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent).HasName("Student_pk");

            entity.ToTable("Student");

            entity.Property(e => e.IdStudent).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdStudentNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_person");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.IdSubject).HasName("Subject_pk");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubjectSymbol)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subject_Faculty");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("User_pk");

            entity.ToTable("User");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
