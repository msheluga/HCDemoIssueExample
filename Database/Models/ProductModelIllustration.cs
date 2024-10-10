﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Cross-reference table mapping product models and illustrations.
/// </summary>
[PrimaryKey("ProductModelID", "IllustrationID")]
[Table("ProductModelIllustration", Schema = "Production")]
public partial class ProductModelIllustration
{
    /// <summary>
    /// Primary key. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    [Key]
    public int ProductModelID { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Illustration.IllustrationID.
    /// </summary>
    [Key]
    public int IllustrationID { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("IllustrationID")]
    [InverseProperty("ProductModelIllustrations")]
    public virtual Illustration Illustration { get; set; }

    [ForeignKey("ProductModelID")]
    [InverseProperty("ProductModelIllustrations")]
    public virtual ProductModel ProductModel { get; set; }
}
