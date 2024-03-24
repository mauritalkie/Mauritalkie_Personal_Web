using System;
using System.Collections.Generic;

namespace Personal_Web_API.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
