﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Infrastructure.Entites;

public partial class EmployeeModel
{
    public Guid EmployeeId { get; set; }

    public string EmployeeCode { get; set; }

    public string ShortName { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public bool? Active { get; set; }

    public Guid? CreateBy { get; set; }

    public Guid? LastEditBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? LastEditTime { get; set; }

    public virtual ICollection<AccountModel> AccountModels { get; set; } = new List<AccountModel>();
}