using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserPictureUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AboutMe> AboutMes { get; set; } = new List<AboutMe>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<FutureProject> FutureProjects { get; set; } = new List<FutureProject>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<SocialMedium> SocialMedia { get; set; } = new List<SocialMedium>();
}
