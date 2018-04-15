/* 
 * TroyaListView
 * =====================================================================
 * FileName: listview.cs
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
    public class TroyaListView : ListView
    {
        bool scrolling = false;

        public TroyaListView( ) {
            base.SetStyle( ControlStyles.UserPaint, true );
            base.Margin = new Padding( 0, 0, 0, 0 );
            base.Padding = new Padding( 0, 0, 0, 0 );
            base.DoubleBuffered = true;
            base.View = View.Tile;

            this.ForeColor = ColorTheme.FontColor;
            this.BackColor = ColorTheme.BackgroundColor;
        }

        protected override void OnPaint( PaintEventArgs e ) {
            base.OnPaint( e );

            foreach ( ListViewItem item in this.Items ) {
                Rectangle itemRect = new Rectangle( item.Position.X + 1, item.Position.Y + 1, this.TileSize.Width - 2, this.TileSize.Height - 2 );
                Rectangle labelRect = new Rectangle( item.Position.X + 1, item.Position.Y + this.TileSize.Height - 21, this.TileSize.Width - 2, 20 );

                if ( this.LargeImageList != null ) {
                    if ( item.ImageIndex < this.LargeImageList.Images.Count && item.ImageIndex >= 0 ) {
                        e.Graphics.DrawImageUnscaledAndClipped( this.LargeImageList.Images[ item.ImageIndex ], itemRect );
                    }
                }

                if ( item.Selected ) {
                    e.Graphics.FillRectangle( ColorTheme.Brush( Color.FromArgb( 30, ColorTheme.ThemeColor.R, ColorTheme.ThemeColor.G, ColorTheme.ThemeColor.B ) ), itemRect );
                    e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.ThemeColor ), itemRect );
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.ThemeColor ), labelRect );
                    e.Graphics.DrawString( item.Text, this.Font, ColorTheme.Brush( ColorTheme.ControlBackgroundColor ), new PointF( item.Position.X + 5, labelRect.Y + 3 ) );
                } else {
                    e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.SeparatorShadowColor ), itemRect );
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.SeparatorShadowColor ), labelRect );
                    e.Graphics.DrawString( item.Text, this.Font, ColorTheme.Brush( ColorTheme.FontColor ), new PointF( item.Position.X + 5, labelRect.Y + 3 ) );
                }
            }
        }

        protected override void OnDrawItem( DrawListViewItemEventArgs e ) {
            e.DrawDefault = false;
        }

        protected override void OnPaintBackground( PaintEventArgs pevent ) {
            base.OnPaintBackground( pevent );

            pevent.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.BackgroundColor ), pevent.ClipRectangle );
        }

        protected override void WndProc( ref Message m ) {
            base.WndProc( ref m );

            if ( m.Msg == 0x115 ) {
                // scrolling
                this.scrolling = true;
            } else {
                if ( this.scrolling ) {
                    // scrolling end
                    //this.RedrawItems( 0, this.Items.Count - 1, false );
                    this.scrolling = false;
                }
            }
        }
    }
}