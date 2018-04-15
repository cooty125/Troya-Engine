/* 
 * TroyaGroupBox
 * =====================================================================
 * FileName: groupbox.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Troya.GUI.WinForms
{
    public class TroyaGroupBox : GroupBox
    {
        public TroyaGroupBox( ) {
            base.SetStyle( ControlStyles.UserPaint, true );
            base.Margin = new Padding( 0, 0, 0, 0 );
            base.Padding = new Padding( 0, 0, 0, 0 );

            this.ForeColor = ColorTheme.FontColor;
        }

        protected override void OnPaint( PaintEventArgs e ) {
            Rectangle frameRect = new Rectangle( 1, 1, 12, 12 );
            Rectangle borderRect = new Rectangle( 0, 0, 14, 14 );

            SizeF textSize = e.Graphics.MeasureString( this.Text, this.Font );

            e.Graphics.FillRectangle( ColorTheme.Brush( this.BackColor ), e.ClipRectangle );
            e.Graphics.DrawString( this.Text, this.Font, ColorTheme.Brush( this.ForeColor ), new PointF( 6, 0 ) );

            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( 1, 8 ), new Point( 5, 8 ) );
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( ( int )textSize.Width + 7, 8 ), new Point( this.Width - 2, 8 ) );
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( 0, 9 ), new Point( 0, this.Height - 2 ) );
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( 1, this.Height - 1 ), new Point( this.Width - 2, this.Height - 1 ) );
            e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.ThemeColor ), new Point( this.Width - 1, 9 ), new Point( this.Width - 1, this.Height - 2 ) );
        }
    }
}