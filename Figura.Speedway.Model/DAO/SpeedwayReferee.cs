using System;
using System.Collections.Generic;

namespace Figura.Speedway.Model.DAO;

public partial class SpeedwayReferee
{
    public int RefId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public DateOnly? DoB { get; set; }
}
