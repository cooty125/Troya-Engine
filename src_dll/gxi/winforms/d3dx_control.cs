/* 
 * DirectX3DControl.cs
 * =====================================================================
 * FileName: d3dx_control.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Color = Microsoft.Xna.Framework.Color;

namespace Troya.GXI.WinForms
{
    public abstract class DirectX3DControl : Control
    {
        GraphicsDeviceService gDeviceService;
        ServiceContainer services;
        ContentManager content;
        bool active = true;
        Stopwatch timer;
        int fps = 0;
        Color rColor = Color.Black;

        public GraphicsDevice GraphicsDevice {
            get { return this.gDeviceService.GraphicsDevice; }
        }
        public ServiceContainer Services {
            get { return this.services; }
        }
        public ContentManager Content {
            get { return this.content; }
        }
        public bool IsActive {
            get { return this.active; }
            set { this.active = value; }
        }
        public Color ResetColor {
            get { return this.rColor; }
            set {
                if ( value != null ) {
                    this.rColor = value;
                }
                else {
                    this.rColor = Color.Black;
                }
            }
        }
        public int FPS {
            get { return this.fps; }
        }

        protected abstract void Initialize( );
        protected abstract void Update( float eTime );
        protected abstract void Draw( );


        protected override void OnCreateControl( ) {
            if ( !this.DesignMode ) {
                this.gDeviceService = GraphicsDeviceService.AddInstance( this.Handle, this.ClientSize.Width, this.ClientSize.Height, 8 ); // msaa

                this.services = new ServiceContainer( );
                this.services.AddService<IGraphicsDeviceService>( this.gDeviceService );

                this.content = new ContentManager( this.services, @".\" );

                this.timer = Stopwatch.StartNew( );
                this.Initialize( );

                Application.Idle += delegate { this.Invalidate( ); };
            }

            base.OnCreateControl( );
        }
        protected override void OnPaint( PaintEventArgs e ) {
            if ( this.gDeviceService != null ) {
                float elapsedTime = ( float )this.timer.Elapsed.TotalSeconds;

                if ( this.active ) {
                    this.Update( elapsedTime );
                    this.timer.Restart( );
                }

                bool needReset = false;

                switch ( this.GraphicsDevice.GraphicsDeviceStatus ) {
                    case GraphicsDeviceStatus.Lost:
                        throw new InvalidOperationException( "Can't create graphics device instance!" );
                    case GraphicsDeviceStatus.NotReset:
                        needReset = true;
                        break;
                    default:
                        PresentationParameters pp = this.GraphicsDevice.PresentationParameters;
                        needReset = ( this.ClientSize.Width > pp.BackBufferWidth ) || ( this.ClientSize.Height > pp.BackBufferHeight );
                        break;
                }

                if ( needReset && this.active ) {
                    this.gDeviceService.Reset( );
                }

                this.GraphicsDevice.Clear( this.rColor );
                //this.GraphicsDevice.RasterizerState = RasterizerState.CullClockwise;
                //this.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

                this.Draw( );
                this.GraphicsDevice.Present( this.getPresentArea( ), null, this.Handle );
                this.fps = ( int )( 1f / elapsedTime );
            }
            else {
                StringFormat sFormat = new StringFormat( );
                sFormat.Alignment = System.Drawing.StringAlignment.Center;
                sFormat.LineAlignment = System.Drawing.StringAlignment.Center;

                Graphics g = this.CreateGraphics( );
                g.Clear( System.Drawing.Color.DarkGray );
                g.DrawString( "DirectX3D Control", this.Font, new SolidBrush( System.Drawing.Color.Black ), new System.Drawing.PointF( this.ClientSize.Width / 2.0f, this.ClientSize.Height / 2.0f ), sFormat );
            }

            base.OnPaint( e );
        }
        protected override void OnPaintBackground( PaintEventArgs e ) {
            //base.OnPaintBackground( e );
        }
        protected override void OnResize( EventArgs e ) {
            if ( !this.DesignMode && this.gDeviceService != null ) {
                int width = this.ClientSize.Width;
                int height = this.ClientSize.Height;
                //float asRatio = Math.Abs( width / height );

                //width = ( int )( height * asRatio );
                //height = ( int )( width / asRatio );

                this.gDeviceService.Resize( width, height );
            }

            base.OnResize( e );
        }
        protected override void Dispose( bool disposing ) {
            if ( this.gDeviceService != null ) {
                this.timer.Stop( );
                this.timer = null;

                this.services.RemoveService( this.gDeviceService );
                this.gDeviceService.Dispose( disposing );
                this.gDeviceService = null;

                //GC.Collect( );
                //GC.WaitForPendingFinalizers( );
                GC.SuppressFinalize( this );
            }

            base.Dispose( disposing );
        }


        Rectangle getPresentArea( ) {
            return new Rectangle( this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height );
        }
    }
}