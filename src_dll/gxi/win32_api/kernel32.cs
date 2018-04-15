/* 
 * KERNEL32
 * =====================================================================
 * FileName: kernel32.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Runtime.InteropServices;

namespace Troya.GXI
{
    internal static class KERNEL32
    {
        const string LIBRARY = "kernel32.dll";

        [DllImport( LIBRARY )]
        public static extern bool QueryPerformanceFrequency( ref long perfFreq );
        [DllImport( LIBRARY )]
        public static extern bool QueryPerformanceCounter( ref long perfCount );
        [DllImport( LIBRARY )]
        public static extern int GetTickCount( );
    }
}