/* 
 * ColorTheme
 * =====================================================================
 * FileName: color_theme.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Troya.GUI
{
    public static class ColorTheme
    {
        public static Color BackgroundColor         = Color.FromArgb( 255, 150, 150, 150 );
        public static Color ForegroundColor         = Color.FromArgb( 255, 135, 135, 135 );
        public static Color FontColor               = Color.FromArgb( 255, 40, 40, 40 );
        public static Color DropDownItemColor       = Color.FromArgb( 255, 180, 180, 180 );
        public static Color ItemSelectColor         = Color.FromArgb( 255, 220, 220, 220 );
        public static Color ControlHeaderColor      = Color.FromArgb( 255, 190, 190, 190 );
        public static Color ControlBackgroundColor  = Color.FromArgb( 255, 170, 170, 170 );
        public static Color SeparatorColor          = Color.FromArgb( 255, 140, 140, 140 );
        public static Color SeparatorShadowColor    = Color.FromArgb( 255, 110, 110, 110 );
        public static Color ThemeColor              = Color.FromArgb( 255, 10, 100, 100 );
        public static Color DialogTitleFontColor    = Color.FromArgb( 255, 210, 210, 210 );
        public static Color DialogBackgroundColor   = Color.FromArgb( 255, 185, 185, 185 );
        public static Color TransparentColor        = Color.FromArgb( 0, 0, 0, 0 );

        public static Color ErrorColor              = Color.FromArgb( 255, 100, 0, 0 );
        public static Color SuccessColor            = Color.FromArgb( 255, 0, 100, 0 );
        public static Color InfoColor               = Color.FromArgb( 255, 30, 75, 110 );
        public static Color WarningColor            = Color.FromArgb( 255, 170, 100, 0 );

        public static LinearGradientBrush GradientBrush( Point start, Point end, Color from, Color to ) {
            return new LinearGradientBrush( start, end, from, to );
        }
        public static SolidBrush Brush( Color color ) {
            return new SolidBrush( color );
        }
        public static Pen Pen( Color color, float width = 1f ) {
            return new Pen( color, width );
        }
    }
}