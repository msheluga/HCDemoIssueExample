using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

[Keyless]
public partial class vProductAndDescription
{
    public int ProductID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductModel { get; set; }

    [Required]
    [StringLength(6)]
    public string CultureID { get; set; }

    [Required]
    [StringLength(400)]
    public string Description { get; set; }
}
