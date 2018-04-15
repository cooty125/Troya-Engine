/* 
 * TroyaCheckBox
 * =====================================================================
 * FileName: checkbox.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using Troya.GUI.Properties;

namespace Troya.GUI.WinForms
{
    public class TroyaCheckBox : CheckBox
    {
        bool hovering = false;
        Color disabledFrameColor = Color.FromArgb( 255, 70, 70, 70 );

        public TroyaCheckBox( ) {
            base.SetStyle( ControlStyles.UserPaint, true );
            base.Margin = new Padding( 0, 0, 0, 0 );
            base.Padding = new Padding( 0, 0, 0, 0 );

            this.ForeColor = ColorTheme.FontColor;
        }

        protected override void OnPaint( PaintEventArgs e ) {
            Rectangle frameRect = new Rectangle( 1, 1, 12, 12 );
            Rectangle borderRect = new Rectangle( 0, 0, 14, 14 );

            e.Graphics.FillRectangle( ColorTheme.Brush( this.BackColor ), e.ClipRectangle );
            e.Graphics.DrawString( this.Text, this.Font, ColorTheme.Brush( this.ForeColor ), new PointF( 20, 0 ) );

            if ( this.Enabled ) {
                if ( this.hovering ) {
                    e.Graphics.DrawRectangle( ColorTheme.Pen( Color.FromArgb( 255, ColorTheme.ThemeColor.R / 2, ColorTheme.ThemeColor.G / 2, ColorTheme.ThemeColor.B / 2 ) ), borderRect );
                } else {
                    e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.ThemeColor ), frameRect );
                }
            } else {
                e.Graphics.DrawRectangle( ColorTheme.Pen( disabledFrameColor ), frameRect );
            }

            if ( this.Checked ) {
                if ( this.Enabled ) {
                    e.Graphics.DrawImageUnscaledAndClipped( Resources.checkbox_checked, new Rectangle( 2, 2, 11, 11 ) );
                } else {
                    e.Graphics.DrawImageUnscaledAndClipped( Resources.checkbox_checked_disabled, new Rectangle( 2, 2, 11, 11 ) );
                }
            }
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
    }
}