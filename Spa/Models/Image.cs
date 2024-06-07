using System;
using System.Collections.Generic;

namespace Spa.Models;

public partial class Image
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;

    public string? FileDescription { get; set; }

    public string FileExtension { get; set; } = null!;

    public long FileSizeInBytes { get; set; }

    public string FilePath { get; set; } = null!;
}
