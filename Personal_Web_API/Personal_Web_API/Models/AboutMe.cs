using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class AboutMe
{
    public int Id { get; set; }

    public string AboutMeDescription { get; set; } = null!;

    public int AboutMeUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User AboutMeUser { get; set; } = null!;
}
