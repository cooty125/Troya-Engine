/* 
 * TroyaButton
 * =====================================================================
 * FileName: button.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Troya.GUI.WinForms
{
    public class TroyaButton : Button
    {
        LinearGradientBrush background_i;
        LinearGradientBrush background_h;
        LinearGradientBrush background_p;

        bool pressed = false;
        bool hovering = false;


        public TroyaButton( ) : base( ) {
            this.SetStyle( ControlStyles.UserPaint, true );
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.BackColor = ColorTheme.BackgroundColor;
            this.ForeColor = ColorTheme.FontColor;

            this.computeGradients( );
        }

        protected override void OnPaint( PaintEventArgs e ) {
            Point center = new Point( 
                ( int )( this.Width - e.Graphics.MeasureString( this.Text, this.Font ).Width ) / 2, 
                ( int )( this.Height - this.Font.Height ) / 2 );

            if ( this.Enabled ) {
                if ( this.hovering ) {
                    e.Graphics.FillRectangle( this.background_h, e.ClipRectangle );
                } else {
                    e.Graphics.FillRectangle( this.background_i, e.ClipRectangle );
                }

                if ( this.pressed ) {
                    e.Graphics.FillRectangle( this.background_p, e.ClipRectangle );
                    e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.BackgroundColor ), new Rectangle( 1, 1, this.Width - 3, this.Height - 3 ) );
                } else {
                    e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.BackgroundColor ), new Rectangle( 1, 1, this.Width - 3, this.Height - 3 ) );
                }

                e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.ThemeColor ), new Rectangle( 0, 0, this.Width - 1, this.Height - 1 ) );
                e.Graphics.DrawString( this.Text, this.Font, ColorTheme.Brush( ColorTheme.FontColor ), center );
            } else {
                e.Graphics.FillRectangle( this.background_i, e.ClipRectangle );
                e.Graphics.DrawString( this.Text, this.Font, ColorTheme.Brush( ColorTheme.SeparatorShadowColor ), center );
            }

            if ( this.Image != null ) {
                e.Graphics.DrawImage( this.Image, new Point( center.X - this.Image.Width / 2, center.Y - 4 ) );
            }
        }
        protected override void OnResize( EventArgs e ) {
            base.OnResize( e );

            this.computeGradients( );
        }
        protected override void OnMouseEnter( EventArgs e ) {
            base.OnMouseEnter( e );

            this.hovering = true;
            this.Invalidate( );
        }
        protected override void OnMouseLeave( EventArgs e ) {
            base.OnMouseLeave( e );

            this.hovering = false;
            this.Invalidate( );
        }
        protected override void OnMouseDown( MouseEventArgs e ) {
            base.OnMouseDown( e );

            this.pressed = true;
            this.Invalidate( );
        }
        protected override void OnMouseUp( MouseEventArgs e ) {
            base.OnMouseUp( e );

            this.pressed = false;
            this.Invalidate( );
        }


        void computeGradients( ) {
            this.background_i = new LinearGradientBrush( new Point( 0, 0 ), new Point( 0, this.Height ), ColorTheme.ControlHeaderColor, ColorTheme.BackgroundColor );
            this.background_h = new LinearGradientBrush( new Point( 0, 0 ), new Point( 0, this.Height ), ColorTheme.ControlBackgroundColor, ColorTheme.ForegroundColor );
            this.background_p = new LinearGradientBrush( new Point( 0, 0 ), new Point( 0, this.Height ), ColorTheme.SeparatorShadowColor, ColorTheme.ForegroundColor );
        }
    }
}