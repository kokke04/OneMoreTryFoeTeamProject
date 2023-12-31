﻿using System;
using System.Collections.Generic;

namespace OneMoreTryFoeTeamProject.Models;

public partial class EshopProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? AvailableStock { get; set; }

    public int? Deleted { get; set; }

    public virtual ICollection<ExamVoucher> ExamVouchers { get; set; } = new List<ExamVoucher>();
}
