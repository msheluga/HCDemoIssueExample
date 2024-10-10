﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// One way hashed authentication information
/// </summary>
[Table("Password", Schema = "Person")]
public partial class Password
{
    [Key]
    public int BusinessEntityID { get; set; }

    /// <summary>
    /// Password for the e-mail account.
    /// </summary>
    [Required]
    [StringLength(128)]
    [Unicode(false)]
    public string PasswordHash { get; set; }

    /// <summary>
    /// Random value concatenated with the password string before the password is hashed.
    /// </summary>
    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string PasswordSalt { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("BusinessEntityID")]
    [InverseProperty("Password")]
    public virtual Person BusinessEntity { get; set; }
}
