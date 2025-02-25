﻿using Data.Entities;

namespace Business.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string DisplayName => $"{FirstName} {LastName}";

    public Role? Role { get; set; } = null!;
}
