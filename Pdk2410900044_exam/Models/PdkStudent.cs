using System;
using System.Collections.Generic;

namespace Pdk2410900044_exam.Models;

public partial class PdkStudent
{
    public int Id { get; set; }

    public string PdkName { get; set; } = null!;

    public bool PdkGender { get; set; }

    public DateOnly PdkBirthDay { get; set; }

    public string? PdkEmail { get; set; }

    public string? PdkPhone { get; set; }

    public bool PdkActive { get; set; }
}
