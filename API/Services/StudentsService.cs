using API.DTOs;
using API.DTOs.Students;
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

    public Task<IEnumerable<StudentDto>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        /*var resultStudents = _context.Students
            .Include(s => s.)
            .Select(p => new StudentDto
            {
                Person = new PersonDto
                {
                    FirstName = p.
                }
            })*/

        return null;
    }

    public async Task<bool> CreateStudentAsync(NewStudentDto newStudentDto, CancellationToken cancellationToken)
    {
        var countryInCorrespondenceAddress = await _context.Countries
            .FirstOrDefaultAsync(c => c.CountryName == newStudentDto.PersonDto.CorrespondenceAddress.CountryName, cancellationToken);
        var countryInPermanentAddress = await _context.Countries
            .FirstOrDefaultAsync(c => c.CountryName == newStudentDto.PersonDto.PermanentAddress.CountryName, cancellationToken);
        
        var countryNationality = await _context.Countries
            .FirstOrDefaultAsync(c => c.NationalityName == newStudentDto.PersonDto.Nationality, cancellationToken);
        
        if (countryInCorrespondenceAddress == null 
            || countryInPermanentAddress == null 
            || countryNationality == null)
        {
            throw new Exception();
        }
        
        await _context.Database.BeginTransactionAsync(cancellationToken);

        var correspondenceAddressModel = new Address
        {
            StreetName = newStudentDto.PersonDto.CorrespondenceAddress.StreetName,
            BuildingNumber = newStudentDto.PersonDto.CorrespondenceAddress.BuildingNumber,
            ApartmentNumber = newStudentDto.PersonDto.CorrespondenceAddress.ApartmentNumber,
            PostalCode = newStudentDto.PersonDto.CorrespondenceAddress.PostalCode,
            CityName = newStudentDto.PersonDto.CorrespondenceAddress.CityName,
            IdCountry = countryInCorrespondenceAddress.IdCountry
        };

        var permanentAddressModel = new Address
        {
            StreetName = newStudentDto.PersonDto.PermanentAddress.StreetName,
            BuildingNumber = newStudentDto.PersonDto.PermanentAddress.BuildingNumber,
            ApartmentNumber = newStudentDto.PersonDto.PermanentAddress.ApartmentNumber,
            PostalCode = newStudentDto.PersonDto.PermanentAddress.PostalCode,
            CityName = newStudentDto.PersonDto.PermanentAddress.CityName,
            IdCountry = countryInPermanentAddress.IdCountry
        };

        await _context.Addresses.AddAsync(correspondenceAddressModel, cancellationToken);
        await _context.Addresses.AddAsync(permanentAddressModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var personModel = new Person
        {
            FirstName = newStudentDto.PersonDto.FirstName,
            LastName = newStudentDto.PersonDto.LastName,
            Email = newStudentDto.PersonDto.Email,
            Gender = newStudentDto.PersonDto.Gender,
            Birthdate = newStudentDto.PersonDto.Birthdate,
            IdNationality = countryNationality.IdCountry,
            IdCorrespondenceAddress = correspondenceAddressModel.IdAddress,
            IdPernamentAddress = permanentAddressModel.IdAddress,
        };
        
        await _context.People.AddAsync(personModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var studentModel = new Student
        {
            IdStudent = personModel.IdPerson,
            EnrollementDate = newStudentDto.EnrollmentDate
        };
        
        await _context.Students.AddAsync(studentModel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        await _context.Database.CommitTransactionAsync(cancellationToken);

        return true;
    }
    
}