using System;
using System.Collections.Generic;

namespace EmployeesPruebas.Models;


public partial class Employee
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string? CreatedOn { get; set; }

    public string? DeletedOn { get; set; }

    public string Email { get; set; } = null!;

    public string? Fax { get; set; }

    public string? Name { get; set; }

    public string? Lastlogin { get; set; }

    public string Password { get; set; } = null!;

    public int PortalId { get; set; }

    public int RoleId { get; set; }

    public int StatusId { get; set; }

    public string? Telephone { get; set; }

    public string? UpdatedOn { get; set; }

    public string Username { get; set; } = null!;
}