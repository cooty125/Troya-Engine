/* 
 * GDI32
 * =====================================================================
 * FileName: gdi32.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Runtime.InteropServices;

namespace Troya.GXI
{
    internal static class GDI32
    {
        const string LIBRARY = "gdi32.dll";

        [DllImport( LIBRARY, SetLastError = true )]
        public unsafe static extern int ChoosePixelFormat( IntPtr hDC, [In, MarshalAs( UnmanagedType.LPStruct )] PIXELFORMATDESCRIPTOR ppfd );
        [DllImport( LIBRARY, SetLastError = true )]
        public unsafe static extern int SetPixelFormat( IntPtr hDC, int iPixelFormat, [In, MarshalAs( UnmanagedType.LPStruct )] PIXELFORMATDESCRIPTOR ppfd );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr GetStockObject( uint fnObject );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern int SwapBuffers( IntPtr hDC );

        [StructLayout( LayoutKind.Explicit )]
        public class PIXELFORMATDESCRIPTOR
        {
            [FieldOffset( 0 )]
            public uint nSize;
            [FieldOffset( 2 )]
            public uint nVersion;
            [FieldOffset( 4 )]
            public uint dwFlags;
            [FieldOffset( 8 )]
            public byte iPixelType;
            [FieldOffset( 9 )]
            public byte cColorBits;
            [FieldOffset( 10 )]
            public byte cRedBits;
            [FieldOffset( 11 )]
            public byte cRedShift;
            [FieldOffset( 12 )]
            public byte cGreenBits;
            [FieldOffset( 13 )]
            public byte cGreenShift;
            [FieldOffset( 14 )]
            public byte cBlueBits;
            [FieldOffset( 15 )]
            public byte cBlueShift;
            [FieldOffset( 16 )]
            public byte cAlphaBits;
            [FieldOffset( 17 )]
            public byte cAlphaShift;
            [FieldOffset( 18 )]
            public byte cAccumBits;
            [FieldOffset( 19 )]
            public byte cAccumRedBits;
            [FieldOffset( 20 )]
            public byte cAccumGreenBits;
            [FieldOffset( 21 )]
            public byte cAccumBlueBits;
            [FieldOffset( 22 )]
            public byte cAccumAlphaBits;
            [FieldOffset( 23 )]
            public byte cDepthBits;
            [FieldOffset( 24 )]
            public byte cStencilBits;
            [FieldOffset( 25 )]
            public byte cAuxBuffers;
            [FieldOffset( 26 )]
            public sbyte iLayerType;
            [FieldOffset( 27 )]
            public byte bReserved;
            [FieldOffset( 28 )]
            public uint dwLayerMask;
            [FieldOffset( 32 )]
            public uint dwVisibleMask;
            [FieldOffset( 36 )]
            public uint dwDamageMask;
        }
    }
}