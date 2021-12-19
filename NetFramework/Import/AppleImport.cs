using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetFramework.Import
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AppleImport
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string Name;
        [MarshalAs(UnmanagedType.I4)]
        public int Amount;
        [MarshalAs(UnmanagedType.R8)]
        public double Price;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string Color;
        [MarshalAs(UnmanagedType.I4)]
        public int Seed;
        [MarshalAs(UnmanagedType.I4)]
        public int Trees;

    }
}
