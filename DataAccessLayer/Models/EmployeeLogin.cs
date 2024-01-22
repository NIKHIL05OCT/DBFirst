using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class EmployeeLogin
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? EmailId { get; set; }

    public string? Password { get; set; }
}
