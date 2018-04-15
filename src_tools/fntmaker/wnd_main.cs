/* 
 * WndMain
 * =====================================================================
 * FileName: wnd_main.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Troya.Tools
{
    public partial class WndMain : Form
    {
        Bitmap finalBmp;
        Graphics bmpGraphics;
        Font currentFont;
        string errorLogger = string.Empty;

        public WndMain( ) {
            this.InitializeComponent( );

            this.finalBmp = new Bitmap( 1, 1, PixelFormat.Format32bppArgb );
            this.bmpGraphics = Graphics.FromImage( this.finalBmp );
        }

        private void WndMain_Load( object sender, EventArgs e ) {
            foreach ( FontFamily font in FontFamily.Families ) {
                this.guiFontList.Items.Add( font.Name );
            }

            this.guiFontList.Text = "Consolas";
        }

        private void guiInstallFont_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Title = "Install new font...";
            ofd.DefaultExt = "ttf";
            ofd.Filter = "True Type Font (*.ttf)|*.ttf";

            if ( ofd.ShowDialog( ) == DialogResult.OK ) {
                Process.Start( ofd.FileName );
            }
        }
        private void btnExport_Click( object sender, EventArgs e ) {
            try {
                if ( this.errorLogger != null ) {
                    throw new ArgumentException( this.errorLogger );
                }

                int firstChar = 0x20;
                int lastChar = 0x7F;

                SaveFileDialog sfd = new SaveFileDialog( );
                sfd.Title = "Export font...";
                sfd.DefaultExt = "bmp";
                sfd.Filter = "Image files (*.bmp)|*.bmp";

                if ( sfd.ShowDialog( ) == DialogResult.OK ) {
                    List<Bitmap> bitmaps = new List<Bitmap>( );
                    List<int> xPositions = new List<int>( );
                    List<int> yPositions = new List<int>( );

                    try {
                        const int padding = 8;

                        int width = padding;
                        int height = padding;
                        int lineWidth = padding;
                        int lineHeight = padding;
                        int count = 0;

                        for ( char ch = ( char )firstChar; ch < lastChar; ch++ ) {
                            Bitmap bitmap = this.rasterizeChar( ch );
                            bitmaps.Add( bitmap );
                            xPositions.Add( lineWidth );
                            yPositions.Add( height );

                            lineWidth += bitmap.Width + padding;
                            lineHeight = Math.Max( lineHeight, bitmap.Height + padding );

                            if ( ( ++count == 16 ) || ( ch == lastChar - 1 ) ) {
                                width = Math.Max( width, lineWidth );
                                height += lineHeight;
                                lineWidth = padding;
                                lineHeight = padding;
                                count = 0;
                            }
                        }

                        using ( Bitmap bitmap = new Bitmap( width, height, PixelFormat.Format32bppArgb ) ) {
                            using ( Graphics graphics = Graphics.FromImage( bitmap ) ) {
                                graphics.Clear( Color.Magenta );
                                graphics.CompositingMode = CompositingMode.SourceCopy;

                                for ( int i = 0; i < bitmaps.Count; i++ ) {
                                    graphics.DrawImage( bitmaps[ i ], xPositions[ i ], yPositions[ i ] );
                                }

                                graphics.Flush( );
                            }

                            bitmap.Save( sfd.FileName, ImageFormat.Bmp );
                        }
                    } finally {
                        foreach ( Bitmap bitmap in bitmaps ) {
                            bitmap.Dispose( );
                        }

                        MessageBox.Show( "Saved to file: " + sfd.FileName, "Export", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
        private void btnClose_Click( object sender, EventArgs e ) {
            this.Close( );
        }

        private void guiFontList_SelectedIndexChanged( object sender, EventArgs e ) {
            this.fontSelectionChanged( );
        }
        private void guiFontStyle_SelectedIndexChanged( object sender, EventArgs e ) {
            this.fontSelectionChanged( );
        }
        private void guiFontSize_SelectedIndexChanged( object sender, EventArgs e ) {
            this.fontSelectionChanged( );
        }
        private void guiFontSize_TextUpdate( object sender, EventArgs e ) {
            this.fontSelectionChanged( );
        }

        void fontSelectionChanged( ) {
            try {
                float size = 0f;

                if ( !float.TryParse( this.guiFontSize.Text, out size ) || ( size <= 0 ) ) {
                    this.errorLogger = ( "Invalid font size '" + this.guiFontStyle.Text + "'" );
                    return;
                }

                FontStyle fStyle = FontStyle.Regular;

                try {
                    fStyle = ( FontStyle )Enum.Parse( typeof( FontStyle ), this.guiFontStyle.Text );
                } catch {
                    this.errorLogger = ( "Invalid font style '" + this.guiFontStyle.Text + "'" );
                    return;
                }

                Font newFont = new Font( this.guiFontList.Text, size, fStyle );

                if ( this.currentFont != null ) {
                    this.currentFont.Dispose( );
                }

                this.guiFontPreview.Font = this.currentFont = newFont;

                this.errorLogger = null;
            } catch ( Exception ex ) {
                this.errorLogger = ex.Message;
            }
        }
        static bool bitmapIsEmpty( Bitmap bitmap, int x ) {
            for ( int y = 0; y < bitmap.Height; y++ ) {
                if ( bitmap.GetPixel( x, y ).A != 0 )
                    return false;
            }

            return true;
        }
        static Bitmap cropCharacter( Bitmap bitmap ) {
            int cropLeft = 0;
            int cropRight = ( bitmap.Width - 1 );

            while ( ( cropLeft < cropRight ) && ( bitmapIsEmpty( bitmap, cropLeft ) ) ) {
                cropLeft++;
            }

            while ( ( cropRight > cropLeft ) && ( bitmapIsEmpty( bitmap, cropRight ) ) ) {
                cropRight--;
            }

            if ( cropLeft == cropRight ) {
                return bitmap;
            }

            cropLeft = Math.Max( cropLeft - 1, 0 );
            cropRight = Math.Min( cropRight + 1, bitmap.Width - 1 );

            int width = ( cropRight - cropLeft + 1 );

            Bitmap croppedBitmap = new Bitmap( width, bitmap.Height, bitmap.PixelFormat );

            using ( Graphics graphics = Graphics.FromImage( croppedBitmap ) ) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage( bitmap, 0, 0, new Rectangle( cropLeft, 0, width, bitmap.Height ), GraphicsUnit.Pixel );
                graphics.Flush( );
            }

            bitmap.Dispose( );

            return croppedBitmap;
        }
        Bitmap rasterizeChar( char ch ) {
            string character = ch.ToString( );

            SizeF size = this.bmpGraphics.MeasureString( character, this.currentFont );
            int width = ( int )Math.Ceiling( size.Width );
            int height = ( int )Math.Ceiling( size.Height );

            Bitmap bitmap = new Bitmap( width, height, PixelFormat.Format32bppArgb );

            using ( Graphics gfx = Graphics.FromImage( bitmap ) ) {
                if ( this.guiAntialias.Checked ) {
                    gfx.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                } else {
                    gfx.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                }

                gfx.Clear( Color.Transparent );

                using ( Brush brush = new SolidBrush( Color.White ) )
                using ( StringFormat format = new StringFormat( ) ) {
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Near;

                    gfx.DrawString( character, this.currentFont, brush, 0, 0, format );
                }

                gfx.Flush( );
            }

            return cropCharacter( bitmap );
        }
    }
}