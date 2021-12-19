using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetFramework.Import
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FruitImport
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string Name;
        [MarshalAs(UnmanagedType.I4)]
        public int Amount;
        [MarshalAs(UnmanagedType.R8)]
        public double Price;
    }

}
