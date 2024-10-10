﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Cross-reference table mapping sales orders to sales reason codes.
/// </summary>
[PrimaryKey("SalesOrderID", "SalesReasonID")]
[Table("SalesOrderHeaderSalesReason", Schema = "Sales")]
public partial class SalesOrderHeaderSalesReason
{
    /// <summary>
    /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
    /// </summary>
    [Key]
    public int SalesOrderID { get; set; }

    /// <summary>
    /// Primary key. Foreign key to SalesReason.SalesReasonID.
    /// </summary>
    [Key]
    public int SalesReasonID { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("SalesOrderID")]
    [InverseProperty("SalesOrderHeaderSalesReasons")]
    public virtual SalesOrderHeader SalesOrder { get; set; }

    [ForeignKey("SalesReasonID")]
    [InverseProperty("SalesOrderHeaderSalesReasons")]
    public virtual SalesReason SalesReason { get; set; }
}
