using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Room
{
    public int IdRoom { get; set; }

    public int RoomNumber { get; set; }

    public string BuildingSymbol { get; set; } = null!;

    public int MaxStudents { get; set; }

    public bool ComputerRoom { get; set; }

    public bool HasProjector { get; set; }

    public bool HasInteractiveWhiteboard { get; set; }

    public bool HasAirConditioning { get; set; }

    public string? OtherFacilities { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
