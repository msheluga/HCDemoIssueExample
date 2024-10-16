﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

[Keyless]
public partial class vStoreWithAddress
{
    public int BusinessEntityID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string AddressType { get; set; }

    [Required]
    [StringLength(60)]
    public string AddressLine1 { get; set; }

    [StringLength(60)]
    public string AddressLine2 { get; set; }

    [Required]
    [StringLength(30)]
    public string City { get; set; }

    [Required]
    [StringLength(50)]
    public string StateProvinceName { get; set; }

    [Required]
    [StringLength(15)]
    public string PostalCode { get; set; }

    [Required]
    [StringLength(50)]
    public string CountryRegionName { get; set; }
}
