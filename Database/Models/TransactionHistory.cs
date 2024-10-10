﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Record of each purchase order, sales order, or work order transaction year to date.
/// </summary>
[Table("TransactionHistory", Schema = "Production")]
[Index("ProductID", Name = "IX_TransactionHistory_ProductID")]
[Index("ReferenceOrderID", "ReferenceOrderLineID", Name = "IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID")]
public partial class TransactionHistory
{
    /// <summary>
    /// Primary key for TransactionHistory records.
    /// </summary>
    [Key]
    public int TransactionID { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int ProductID { get; set; }

    /// <summary>
    /// Purchase order, sales order, or work order identification number.
    /// </summary>
    public int ReferenceOrderID { get; set; }

    /// <summary>
    /// Line number associated with the purchase order, sales order, or work order.
    /// </summary>
    public int ReferenceOrderLineID { get; set; }

    /// <summary>
    /// Date and time of the transaction.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// W = WorkOrder, S = SalesOrder, P = PurchaseOrder
    /// </summary>
    [Required]
    [StringLength(1)]
    public string TransactionType { get; set; }

    /// <summary>
    /// Product quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Product cost.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal ActualCost { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductID")]
    [InverseProperty("TransactionHistories")]
    public virtual Product Product { get; set; }
}
