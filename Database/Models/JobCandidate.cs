﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Résumés submitted to Human Resources by job applicants.
/// </summary>
[Table("JobCandidate", Schema = "HumanResources")]
[Index("BusinessEntityID", Name = "IX_JobCandidate_BusinessEntityID")]
public partial class JobCandidate
{
    /// <summary>
    /// Primary key for JobCandidate records.
    /// </summary>
    [Key]
    public int JobCandidateID { get; set; }

    /// <summary>
    /// Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.
    /// </summary>
    public int? BusinessEntityID { get; set; }

    /// <summary>
    /// Résumé in XML format.
    /// </summary>
    [Column(TypeName = "xml")]
    public string Resume { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityID")]
    [InverseProperty("JobCandidates")]
    public virtual Employee BusinessEntity { get; set; }
}
