using System;
using System.Collections.Generic;

namespace AngularApp2.Server.Models;

public partial class Regestration
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }
}
