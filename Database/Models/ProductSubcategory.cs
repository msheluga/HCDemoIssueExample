﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Product subcategories. See ProductCategory table.
/// </summary>
[Table("ProductSubcategory", Schema = "Production")]
[Index("Name", Name = "AK_ProductSubcategory_Name", IsUnique = true)]
[Index("rowguid", Name = "AK_ProductSubcategory_rowguid", IsUnique = true)]
public partial class ProductSubcategory
{
    /// <summary>
    /// Primary key for ProductSubcategory records.
    /// </summary>
    [Key]
    public int ProductSubcategoryID { get; set; }

    /// <summary>
    /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
    /// </summary>
    public int ProductCategoryID { get; set; }

    /// <summary>
    /// Subcategory description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductCategoryID")]
    [InverseProperty("ProductSubcategories")]
    public virtual ProductCategory ProductCategory { get; set; }

    [InverseProperty("ProductSubcategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
