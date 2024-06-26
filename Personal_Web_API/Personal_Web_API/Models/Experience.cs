﻿using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string ExperienceDescription { get; set; } = null!;

    public int ExperienceUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User ExperienceUser { get; set; } = null!;
}
