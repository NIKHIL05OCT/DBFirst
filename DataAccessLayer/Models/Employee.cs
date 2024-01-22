using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }
}
