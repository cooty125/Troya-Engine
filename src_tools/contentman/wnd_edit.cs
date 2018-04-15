/* 
 * WndEdit
 * =====================================================================
 * FileName: wnd_edit.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace Troya.Tools
{
    public partial class WndEdit : Form
    {
        ProjectItem item;

        public event EventHandler<ProjectItem> Apply = null;

        public WndEdit( ProjectItem item ) {
            this.InitializeComponent( );

            this.item = item;

            this.guiFileAsset.Text = Path.GetFileName( item.FileAsset );

            switch ( item.FileContentType ) {
                case ProjectItem.ContentType.Font:
                    this.guiFileType.SelectedIndex = 0;
                    break;
                case ProjectItem.ContentType.Model:
                    this.guiFileType.SelectedIndex = 1;
                    break;
                case ProjectItem.ContentType.StudioModel:
                    this.guiFileType.SelectedIndex = 2;
                    break;
                case ProjectItem.ContentType.GameModel:
                    this.guiFileType.SelectedIndex = 3;
                    break;
                case ProjectItem.ContentType.Texture:
                    this.guiFileType.SelectedIndex = 4;
                    break;
                case ProjectItem.ContentType.Shader:
                    this.guiFileType.SelectedIndex = 5;
                    break;
                case ProjectItem.ContentType.Sound:
                    this.guiFileType.SelectedIndex = 6;
                    break;
            }

            switch ( item.Profile ) {
                case ProjectItem.GDProfile.HiDef:
                    this.guiProfile.SelectedIndex = 0;
                    break;
                case ProjectItem.GDProfile.Reach:
                    this.guiProfile.SelectedIndex = 1;
                    break;
            }

            this.guiBuild.Checked = item.Build;
        }

        private void btnOK_Click( object sender, EventArgs e ) {
            this.item.Build = this.guiBuild.Checked;

            switch ( this.guiFileType.SelectedIndex ) {
                case 0:
                    this.item.FileContentType = ProjectItem.ContentType.Font;
                    break;
                case 1:
                    this.item.FileContentType = ProjectItem.ContentType.Model;
                    break;
                case 2:
                    this.item.FileContentType = ProjectItem.ContentType.StudioModel;
                    break;
                case 3:
                    this.item.FileContentType = ProjectItem.ContentType.GameModel;
                    break;
                case 4:
                    this.item.FileContentType = ProjectItem.ContentType.Texture;
                    break;
                case 5:
                    this.item.FileContentType = ProjectItem.ContentType.Shader;
                    break;
                case 6:
                    this.item.FileContentType = ProjectItem.ContentType.Sound;
                    break;
            }

            switch ( this.guiProfile.SelectedIndex ) {
                case 0:
                    this.item.Profile = ProjectItem.GDProfile.HiDef;
                    break;
                case 1:
                    this.item.Profile = ProjectItem.GDProfile.Reach;
                    break;
            }

            if ( this.Apply != null ) {
                this.Apply( this, this.item );
            }

            this.Close( );
        }

        private void btnClose_Click( object sender, EventArgs e ) {
            this.Close( );
        }
    }
}