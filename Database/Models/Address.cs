﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Models;

/// <summary>
/// Street address information for customers, employees, and vendors.
/// </summary>
[Table("Address", Schema = "Person")]
[Index("rowguid", Name = "AK_Address_rowguid", IsUnique = true)]
[Index("AddressLine1", "AddressLine2", "City", "StateProvinceID", "PostalCode", Name = "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode", IsUnique = true)]
[Index("StateProvinceID", Name = "IX_Address_StateProvinceID")]
public partial class Address
{
    /// <summary>
    /// Primary key for Address records.
    /// </summary>
    [Key]
    [CustomAuthorize("AdventureWorks.Person.AddressId.Read")]
    public int AddressID { get; set; }

    /// <summary>
    /// First street address line.
    /// </summary>
    [Required]
    [StringLength(60)]
    [CustomAuthorize("AdventureWorks.Person.AddressLine1.Read")]
    public string AddressLine1 { get; set; }

    /// <summary>
    /// Second street address line.
    /// </summary>
    [StringLength(60)]
    [CustomAuthorize("AdventureWorks.Person.AddressLine2.Read")]
    public string AddressLine2 { get; set; }

    /// <summary>
    /// Name of the city.
    /// </summary>
    [Required]
    [StringLength(30)]
    [CustomAuthorize("AdventureWorks.Person.City.Read")]
    public string City { get; set; }

    /// <summary>
    /// Unique identification number for the state or province. Foreign key to StateProvince table.
    /// </summary>
    [CustomAuthorize("AdventureWorks.Person.StateProvidenceID.Read")]
    public int StateProvinceID { get; set; }

    /// <summary>
    /// Postal code for the street address.
    /// </summary>
    [Required]
    [StringLength(15)]
    [CustomAuthorize("AdventureWorks.Person.PostalCode.Read")]
    public string PostalCode { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [CustomAuthorize("AdventureWorks.Person.rowguid.Read")]
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    [CustomAuthorize("AdventureWorks.Person.ModifiedDate.Read")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new List<BusinessEntityAddress>();

    [InverseProperty("BillToAddress")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; } = new List<SalesOrderHeader>();

    [InverseProperty("ShipToAddress")]
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; } = new List<SalesOrderHeader>();

    [ForeignKey("StateProvinceID")]
    [InverseProperty("Addresses")]
    public virtual StateProvince StateProvince { get; set; }
}