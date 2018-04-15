/* 
 * TroyaNumericUpDown
 * =====================================================================
 * FileName: numericupdown.cs
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
    public class TroyaNumericUpDown : NumericUpDown
    {
        public TroyaNumericUpDown( ) : base( ) {
            this.SetStyle( ControlStyles.UserPaint, true );
            this.Margin = new Padding( 0, 0, 0, 0 );
            this.BorderStyle = BorderStyle.None;

            this.BackColor = ColorTheme.BackgroundColor;
            this.ForeColor = ColorTheme.FontColor;
        }

        protected override void OnPaint( PaintEventArgs e ) {
            base.OnPaint( e );
        }
    }
}