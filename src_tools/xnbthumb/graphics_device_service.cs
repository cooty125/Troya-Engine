/* 
 * GraphicsDeviceService
 * =====================================================================
 * FileName: graphics_device_service.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace Troya.GXI
{
    class GraphicsDeviceService : IGraphicsDeviceService
    {
        static GraphicsDeviceService singletonInstance = null;
        static int numInstances = 0;

        GraphicsDevice gDevice = null;
        PresentationParameters pParams = null;

        public event EventHandler<EventArgs> DeviceCreated = null;
        public event EventHandler<EventArgs> DeviceDisposing = null;
        public event EventHandler<EventArgs> DeviceReset = null;
        public event EventHandler<EventArgs> DeviceResetting = null;


        public GraphicsDevice GraphicsDevice {
            get { return this.gDevice; }
        }

        GraphicsDeviceService( IntPtr wHandle, int vWidth, int vHeight, int msaa ) {
            this.pParams = new PresentationParameters( );
            this.pParams.BackBufferWidth = vWidth;
            this.pParams.BackBufferHeight = vHeight;
            this.pParams.IsFullScreen = false;
            this.pParams.MultiSampleCount = msaa;
            this.pParams.PresentationInterval = PresentInterval.Immediate;
            this.pParams.BackBufferFormat = SurfaceFormat.Color;
            this.pParams.DepthStencilFormat = DepthFormat.Depth24Stencil8;
            this.pParams.RenderTargetUsage = RenderTargetUsage.DiscardContents;
            this.pParams.DeviceWindowHandle = wHandle;
            

            this.gDevice = new GraphicsDevice( GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, this.pParams );
            
            if ( this.DeviceCreated != null ) {
                this.DeviceCreated( this, EventArgs.Empty );
            }
        }

        public static GraphicsDeviceService AddInstance( IntPtr handle, int width, int height, int msaa = 0 ) {
            if ( Interlocked.Increment( ref numInstances ) >= 1 ) {
                singletonInstance = new GraphicsDeviceService( handle, width, height, msaa );
            }

            return singletonInstance;
        }
        public void Reset( ) {
            if ( this.DeviceResetting != null ) {
                this.DeviceResetting( this, EventArgs.Empty );
            }

            this.gDevice.Reset( );

            if ( this.DeviceReset != null ) {
                this.DeviceReset( this, EventArgs.Empty );
            }
        }
        public void ChangeMultiSampleCount( int msaa ) {
            if ( this.DeviceResetting != null ) {
                this.DeviceResetting( this, EventArgs.Empty );
            }

            this.pParams.MultiSampleCount = msaa;
            this.gDevice.Reset( this.pParams );

            if ( this.DeviceReset != null ) {
                this.DeviceReset( this, EventArgs.Empty );
            }
        }
        public void Resize( int width, int height ) {
            if ( this.DeviceResetting != null ) {
                this.DeviceResetting( this, EventArgs.Empty );
            }

            this.pParams.BackBufferWidth = width;
            this.pParams.BackBufferHeight = height;

            this.gDevice.Reset( this.pParams );

            if ( this.DeviceReset != null ) {
                this.DeviceReset( this, EventArgs.Empty );
            }
        }
        public void Dispose( bool disposing ) {
            if ( Interlocked.Decrement( ref numInstances ) == 0 ) {
                if ( disposing ) {
                    if ( this.DeviceDisposing != null ) {
                        this.DeviceDisposing( this, EventArgs.Empty );
                    }

                    this.gDevice.Dispose( );
                }
                this.gDevice = null;
            }
        }
    }
}