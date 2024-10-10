﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Models;

/// <summary>
/// Customer reviews of products they have purchased.
/// </summary>
[Table("ProductReview", Schema = "Production")]
[Index("ProductID", "ReviewerName", Name = "IX_ProductReview_ProductID_Name")]
public partial class ProductReview
{
    /// <summary>
    /// Primary key for ProductReview records.
    /// </summary>
    [Key]
    public int ProductReviewID { get; set; }

    /// <summary>
    /// Product identification number. Foreign key to Product.ProductID.
    /// </summary>
    public int ProductID { get; set; }

    /// <summary>
    /// Name of the reviewer.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string ReviewerName { get; set; }

    /// <summary>
    /// Date review was submitted.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ReviewDate { get; set; }

    /// <summary>
    /// Reviewer&apos;s e-mail address.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Product rating given by the reviewer. Scale is 1 to 5 with 5 as the highest rating.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Reviewer&apos;s comments
    /// </summary>
    [StringLength(3850)]
    public string Comments { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductID")]
    [InverseProperty("ProductReviews")]
    public virtual Product Product { get; set; }
}
