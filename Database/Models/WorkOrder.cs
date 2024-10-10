﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Manufacturing work orders.
/// </summary>
[Table("WorkOrder", Schema = "Production")]
[Index("ProductID", Name = "IX_WorkOrder_ProductID")]
[Index("ScrapReasonID", Name = "IX_WorkOrder_ScrapReasonID")]
public partial class WorkOrder
{
    /// <summary>
    /// Primary key for WorkOrder records.
    /// </summary>
    [Key]
    public int WorkOrderID { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int ProductID { get; set; }

    /// <summary>
    /// Product quantity to build.
    /// </summary>
    public int OrderQty { get; set; }

    /// <summary>
    /// Quantity built and put in inventory.
    /// </summary>
    public int StockedQty { get; set; }

    /// <summary>
    /// Quantity that failed inspection.
    /// </summary>
    public short ScrappedQty { get; set; }

    /// <summary>
    /// Work order start date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Work order end date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Work order due date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Reason for inspection failure.
    /// </summary>
    public short? ScrapReasonID { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductID")]
    [InverseProperty("WorkOrders")]
    public virtual Product Product { get; set; }

    [ForeignKey("ScrapReasonID")]
    [InverseProperty("WorkOrders")]
    public virtual ScrapReason ScrapReason { get; set; }

    [InverseProperty("WorkOrder")]
    public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; } = new List<WorkOrderRouting>();
}
