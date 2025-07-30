using API.DTOs.Students;
using API.Exceptions;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class StudentsService : IStudentsService
{
    private readonly UniversityContext _context;

    public StudentsService(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsWithGradesAsync(CancellationToken cancellationToken)
    {
        /*var resultStudents = await _context.Students
            .Include(s => s.IdStudentNavigation)
                .ThenInclude(s => s.IdNationalityNavigation)
                .ThenInclude(s => s.Addresses)
                    .ThenInclude(a => a.IdCountryNavigation)
            .Include(s => s.FinalGrades)
                .ThenInclude(f => f.GradeComponents)
            .Include(s => s.IdGroups)
                .ThenInclude(g => g.Classes)
            .Select(s => new StudentDto
            {
                Person = new PersonDto
                {
                    FirstName = s.IdStudentNavigation.FirstName,
                    LastName = s.IdStudentNavigation.LastName,
                    Email = s.IdStudentNavigation.Email,
                    Gender = s.IdStudentNavigation.Gender,
                    Birthdate = s.IdStudentNavigation.Birthdate,
                    Nationality = s.IdStudentNavigation.IdNationalityNavigation.NationalityName,
                    CorrespondenceAddress = new AddressDto
                    {
                        StreetName = s.IdStudentNavigation.IdCorrespondenceAddressNavigation.StreetName,
                        BuildingNumber = s.IdStudentNavigation.IdCorrespondenceAddressNavigation.BuildingNumber,
                        ApartmentNumber = s.IdStudentNavigation.IdCorrespondenceAddressNavigation.ApartmentNumber ?? "-",
                        PostalCode = s.IdStudentNavigation.IdCorrespondenceAddressNavigation.PostalCode,
                        CityName = s.IdStudentNavigation.IdCorrespondenceAddressNavigation.PostalCode,
                        CountryName = s.IdStudentNavigation.IdCorrespondenceAddressNavigation.IdCountryNavigation.CountryName
                    },
                    PermanentAddress = new AddressDto
                    {
                        StreetName = s.IdStudentNavigation.IdPermanentAddressNavigation.StreetName,
                        BuildingNumber = s.IdStudentNavigation.IdPermanentAddressNavigation.BuildingNumber,
                        ApartmentNumber = s.IdStudentNavigation.IdPermanentAddressNavigation.ApartmentNumber ?? "-",
                        PostalCode = s.IdStudentNavigation.IdPermanentAddressNavigation.PostalCode,
                        CityName = s.IdStudentNavigation.IdPermanentAddressNavigation.PostalCode,
                        CountryName = s.IdStudentNavigation.IdPermanentAddressNavigation.IdCountryNavigation.CountryName
                    }
                },
                
                FinalGrades = s.FinalGrades.Select(fg => new FinalGradeDto
                {
                    FinalGrade = fg.FinalGrade1,
                    Course = new CourseDto
                    {
                        MainLecturerFullName = fg.IdLecturerNavigation.IdLecturerNavigation.FirstName 
                            + fg.IdLecturerNavigation.IdLecturerNavigation.LastName,
                        CourseBeginDate = fg.IdCourseNavigation.BeginDate,
                        CourseEndDate = fg.IdCourseNavigation.EndDate,
                        Subject = new SubjectDto
                        {
                            SubjectName = fg.IdCourseNavigation.IdSubjectNavigation.SubjectName,
                            SubjectSymbol = fg.IdCourseNavigation.IdSubjectNavigation.SubjectSymbol,
                            EctsPoints = fg.IdCourseNavigation.IdSubjectNavigation.EctsPoints,
                            FinalExam = fg.IdCourseNavigation.IdSubjectNavigation.FinalExam,
                            FacultyName = fg.IdCourseNavigation.IdSubjectNavigation.IdFacultyNavigation.FacultyName
                        }
                    }
                    
                }).ToList(),
            }).ToListAsync(cancellationToken);*/
            
        
        return null;
    }

    public Task<StudentDto> GetStudentWithGradesByStudentFilter(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


    public async Task<bool> CreateStudentAsync(NewStudentDto newStudentDto, CancellationToken cancellationToken)
    {
        var countryInCorrespondenceAddress = await _context.Countries
            .FirstOrDefaultAsync(c => c.IdCountry == newStudentDto.Person.CorrespondenceAddress.IdCountry, cancellationToken);
        var countryInPermanentAddress = await _context.Countries
            .FirstOrDefaultAsync(c => c.IdCountry == newStudentDto.Person.PermanentAddress.IdCountry, cancellationToken);
        var countryNationality = await _context.Countries
            .FirstOrDefaultAsync(c => c.IdCountry == newStudentDto.Person.IdNationality, cancellationToken);
        
        if (countryInCorrespondenceAddress == null)
        {
            throw new CountryNotFoundException(newStudentDto.Person.CorrespondenceAddress.IdCountry);
        }
        if (countryInPermanentAddress == null)
        {
            throw new CountryNotFoundException(newStudentDto.Person.PermanentAddress.IdCountry);
        }
        if (countryNationality == null)
        {
            throw new CountryNotFoundException(newStudentDto.Person.IdNationality);
        }
        
        await _context.Database.BeginTransactionAsync(cancellationToken);

        var correspondenceAddressModel = new Address
        {
            StreetName = newStudentDto.Person.CorrespondenceAddress.StreetName,
            BuildingNumber = newStudentDto.Person.CorrespondenceAddress.BuildingNumber,
            ApartmentNumber = newStudentDto.Person.CorrespondenceAddress.ApartmentNumber,
            PostalCode = newStudentDto.Person.CorrespondenceAddress.PostalCode,
            CityName = newStudentDto.Person.CorrespondenceAddress.CityName,
            IdCountry = countryInCorrespondenceAddress.IdCountry
        };

        var permanentAddressModel = new Address
        {
            StreetName = newStudentDto.Person.PermanentAddress.StreetName,
            BuildingNumber = newStudentDto.Person.PermanentAddress.BuildingNumber,
            ApartmentNumber = newStudentDto.Person.PermanentAddress.ApartmentNumber,
            PostalCode = newStudentDto.Person.PermanentAddress.PostalCode,
            CityName = newStudentDto.Person.PermanentAddress.CityName,
            IdCountry = countryInPermanentAddress.IdCountry
        };

        await _context.Addresses.AddAsync(correspondenceAddressModel, cancellationToken);
        await _context.Addresses.AddAsync(permanentAddressModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var personModel = new Person
        {
            FirstName = newStudentDto.Person.FirstName,
            LastName = newStudentDto.Person.LastName,
            Email = newStudentDto.Person.Email,
            Gender = newStudentDto.Person.Gender,
            Birthdate = newStudentDto.Person.Birthdate,
            IdNationality = countryNationality.IdCountry,
            IdCorrespondenceAddress = correspondenceAddressModel.IdAddress,
            IdPermanentAddress = permanentAddressModel.IdAddress,
        };
        
        await _context.People.AddAsync(personModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var studentModel = new Student
        {
            IdStudent = personModel.IdPerson,
            EnrollmentDate = newStudentDto.EnrollmentDate
        };
        
        await _context.Students.AddAsync(studentModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await _context.Database.CommitTransactionAsync(cancellationToken);

        return true;
    }
    
}