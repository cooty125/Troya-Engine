/* 
 * TroyaToolBar
 * =====================================================================
 * FileName: toolbar.cs
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
    public class TroyaToolBar : ToolStrip
    {
        public TroyaToolBar( ) {
            base.SetStyle( ControlStyles.UserPaint, true );
            base.Margin = new Padding( 0, 0, 0, 0 );
            base.Padding = new Padding( 0, 0, 0, 0 );

            this.BackColor = ColorTheme.BackgroundColor;
            this.ForeColor = ColorTheme.FontColor;

            this.GripStyle = ToolStripGripStyle.Hidden;

            this.Renderer = new VixenToolStripRenderer( );
        }
    }
}