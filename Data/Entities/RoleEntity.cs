﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
    public ICollection<UserEntity> Users { get; set; } = [];
    public ICollection<UserRoleEntity> UserRoles { get; set; } = [];
}

