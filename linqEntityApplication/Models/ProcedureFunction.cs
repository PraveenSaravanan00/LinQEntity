using System;
using System.Collections.Generic;

namespace linqEntityApplication.Models;

public partial class ProcedureFunction
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

    public int Price { get; set; }

    public int? Status { get; set; }
}
