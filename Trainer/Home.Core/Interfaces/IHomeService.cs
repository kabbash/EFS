using Home.Core.Models;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Core.Interfaces
{
    public interface IHomeService
    {
        ResultMessage ContactUs(ContactUsDto contactUsDto);
    }
}
