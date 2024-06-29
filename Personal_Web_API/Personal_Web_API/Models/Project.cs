using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public string ProjectUrl { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int ProjectUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User ProjectUser { get; set; } = null!;
}
