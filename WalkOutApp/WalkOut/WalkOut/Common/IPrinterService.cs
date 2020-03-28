using System;
using System.Collections.Generic;
using System.Text;
using WalkOut.Models;

namespace WalkOut.Common
{
    public interface IPrinterService
    {
        void GeneratePDF(FormModel form);
    }
}
