﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Models;

/// <summary>
/// State and province lookup table.
/// </summary>
[Table("StateProvince", Schema = "Person")]
[Index("Name", Name = "AK_StateProvince_Name", IsUnique = true)]
[Index("StateProvinceCode", "CountryRegionCode", Name = "AK_StateProvince_StateProvinceCode_CountryRegionCode", IsUnique = true)]
[Index("rowguid", Name = "AK_StateProvince_rowguid", IsUnique = true)]
public partial class StateProvince
{
    /// <summary>
    /// Primary key for StateProvince records.
    /// </summary>
    [Key]
    public int StateProvinceID { get; set; }

    /// <summary>
    /// ISO standard state or province code.
    /// </summary>
    [Required]
    [StringLength(3)]
    public string StateProvinceCode { get; set; }

    /// <summary>
    /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
    /// </summary>
    [Required]
    [StringLength(3)]
    public string CountryRegionCode { get; set; }

    /// <summary>
    /// 0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.
    /// </summary>
    [Required]
    public bool? IsOnlyStateProvinceFlag { get; set; }

    /// <summary>
    /// State or province description.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    public int TerritoryID { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("StateProvince")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [ForeignKey("CountryRegionCode")]
    [InverseProperty("StateProvinces")]
    public virtual CountryRegion CountryRegionCodeNavigation { get; set; }

    [InverseProperty("StateProvince")]
    public virtual ICollection<SalesTaxRate> SalesTaxRates { get; set; } = new List<SalesTaxRate>();

    [ForeignKey("TerritoryID")]
    [InverseProperty("StateProvinces")]
    public virtual SalesTerritory Territory { get; set; }
}