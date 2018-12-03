using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Models.Base
{
    public interface IImageBase
    {
        int Id { get; set; }
        string Path { get; set; }
        string Title { get; set; }
        string Text { get; set; }
    }
}
