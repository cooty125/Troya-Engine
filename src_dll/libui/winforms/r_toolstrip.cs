/* 
 * VixenToolStripRenderer
 * =====================================================================
 * FileName: r_toolstrip.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2017 - All rights reserved.
 * =====================================================================
 */

using System.Drawing;
using System.Windows.Forms;
using Troya.GUI.Properties;

namespace Troya.GUI.WinForms
{
    public class VixenToolStripRenderer : ToolStripProfessionalRenderer
    {
        public VixenToolStripRenderer( ) : base( ) {
        }

        protected override void InitializeItem( ToolStripItem item ) {
            base.InitializeItem( item );

            if ( item is ToolStripMenuItem ) {
                item.BackColor = ColorTheme.BackgroundColor;
                item.ForeColor = ColorTheme.FontColor;

                foreach ( ToolStripItem child in ( ( ToolStripMenuItem )item ).DropDownItems ) {
                    child.BackColor = ColorTheme.BackgroundColor;
                    child.ForeColor = ColorTheme.FontColor;
                }
            }
        }
        protected override void OnRenderToolStripBackground( ToolStripRenderEventArgs e ) {
            Rectangle rect = new Rectangle( Point.Empty, e.ToolStrip.Size );
            e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.BackgroundColor ), rect );
        }
        protected override void OnRenderToolStripBorder( ToolStripRenderEventArgs e ) {
            Rectangle rect = new Rectangle( Point.Empty, e.ToolStrip.Size );

            if ( e.ToolStrip.Items.Count > 0 ) {
                ToolStripItem item = e.ToolStrip.Items[ 0 ];

                if ( item.IsOnDropDown ) {
                    e.Graphics.DrawRectangle( new Pen( ColorTheme.Brush( ColorTheme.DropDownItemColor ), 4 ), rect );
                }
            }
        }
        protected override void OnRenderMenuItemBackground( ToolStripItemRenderEventArgs e ) {
            ToolStripItem item = e.Item;
            Rectangle rect = new Rectangle( Point.Empty, item.Size );

            if ( item.IsOnDropDown ) {
                if ( item.Selected ) {
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.ItemSelectColor ), rect );
                } else {
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );
                }
            } else {
                if ( item.Selected && !item.Pressed ) {
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );
                } else if ( item.Pressed ) {
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );
                }
            }
        }
        protected override void OnRenderButtonBackground( ToolStripItemRenderEventArgs e ) {
            ToolStripButton item = ( ToolStripButton )e.Item;
            Rectangle rect = new Rectangle( Point.Empty, item.Size );
            Rectangle rectFrame = new Rectangle( Point.Empty, new Size( item.Width - 1, item.Height - 1 ) );

            if ( item.Checked ) {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );

                if ( item.Selected ) {
                    e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.ItemSelectColor ), rect );
                }

                e.Graphics.DrawRectangle( ColorTheme.Pen( ColorTheme.ThemeColor ), rectFrame );
            } 
            else if ( item.Selected ) {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.ItemSelectColor ), rect );
            } else {
                base.OnRenderMenuItemBackground( e );
            }

            if ( item.Pressed ) {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );
            } 
        }
        protected override void OnRenderSplitButtonBackground( ToolStripItemRenderEventArgs e ) {
            ToolStripSplitButton item = ( ToolStripSplitButton )e.Item;
            Rectangle rect = new Rectangle( Point.Empty, item.Size );

            if ( item.Selected ) {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.ItemSelectColor ), rect );
                e.Graphics.DrawImageUnscaled( Resources.splitbutton_arrow_down, 25, 8, 11, 11 );
            } else {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.BackgroundColor ), rect );
                e.Graphics.DrawImageUnscaled( Resources.splitbutton_arrow_down, 25, 8, 11, 11 );
            }

            if ( item.Pressed ) {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );
                e.Graphics.DrawImageUnscaled( Resources.splitbutton_arrow_up, 25, 8, 11, 11 );
            } 
        }
        protected override void OnRenderSeparator( ToolStripSeparatorRenderEventArgs e ) {
            Rectangle rect = new Rectangle( Point.Empty, e.Item.Size );

            int middleY = ( ( rect.Top + rect.Bottom ) / 2 + 1 );
            int middleX = ( ( rect.Left + rect.Right ) / 2 + 2 );

            if ( e.Item.IsOnDropDown ) {
                e.Item.AutoSize = false;
                e.Item.Size = new Size( e.Item.Size.Width, 3 );
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.DropDownItemColor ), rect );
                e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.SeparatorColor ), 30, middleY - 1, rect.Width, middleY - 1 );
            } else {
                e.Graphics.FillRectangle( ColorTheme.Brush( ColorTheme.BackgroundColor ), rect );
                e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.SeparatorColor ), middleX, 5, middleX, rect.Height - 5 );
                e.Graphics.DrawLine( ColorTheme.Pen( ColorTheme.SeparatorShadowColor ), middleX - 1, 5, middleX - 1, rect.Height - 5 );
            }
        }
    }
}