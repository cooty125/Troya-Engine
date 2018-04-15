/* 
 * DirectX3DWindow
 * =====================================================================
 * FileName: d3dx_window.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Troya.GXI
{
    public abstract class DirectX3DWindow : IDisposable
    {
        const string WND_CLASSNAME          = "Troya_GXI_Win32_D3D_Window";

        IntPtr wHandle                      = IntPtr.Zero;
        IntPtr hInstance                    = IntPtr.Zero;
        USER32.WndProc windowEvents         = null;
        bool wActive                        = true;
        bool wCursorVisible                 = true;

        int wWidth                          = 800;
        int wHeight                         = 600;
        string wTitle                       = string.Empty;
        int sWidth                          = 1024;
        int sHeight                         = 768;

        ServiceContainer services;
        GraphicsDevice gDevice              = null;
        ContentManager content              = null;
        PresentationParameters pParams      = null;

        uint maxFPS                         = 200;
        bool canUpdate                      = true;
        long ticksPerSecond                 = 0;
        long ticksPerFrame                  = 0;
        long newTime                        = 0;
        long oldTime                        = 0;
        float elapsedTime                   = 0f;

        GraphicsAdapter gAdapter            = GraphicsAdapter.DefaultAdapter;
        int multiSampling                   = 2;


        public IntPtr Handle {
            get { return this.wHandle; }
        }

        public int Width {
            get { return this.wWidth; }
        }
        public int Height {
            get { return this.wHeight; }
        }
        public Point Location {
            get {
                USER32.Rect rect = new USER32.Rect( );
                USER32.GetWindowRect( this.wHandle, ref rect );

                return new Point( rect.Left, rect.Right );
            }
        }
        public int MultiSamplingCount {
            get { return this.multiSampling; }
            set { this.multiSampling = value; }
        }
        public bool IsDeviceReady {
            get { return ( this.gDevice.GraphicsDeviceStatus != GraphicsDeviceStatus.Lost ); }
        }
        public bool IsCursorVisible {
            get { return this.wCursorVisible; }
            set {
                this.wCursorVisible = value;

                if ( value ) {
                    USER32.ShowCursor( USER32.SW_SHOWCURSOR );
                } else {
                    USER32.ShowCursor( USER32.SW_HIDECURSOR );
                }
            }
        }

        public ContentManager Content {
            get { return this.content; }
        }
        public GraphicsDevice Device {
            get { return this.gDevice; }
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


        public DirectX3DWindow( ) {
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
        ~DirectX3DWindow( ) {
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
        public void InitializeDirectX3D( ) {
            this.pParams = new PresentationParameters( );

            GraphicsDeviceService gDeviceService = GraphicsDeviceService.AddInstance( this.wHandle, this.wWidth, this.wHeight, this.multiSampling );
            this.services = new ServiceContainer( );
            this.services.AddService<IGraphicsDeviceService>( gDeviceService );

            this.gDevice = gDeviceService.GraphicsDevice;

            Viewport viewport = new Viewport( 0, 0, this.wWidth, this.wHeight );
            viewport.MinDepth = 0f;
            viewport.MaxDepth = 1f;

            this.gDevice.Viewport = viewport;
            this.content = new ContentManager( this.services, @"content" );

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
                        switch ( this.gDevice.GraphicsDeviceStatus ) {
                            case GraphicsDeviceStatus.NotReset:
                                this.gDevice.Reset( );
                                break;

                            case GraphicsDeviceStatus.Lost:
                                throw new InvalidOperationException( "Graphics device instance lost." );
                        }

                        this.gDevice.Clear( Microsoft.Xna.Framework.Color.Black );
                        this.gDevice.RasterizerState = RasterizerState.CullClockwise;
                        this.gDevice.DepthStencilState = DepthStencilState.Default;

                        this.Draw( );
                        this.gDevice.Present( );

                        this.oldTime += this.ticksPerFrame;

                        if ( this.oldTime < this.newTime ) {
                            this.oldTime = ( this.newTime + this.ticksPerFrame );
                        }

                        this.canUpdate = true;
                    }
                }
            }
        }
        public void FullScreenMode( ) {
            this.checkDeviceInitialization( );

            USER32.SetWindowPos(
                this.wHandle,
                IntPtr.Zero,
                ( this.sWidth / 2 - this.wWidth / 2 ),
                ( this.sHeight / 2 - this.wHeight / 2 ),
                this.sWidth,
                this.sHeight, USER32.SW_SHOWDEFAULT );

            this.pParams.BackBufferWidth = this.sWidth;
            this.pParams.BackBufferHeight = this.sHeight; 
            this.pParams.IsFullScreen = true;

            if ( this.IsDeviceReady ) {
                this.gDevice.Reset( this.pParams, this.gAdapter );
            }
        }
        public void WindowedMode( ) {
            this.checkDeviceInitialization( );

            USER32.SetWindowPos(
                this.wHandle,
                IntPtr.Zero,
                ( this.sWidth / 2 - this.wWidth / 2 ),
                ( this.sHeight / 2 - this.wHeight / 2 ),
                this.wWidth,
                this.wHeight,
                USER32.SW_SHOWDEFAULT );

            this.pParams.BackBufferWidth = this.wWidth;
            this.pParams.BackBufferHeight = this.wHeight;
            this.pParams.IsFullScreen = false;

            if ( this.IsDeviceReady ) {
                this.gDevice.Reset( this.pParams, this.gAdapter );
            }
        }
        public void Dispose( ) {
            this.wHandle = IntPtr.Zero;
            this.windowEvents = null;
            this.gDevice.Dispose( );

            GC.SuppressFinalize( this );
        }


        IntPtr WndEvents( IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam ) {
            switch ( msg ) {
                case USER32.WM_ACTIVATEAPP:
                    this.wActive = ( wParam != IntPtr.Zero );
                    return IntPtr.Zero;

                case USER32.WM_CLOSE:
                    USER32.DestroyWindow( this.wHandle );
                    return IntPtr.Zero;

                case USER32.WM_DESTROY:
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
                USER32.WS_OVERLAPPED | USER32.WS_CAPTION | USER32.WS_VISIBLE | wStyle,
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
        void checkDeviceInitialization( ) {
            if ( this.pParams == null || this.gDevice == null ) {
                throw new InvalidOperationException( "[DirectX3DWindow.GraphicsDevice] Device is not initialized yet. Please call InitializeDirectX3D9( ); method first." );
            }
        }
    }
}