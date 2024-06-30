using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class FutureProject
{
    public int Id { get; set; }

    public string ProjectDescription { get; set; } = null!;

    public int ProjectUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User ProjectUser { get; set; } = null!;
}
