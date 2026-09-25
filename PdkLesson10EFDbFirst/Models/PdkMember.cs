using System;
using System.Collections.Generic;

namespace PdkLesson10EFDbFirst.Models;

public partial class PdkMember
{
    public long Id { get; set; }

    public string? PdkUserName { get; set; }

    public string? PdkPassword { get; set; }

    public string? PdkFullName { get; set; }

    public string? PdkEmail { get; set; }

    public string? PdkPhone { get; set; }

    public bool? PdkStatus { get; set; }
}
