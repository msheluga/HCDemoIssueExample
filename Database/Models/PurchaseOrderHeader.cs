﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// General purchase order information. See PurchaseOrderDetail.
/// </summary>
[Table("PurchaseOrderHeader", Schema = "Purchasing")]
[Index("EmployeeID", Name = "IX_PurchaseOrderHeader_EmployeeID")]
[Index("VendorID", Name = "IX_PurchaseOrderHeader_VendorID")]
public partial class PurchaseOrderHeader
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    public int PurchaseOrderID { get; set; }

    /// <summary>
    /// Incremental number to track changes to the purchase order over time.
    /// </summary>
    public byte RevisionNumber { get; set; }

    /// <summary>
    /// Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.
    /// </summary>
    public int EmployeeID { get; set; }

    /// <summary>
    /// Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.
    /// </summary>
    public int VendorID { get; set; }

    /// <summary>
    /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
    /// </summary>
    public int ShipMethodID { get; set; }

    /// <summary>
    /// Purchase order creation date.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Estimated shipment date from the vendor.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? ShipDate { get; set; }

    /// <summary>
    /// Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Tax amount.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal TaxAmt { get; set; }

    /// <summary>
    /// Shipping cost.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal Freight { get; set; }

    /// <summary>
    /// Total due to vendor. Computed as Subtotal + TaxAmt + Freight.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal TotalDue { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("EmployeeID")]
    [InverseProperty("PurchaseOrderHeaders")]
    public virtual Employee Employee { get; set; }

    [InverseProperty("PurchaseOrder")]
    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    [ForeignKey("ShipMethodID")]
    [InverseProperty("PurchaseOrderHeaders")]
    public virtual ShipMethod ShipMethod { get; set; }

    [ForeignKey("VendorID")]
    [InverseProperty("PurchaseOrderHeaders")]
    public virtual Vendor Vendor { get; set; }
}
