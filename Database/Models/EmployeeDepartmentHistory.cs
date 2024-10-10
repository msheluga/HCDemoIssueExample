﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Employee department transfers.
/// </summary>
[PrimaryKey("BusinessEntityID", "StartDate", "DepartmentID", "ShiftID")]
[Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
[Index("DepartmentID", Name = "IX_EmployeeDepartmentHistory_DepartmentID")]
[Index("ShiftID", Name = "IX_EmployeeDepartmentHistory_ShiftID")]
public partial class EmployeeDepartmentHistory
{
    /// <summary>
    /// Employee identification number. Foreign key to Employee.BusinessEntityID.
    /// </summary>
    [Key]
    public int BusinessEntityID { get; set; }

    /// <summary>
    /// Department in which the employee worked including currently. Foreign key to Department.DepartmentID.
    /// </summary>
    [Key]
    public short DepartmentID { get; set; }

    /// <summary>
    /// Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.
    /// </summary>
    [Key]
    public byte ShiftID { get; set; }

    /// <summary>
    /// Date the employee started work in the department.
    /// </summary>
    [Key]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Date the employee left the department. NULL = Current department.
    /// </summary>
    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityID")]
    [InverseProperty("EmployeeDepartmentHistories")]
    public virtual Employee BusinessEntity { get; set; }

    [ForeignKey("DepartmentID")]
    [InverseProperty("EmployeeDepartmentHistories")]
    public virtual Department Department { get; set; }

    [ForeignKey("ShiftID")]
    [InverseProperty("EmployeeDepartmentHistories")]
    public virtual Shift Shift { get; set; }
}
