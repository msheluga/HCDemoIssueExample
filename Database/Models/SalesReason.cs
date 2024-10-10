﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Lookup table of customer purchase reasons.
/// </summary>
[Table("SalesReason", Schema = "Sales")]
public partial class SalesReason
{
    /// <summary>
    /// Primary key for SalesReason records.
    /// </summary>
    [Key]
    public int SalesReasonID { get; set; }

    /// <summary>
    /// Sales reason description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Category the sales reason belongs to.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string ReasonType { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("SalesReason")]
    public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } = new List<SalesOrderHeaderSalesReason>();
}
