using System;

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