/* 
 * OpenGLWindow
 * =====================================================================
 * FileName: gl_window.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Runtime.InteropServices;

namespace Troya.GXI
{
    public abstract class OpenGLWindow : IDisposable
    {
        const string WND_CLASSNAME          = "Troya_GXI_Win32_GLWindow";

        IntPtr wHandle                      = IntPtr.Zero;
        IntPtr hInstance                    = IntPtr.Zero;
        USER32.WndProc windowEvents         = null;
        bool wActive                        = true;    

        IntPtr dcHandle                     = IntPtr.Zero;
        IntPtr wglContext                   = IntPtr.Zero;

        int wWidth                          = 800;
        int wHeight                         = 600;
        string wTitle                       = string.Empty;
        int sWidth                          = 1024;
        int sHeight                         = 768;

        uint maxFPS                         = 200;
        bool canUpdate                      = true;
        long ticksPerSecond                 = 0;
        long ticksPerFrame                  = 0;
        long newTime                        = 0;
        long oldTime                        = 0;
        float elapsedTime                   = 0f;


        public IntPtr Handle {
            get { return this.wHandle; }
        }
        public int Width {
            get { return this.wWidth; }
        }
        public int Heigth {
            get { return this.wHeight; }
        }
        public double AspectRatio {
            get { return ( ( double )this.wWidth / ( double )this.wHeight ); }
        }
        public uint MaxFPS {
            get { return this.maxFPS; }
            set {
                if ( value > 0 ) {
                    this.maxFPS = value;
                }
            }
        }
        public float ElapsedTime {
            get { return this.elapsedTime; }
        }
        public int FPS {
            get { return ( int )( 1 / this.elapsedTime ); }
        }


        protected abstract void Initialize( );
        protected abstract void Update( float eTime );
        protected abstract void Draw( );


        public OpenGLWindow( ) {
            this.windowEvents = new USER32.WndProc( this.WndEvents );

            this.sWidth = USER32.GetSystemMetrics( USER32.SM_CXSCREEN );
            this.sHeight = USER32.GetSystemMetrics( USER32.SM_CYSCREEN );

            if ( KERNEL32.QueryPerformanceFrequency( ref ticksPerSecond ) ) {
                this.ticksPerFrame = ( this.ticksPerSecond / this.maxFPS );

                KERNEL32.QueryPerformanceCounter( ref oldTime );
            } else {
                throw new InvalidOperationException( "[KERNEL32.QueryPerformanceCounter] Your CPU hardware doesn't support QPF timer." );
            }
        }
        ~OpenGLWindow( ) {
            this.Dispose( );
        }

        public void Create( int width, int height, string title, WindowStyle style ) {
            this.wWidth = width;
            this.wHeight = height;
            this.wTitle = title;

            uint wStyle = 0;

            switch ( style ) {
                case WindowStyle.Default:
                    wStyle = ( USER32.WS_SYSMENU | USER32.WS_MINIMIZEBOX | USER32.WS_MAXIMIZEBOX );
                    break;
                case WindowStyle.NoSysMenu:
                    wStyle = 0x0;
                    break;
                case WindowStyle.NoMinimizeNoMaximize:
                    wStyle = USER32.WS_SYSMENU;
                    break;
                case WindowStyle.NoMaximize:
                    wStyle = ( USER32.WS_SYSMENU | USER32.WS_MINIMIZEBOX );
                    break;
                case WindowStyle.NoMinimize:
                    wStyle = ( USER32.WS_SYSMENU | USER32.WS_MAXIMIZEBOX );
                    break;
                case WindowStyle.Fullscreen:
                    wStyle = 0x0;
                    break;
            }

            this.registerClass( );
            this.createWindow( wStyle );

            USER32.ShowWindow( this.wHandle, USER32.SW_SHOWDEFAULT );
            USER32.SetForegroundWindow( this.wHandle );
        }
        public void InitializeOpenGL( ) {
            this.dcHandle = USER32.GetDC( this.wHandle );

            GDI32.PIXELFORMATDESCRIPTOR pfd = new GDI32.PIXELFORMATDESCRIPTOR( );
            pfd.nSize = ( ushort )Marshal.SizeOf( pfd );
            pfd.nVersion = 1;
            pfd.dwFlags = ( OPENGL32.PFD_DRAW_TO_WINDOW | OPENGL32.PFD_SUPPORT_OPENGL | OPENGL32.PFD_DOUBLEBUFFER );
            pfd.iPixelType = OPENGL32.PFD_TYPE_RGBA;
            pfd.cColorBits = 24;
            pfd.cDepthBits = 16;
            pfd.cStencilBits = 8;
            pfd.iLayerType = OPENGL32.PFD_MAIN_PLANE;

            int pixelFormat = GDI32.ChoosePixelFormat( this.dcHandle, pfd );
            GDI32.SetPixelFormat( this.dcHandle, pixelFormat, pfd );

            this.wglContext = OPENGL32.wglCreateContext( this.dcHandle );
            OPENGL32.wglMakeCurrent( this.dcHandle, this.wglContext );

            this.Initialize( );
        }
        public void Run( ) {
            USER32.MSG msg = new USER32.MSG( );
            USER32.PeekMessage( out msg, this.hInstance, 0, 0, USER32.PM_NOREMOVE );

            while ( msg.message != USER32.WM_QUIT ) {
                if ( USER32.PeekMessage( out msg, this.hInstance, 0, 0, USER32.PM_REMOVE ) ) {
                    USER32.TranslateMessage( ref msg );
                    USER32.DispatchMessage( ref msg );
                } else {
                    if ( this.canUpdate ) {
                        this.elapsedTime = ( float )( ( this.oldTime - this.newTime ) / ( float )this.ticksPerSecond );

                        this.Update( this.elapsedTime );
                        this.canUpdate = false;
                    }

                    KERNEL32.QueryPerformanceCounter( ref newTime );

                    if ( this.newTime > this.oldTime ) {
                        OPENGL32.glClearColor( 0, 0, 0, 0 );
                        OPENGL32.glClear( OPENGL32.GL_COLOR_BUFFER_BIT | OPENGL32.GL_DEPTH_BUFFER_BIT );
                        OPENGL32.glLoadIdentity( );

                        this.Draw( );

                        OPENGL32.glFlush( );
                        GDI32.SwapBuffers( this.dcHandle );

                        this.oldTime += this.ticksPerFrame;

                        if ( this.oldTime < this.newTime ) {
                            this.oldTime = ( this.newTime + this.ticksPerFrame );
                        }

                        this.canUpdate = true;
                    }
                }
            }
        }
        public void Dispose( ) {
            this.wHandle = IntPtr.Zero;
            this.windowEvents = null;

            GC.SuppressFinalize( this );
        }


        IntPtr WndEvents( IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam ) {
            switch ( msg ) {
                case USER32.WM_CREATE:
                    return IntPtr.Zero;

                case USER32.WM_ACTIVATEAPP:
                    this.wActive = ( wParam != IntPtr.Zero );
                    return IntPtr.Zero;

                case USER32.WM_CLOSE:
                    USER32.DestroyWindow( this.wHandle );
                    return IntPtr.Zero;

                case USER32.WM_DESTROY:
                    OPENGL32.wglMakeCurrent( this.dcHandle, IntPtr.Zero );
                    OPENGL32.wglDeleteContext( this.wglContext );
                    USER32.PostQuitMessage( 0 );
                    return IntPtr.Zero;

                default:
                    return USER32.DefWindowProc( hWnd, msg, wParam, lParam );
            }
        }
        void registerClass( ) {
            USER32.WNDCLASSEX wndClassEx = new USER32.WNDCLASSEX( );
            wndClassEx.cbClsExtra = 0;
            wndClassEx.cbWndExtra = 0;
            wndClassEx.cbSize = ( uint )Marshal.SizeOf( wndClassEx );
            wndClassEx.style = ( USER32.CS_VREDRAW | USER32.CS_HREDRAW );
            wndClassEx.hbrBackground = ( IntPtr )5;
            wndClassEx.hInstance = this.hInstance;
            wndClassEx.hCursor = USER32.LoadCursor( IntPtr.Zero, USER32.IDC_ARROW );
            wndClassEx.hIcon = USER32.LoadIcon( IntPtr.Zero, USER32.IDI_APPLICATION );
            wndClassEx.hIconSm = wndClassEx.hIcon;
            wndClassEx.lpszMenuName = null;
            wndClassEx.lpszClassName = WND_CLASSNAME;
            wndClassEx.lpfnWndProc = this.windowEvents;

            if ( USER32.RegisterClassEx( ref wndClassEx ) == 0 ) {
                throw new InvalidOperationException( "[USER32.RegisterClassEx] Can't register window class " + WND_CLASSNAME + "." );
            }
        }
        void createWindow( uint wStyle ) {
            this.wHandle = USER32.CreateWindowEx(
                0,
                WND_CLASSNAME,
                this.wTitle,
                USER32.WS_OVERLAPPED | USER32.WS_CAPTION | USER32.WS_SYSMENU | USER32.WS_MINIMIZEBOX | USER32.WS_VISIBLE,
                ( this.sWidth / 2 - this.wWidth / 2 ),
                ( this.sHeight / 2 - this.wHeight / 2 ),
                this.wWidth,
                this.wHeight,
                IntPtr.Zero,
                IntPtr.Zero,
                this.hInstance,
                IntPtr.Zero );

            if ( this.wHandle == IntPtr.Zero ) {
                throw new InvalidOperationException( "[USER32.CreateWindowEx] Can't create window handle." );
            }
        }
    }
}