using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

[Keyless]
public partial class vStateProvinceCountryRegion
{
    public int StateProvinceID { get; set; }

    [Required]
    [StringLength(3)]
    public string StateProvinceCode { get; set; }

    public bool IsOnlyStateProvinceFlag { get; set; }

    [Required]
    [StringLength(50)]
    public string StateProvinceName { get; set; }

    public int TerritoryID { get; set; }

    [Required]
    [StringLength(3)]
    public string CountryRegionCode { get; set; }

    [Required]
    [StringLength(50)]
    public string CountryRegionName { get; set; }
}
