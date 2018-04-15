/* 
 * USER32
 * =====================================================================
 * FileName: user32.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Troya.GXI
{
    internal static class USER32
    {
        const string LIBRARY = "user32.dll";

        public const uint WM_ACTIVATE = 0x0006;
        public const uint WM_ACTIVATEAPP = 0x001C;
        public const uint WM_CLEAR = 0x0303;
        public const uint WM_CLOSE = 0x0010;
        public const uint WM_COPY = 0x0301;
        public const uint WM_CREATE = 0x0001;
        public const uint WM_DESTROY = 0x0002;
        public const uint WM_ENABLE = 0x000A;
        public const uint WM_HOTKEY = 0x0312;
        public const uint WM_IME_CONTROL = 0x0283;
        public const uint WM_IME_KEYDOWN = 0x0290;
        public const uint WM_IME_KEYUP = 0x0291;
        public const uint WM_INPUT = 0x00FF;
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYUP = 0x0101;
        public const uint WM_LBUTTONDBCLK = 0x0203;
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint WM_LBUTTONUP = 0x0202;
        public const uint WM_MBUTTONDBCLK = 0x0209;
        public const uint WM_MBUTTONDOWN = 0x0207;
        public const uint WM_MBUTTONUP = 0x0208;
        public const uint WM_PAINT = 0x000F;
        public const uint WM_PASTE = 0x0302;
        public const uint WM_QUIT = 0x0012;
        public const uint WM_SIZE = 0x0005;
        public const uint WM_SIZING = 0x0214;
        public const uint WM_SYSKEYDOWN = 0x0104;
        public const uint WM_SYSKEYUP = 0x0105;
        public const uint WS_BORDER = 0x00800000;
        public const uint WS_CAPTION = 0x00C00000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_CHILDWINDOW = 0x40000000;
        public const uint WS_CLIPCHILDREN = 0x02000000;
        public const uint WS_CLIPSIBLINGS = 0x04000000;
        public const uint WS_DISABLED = 0x08000000;
        public const uint WS_DLGFRAME = 0x00400000;
        public const uint WS_GROUP = 0x00020000;
        public const uint WS_HSCROLL = 0x00100000;
        public const uint WS_ICONIC = 0x20000000;
        public const uint WS_MAXIMIZE = 0x01000000;
        public const uint WS_MAXIMIZEBOX = 0x00010000;
        public const uint WS_MINIMIZE = 0x2000000;
        public const uint WS_MINIMIZEBOX = 0x00020000;
        public const uint WS_OVERLAPPED = 0x00000000;
        public const uint WS_OVERLAPPEDWINDOW = ( WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX );
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_POPUPWINDOW = ( WS_POPUP | WS_BORDER | WS_SYSMENU );
        public const uint WS_SIZEBOX = 0x00040000;
        public const uint WS_SYSMENU = 0x00080000;
        public const uint WS_TABSTOP = 0x00010000;
        public const uint WS_THICKFRAME = 0x00040000;
        public const uint WS_TILED = 0x00000000;
        public const uint WS_TILEDWINDOW = ( WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX );
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_VSCROLL = 0x00200000;
        public const uint PM_NOREMOVE = 0x0000;
        public const uint PM_REMOVE = 0x0001;
        public const uint IDI_APPLICATION = 32512;
        public const uint IDI_ASTERISK = 32516;
        public const uint IDI_ERROR = 32513;
        public const uint IDI_EXCLAMATION = 32515;
        public const uint IDI_HAND = 32513;
        public const uint IDI_INFORMATION = 32516;
        public const uint IDI_QUESTION = 32514;
        public const uint IDI_SHIELD = 32518;
        public const uint IDI_WARNING = 32515;
        public const uint IDI_WINLOGO = 32517;
        public const uint IDC_APPSTARTING = 32650;
        public const uint IDC_ARROW = 32512;
        public const uint IDC_CROSS = 32515;
        public const uint IDC_HAND = 32649;
        public const uint IDC_HELP = 32651;
        public const uint IDC_IBEAM = 32513;
        public const uint IDC_ICON = 32641;
        public const uint IDC_NO = 32648;
        public const uint IDC_SIZE = 32640;
        public const uint IDC_SIZEALL = 32646;
        public const uint IDC_SIZENESW = 32643;
        public const uint IDC_SIZENS = 32645;
        public const uint IDC_SIZENWSE = 32642;
        public const uint IDC_SIZEWE = 32644;
        public const uint IDC_UPPARROW = 32516;
        public const uint IDC_WAIT = 32514;
        public const uint SW_FORCEMINIMIZE = 11;
        public const uint SW_HIDE = 0;
        public const uint SW_MAXIMIZE = 3;
        public const uint SW_MINIMIZE = 6;
        public const uint SW_RESTORE = 9;
        public const uint SW_SHOW = 5;
        public const uint SW_SHOWDEFAULT = 10;
        public const uint SW_SHOWMAXIMIZED = 3;
        public const uint SW_SHOWMINIMIZED = 2;
        public const uint SW_SHOWMINNOACTIVE = 7;
        public const uint SW_SHOWNA = 8;
        public const uint SW_SHOWNOACTIVATE = 4;
        public const uint SW_SHOWNORMAL = 1;
        public const uint SW_SHOWCURSOR = 1;
        public const uint SW_HIDECURSOR = 0;
        public const uint CS_BYTEALIGNCLIENT = 0x1000;
        public const uint CS_BYTEALIGNWINDOW = 0x2000;
        public const uint CS_CLASSDC = 0x0040;
        public const uint CS_DBLCLKS = 0x0008;
        public const uint CS_GLOBALCLASS = 0x4000;
        public const uint CS_HREDRAW = 0x0002;
        public const uint CS_NOCLOSE = 0x0200;
        public const uint CS_OWNDC = 0x0020;
        public const uint CS_PARENTDC = 0x0080;
        public const uint CS_SAVEBITS = 0x0800;
        public const uint CS_VREDRAW = 0x0001;
        public const uint SM_ARRANGE = 56;
        public const uint SM_SYSTEMDOCKED = 0x2004;
        public const uint SM_CYMIN = 29;
        public const uint SM_CXMIN = 28;
        public const uint SM_CXSCREEN = 0;
        public const uint SM_CYSCREEN = 1;
        public const uint SM_CXSIZE = 30;
        public const uint SM_CYSIZE = 31;
        public const uint SM_CXSIZEFRAME = 32;
        public const uint SM_CYSIZEFRAME = 33;
        public const uint SM_CXVIRTUALSCREEN = 78;
        public const uint SM_YVIRTUALSCREEN = 77;

        [DllImport( LIBRARY )]
        public static extern IntPtr LoadCursor( IntPtr hInstance, uint lpCursorName );
        [DllImport( LIBRARY )]
        public static extern IntPtr LoadIcon( IntPtr hInstance, uint lpIconName );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern short RegisterClassEx( ref WNDCLASSEX lpwcx );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr CreateWindowEx( uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam );
        [DllImport( LIBRARY )]
        public static extern IntPtr DefWindowProc( IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern bool AdjustWindowRect( ref Rectangle lpRect, uint dwStyle, bool bMenu );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern bool SetWindowPos( IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags );
        [DllImport( LIBRARY )]
        public static extern bool SetForegroundWindow( IntPtr hWnd );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr SetActiveWindow( IntPtr hWnd );
        [DllImport( LIBRARY )]
        public static extern int GetSystemMetrics( uint smIndex );
        [DllImport( LIBRARY )]
        public static extern bool ShowWindow( IntPtr hWnd, uint nCmdShow );
        [DllImport( LIBRARY )]
        public static extern bool DestroyWindow( IntPtr hWnd );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr GetDC( IntPtr hWnd );
        [DllImport( LIBRARY )]
        public static extern bool PeekMessage( out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg );
        [DllImport( LIBRARY )]
        public static extern sbyte GetMessage( out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax );
        [DllImport( LIBRARY )]
        public static extern bool TranslateMessage( ref MSG lpMsg );
        [DllImport( LIBRARY )]
        public static extern IntPtr DispatchMessage( ref MSG lpMsg );
        [DllImport( LIBRARY )]
        public static extern void PostQuitMessage( int nExitCode );
        [DllImport( LIBRARY )]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        [DllImport( LIBRARY )]
        public static extern int ShowCursor( uint nShow );

        public delegate IntPtr WndProc( IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam );

        [StructLayout( LayoutKind.Sequential )]
        public struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            [MarshalAs( UnmanagedType.FunctionPtr )]
            public WndProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        [StructLayout( LayoutKind.Sequential )]
        public struct MSG
        {
            public IntPtr hWnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point pt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
    }
}