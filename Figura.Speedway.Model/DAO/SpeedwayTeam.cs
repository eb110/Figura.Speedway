using System;
using System.Collections.Generic;

namespace Figura.Speedway.Model.DAO;

public partial class SpeedwayTeam
{
    public int TeamId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateOnly? CreationDate { get; set; }
}
