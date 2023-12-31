﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Infrastructure.Entites;

public partial class RoleModel
{
    public Guid RoleId { get; set; }

    public string RoleCode { get; set; }

    public string RoleName { get; set; }

    public bool? Active { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? LastEditBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? LastEditTime { get; set; }

    public virtual ICollection<RolePageFunctionMapping> RolePageFunctionMappings { get; set; } = new List<RolePageFunctionMapping>();

    public virtual ICollection<AccountModel> Accounts { get; set; } = new List<AccountModel>();
}