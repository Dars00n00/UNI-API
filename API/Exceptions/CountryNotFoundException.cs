namespace API.Exceptions;

public class CountryNotFoundException : Exception
{
    public CountryNotFoundException(int idCountry)
        : base($"Country with id={idCountry} not found")
    {
    }

    public CountryNotFoundException(string countryName) 
        : base($"Country with name={countryName} not found")
    {
    }
}