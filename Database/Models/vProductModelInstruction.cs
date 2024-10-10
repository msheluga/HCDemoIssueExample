﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

[Keyless]
public partial class vProductModelInstruction
{
    public int ProductModelID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public string Instructions { get; set; }

    public int? LocationID { get; set; }

    [Column(TypeName = "decimal(9, 4)")]
    public decimal? SetupHours { get; set; }

    [Column(TypeName = "decimal(9, 4)")]
    public decimal? MachineHours { get; set; }

    [Column(TypeName = "decimal(9, 4)")]
    public decimal? LaborHours { get; set; }

    public int? LotSize { get; set; }

    [StringLength(1024)]
    public string Step { get; set; }

    public Guid rowguid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
