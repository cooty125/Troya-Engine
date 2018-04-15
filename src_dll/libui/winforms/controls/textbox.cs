/* 
 * TroyaTextBox
 * =====================================================================
 * FileName: textbox.cs
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
    public class TroyaTextBox : TextBox
    {
        public TroyaTextBox( ) {
            //base.Margin = new Padding( 0, 0, 0, 0 );
            base.Padding = new Padding( 0, 0, 0, 0 );
            this.BorderStyle = BorderStyle.FixedSingle;

            this.BackColor = ColorTheme.ItemSelectColor;
            this.ForeColor = ColorTheme.FontColor;
        }

        protected override void OnPaint( PaintEventArgs e ) {
            base.OnPaint( e );
        }
    }
}