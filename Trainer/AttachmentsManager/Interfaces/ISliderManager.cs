using Attachments.Core.Models;
using Shared.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attachments.Core.Interfaces
{
    public interface ISliderManager<T> where T : IImageBase
    {
        bool Add(SliderDto dto);
        bool Update(SliderDto dto);
        bool Delete(SliderDto dto);
        string GetProfilePicturePath(SliderDto dto, string oldPath=null);
    }
}
