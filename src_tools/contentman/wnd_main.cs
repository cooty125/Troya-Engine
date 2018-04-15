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
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Troya.Tools.Properties;

namespace Troya.Tools
{
    public partial class WndMain : Form
    {
        Project project;

        public WndMain( string fileName, bool open = false ) {
            this.InitializeComponent( );

            this.guiToolsXNB.Text = Settings.Default.toolsXNB;
            this.guiToolsSHA.Text = Settings.Default.toolsSHA;

            this.project = new Project( );

            if ( open ) {
                this.project.Open( fileName );
                this.guiContentDir.Text = this.project.ContentDirectory;
                this.guiMenuSave.Enabled = true;
                this.updateItems( );
            } else {
                this.project.ContentDirectory = this.guiContentDir.Text;
            }
        }

        private void WndMain_FormClosing( object sender, FormClosingEventArgs e ) {
            Settings.Default.toolsXNB = this.guiToolsXNB.Text;
            Settings.Default.toolsSHA = this.guiToolsSHA.Text;
            Settings.Default.Save( );
        }

        private void btnBrowse_Click( object sender, EventArgs e ) {
            FolderBrowserDialog fbd = new FolderBrowserDialog( );
            fbd.Description = "Please select content directory.";

            if ( fbd.ShowDialog( ) == DialogResult.OK ) {
                this.guiContentDir.Text = fbd.SelectedPath;
            }
        }

        private void btnBrowseXNB_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Title = "Open XNB tool...";
            ofd.Filter = "XNB Tool (xnb.exe)|xnb.exe";

            if ( ofd.ShowDialog( ) == DialogResult.OK ) {
                this.guiToolsXNB.Text = ofd.FileName;
            }
        }

        private void btnBrowseSHA_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Title = "Open SHA tool...";
            ofd.Filter = "SHA Tool (sha.exe)|sha.exe";

            if ( ofd.ShowDialog( ) == DialogResult.OK ) {
                this.guiToolsSHA.Text = ofd.FileName;
            }
        }

        private void btnItemAdd_Click( object sender, EventArgs e ) {
            WndAdd wndAdd = new WndAdd( );
            wndAdd.AddItem += this.wndAdd_AddItem;

            if ( !wndAdd.IsDisposed ) {
                wndAdd.ShowDialog( );
            }
        }
        private void wndAdd_AddItem( object sender, ProjectItem e ) {
            if ( this.project.AddItem( e ) ) {
                this.updateItems( );
            } else {
                MessageBox.Show( "Item is already in the list.\r\nRemove this item first, or change type of file.", "Add item", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnItemRemove_Click( object sender, EventArgs e ) {
            if ( this.project.RemoveItem( this.guiGrid.SelectedRows[ 0 ].Index ) ) {
                this.updateItems( );
            }
        }

        private void guiMenuExit_Click( object sender, EventArgs e ) {
            this.Close( );
        }

        private void guiMenuOpen_Click( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Title = "Open content project.";
            ofd.Filter = "Troya Content Project (*.conp)|*.conp";

            if ( ofd.ShowDialog( ) == DialogResult.OK ) {
                this.project.Open( ofd.FileName );
                this.updateItems( );
            }
        }

        private void guiMenuSave_Click( object sender, EventArgs e ) {
            this.project.ContentDirectory = this.guiContentDir.Text;
            this.project.Save( );
        }

        private void guiMenuSaveAs_Click( object sender, EventArgs e ) {
            SaveFileDialog sfd = new SaveFileDialog( );
            sfd.Title = "Save content project.";
            sfd.Filter = "Troya Content Project (*.conp)|*.conp";

            if ( sfd.ShowDialog( ) == DialogResult.OK ) {
                this.project.ContentDirectory = this.guiContentDir.Text;
                this.project.SaveAs( sfd.FileName );
                this.guiMenuSave.Enabled = true;
            }
        }

        private void guiMenuBuild_Click( object sender, EventArgs e ) {
            WndBuild wndBuild = new WndBuild( );
            wndBuild.BuildStart += this.wndBuild_BuildStart;

            if ( !wndBuild.IsDisposed ) {
                wndBuild.ShowDialog( );
            }
        }
        private void wndBuild_BuildStart( object sender, EventArgs e ) {
            int files = 0;

            foreach ( ProjectItem item in this.project.Items ) {
                if ( item.Build ) {
                    files++;
                }
            }

            if ( files > 0 ) {
                WndProcess wndProcess = new WndProcess( this.guiToolsXNB.Text, this.guiToolsSHA.Text );
                wndProcess.Show( );
                wndProcess.BuildProject( this.project );
            } else {
                MessageBox.Show( "Nothing to build.", "Build", MessageBoxButtons.OK, MessageBoxIcon.Stop );
            }
        }

        private void guiGrid_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e ) {
            ProjectItem item = this.project.Items[ this.guiGrid.SelectedRows[ 0 ].Index ];

            WndEdit wndEdit = new WndEdit( item );
            wndEdit.Apply += this.wndEdit_Apply;

            if ( !wndEdit.IsDisposed ) {
                wndEdit.ShowDialog( );
            }
        }
        private void wndEdit_Apply( object sender, ProjectItem e ) {
            this.project.UpdateItem( this.guiGrid.SelectedRows[ 0 ].Index, e );
            this.updateItems( );
        }



        void updateItems( ) {
            this.guiGrid.Rows.Clear( );

            foreach ( ProjectItem item in this.project.Items ) {
                string name = Path.GetFileName( item.FileAsset );
                this.guiGrid.Rows.Add( item.Build, item.FileContentType.ToString( ).ToUpper( ), name, item.Profile.ToString( ) );
            }

            if ( this.guiGrid.Rows.Count > 0 ) {
                this.guiMenuBuild.Enabled = true;
            } else {
                this.guiMenuBuild.Enabled = false;
            }
        }
    }
}