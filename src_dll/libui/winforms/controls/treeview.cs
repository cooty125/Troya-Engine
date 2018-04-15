/* 
 * TroyaTreeView
 * =====================================================================
 * FileName: treeview.cs
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
    public class TroyaTreeView : TreeView
    {
        SolidBrush brFont;


        public TroyaTreeView( ) {
            base.SetStyle( ControlStyles.UserPaint, true );
            base.Margin = new Padding( 0, 0, 0, 0 );
            base.Padding = new Padding( 0, 0, 0, 0 );

            this.BackColor = ColorTheme.ControlBackgroundColor;
            this.ForeColor = ColorTheme.FontColor;
            
            this.brFont = new SolidBrush( ColorTheme.FontColor );
        }

        protected override void OnPaint( PaintEventArgs e ) {
            this.drawAllNodes( e, base.Nodes );
        }
        protected override void OnPaintBackground( PaintEventArgs pevent ) {
            base.OnPaintBackground( pevent );
        }


        void drawAllNodes( PaintEventArgs e, TreeNodeCollection nodes ) {
            foreach ( TreeNode node in nodes ) {
                if ( node.IsVisible ) {
                    Rectangle lineRect = new Rectangle( 0, node.Bounds.Y, base.Width, node.Bounds.Height );

                    if ( node.IsSelected ) {
                        e.Graphics.FillRectangle( new SolidBrush( ColorTheme.ItemSelectColor ), lineRect );
                    }

                    if ( node.GetNodeCount( false ) > 0 ) {
                        Rectangle plusMinusRect = new Rectangle( node.Bounds.X - 15, node.Bounds.Y + 3, 11, 11 );
                        if ( node.IsExpanded ) {
                            e.Graphics.Flush( );
                            e.Graphics.DrawImageUnscaledAndClipped( Resources.treeview_minus, plusMinusRect );
                        } else {
                            e.Graphics.DrawImageUnscaledAndClipped( Resources.treeview_plus, plusMinusRect );
                        }
                    }

                    if ( this.ImageList != null && node.ImageIndex > -1 ) {
                        Rectangle imageRect = new Rectangle( node.Bounds.X - 20, node.Bounds.Y, this.ImageList.ImageSize.Width, this.ImageList.ImageSize.Height );
                        e.Graphics.DrawImageUnscaledAndClipped( this.ImageList.Images[ node.ImageIndex ], imageRect );
                    }

                    e.Graphics.DrawString( node.Text, base.Parent.Font, this.brFont, node.Bounds.Location );
                }

                if ( node.GetNodeCount( false ) > 0 ) {
                    this.drawAllNodes( e, node.Nodes );
                }
            }
        }
    }
}