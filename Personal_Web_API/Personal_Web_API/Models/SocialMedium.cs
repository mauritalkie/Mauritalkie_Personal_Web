using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class SocialMedium
{
    public int Id { get; set; }

    public string SocialMediaName { get; set; } = null!;

    public string SocialMediaUrl { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int SocialMediaUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User SocialMediaUser { get; set; } = null!;
}
