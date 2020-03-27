using System;
using System.Collections.Generic;
using System.Text;

namespace WalkOut.Common
{
    internal static class CommonMethods
    {
        internal static string DateToString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}
