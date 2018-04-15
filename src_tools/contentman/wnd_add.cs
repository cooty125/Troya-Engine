/* 
 * WndAdd
 * =====================================================================
 * FileName: wnd_add.cs
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
    public partial class WndAdd : Form
    {
        public event EventHandler<ProjectItem> AddItem = null;

        public WndAdd( ) {
            this.InitializeComponent( );

            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Title = "Open file...";
            ofd.Filter = "All supported files|*.jpg;*.jpeg;*.png;*.bmp;*.tga;*.gif;*.fbx;*.x;*.obj;*.wav;*.fx;*.spritefont";

            if ( ofd.ShowDialog( ) == DialogResult.OK ) {
                switch ( Path.GetExtension( ofd.FileName ).ToLower( ) ) {
                    case ".bmp":
                    case ".spritefont":
                        this.guiFileType.SelectedIndex = 0;
                        break;
                    case ".fbx":
                    case ".x":
                    case ".obj":
                        this.guiFileType.SelectedIndex = 1;
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".tga":
                    case ".gif":
                        this.guiFileType.SelectedIndex = 4;
                        break;
                    case ".fx":
                        this.guiFileType.SelectedIndex = 5;
                        break;
                    case ".wav":
                        this.guiFileType.SelectedIndex = 6;
                        break;
                }

                this.guiFileAsset.Text = ofd.FileName;
            } else {
                this.Close( );
            }
            this.guiProfile.SelectedIndex = 0;
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.Close( );
        }

        private void btnOK_Click( object sender, EventArgs e ) {
            if ( this.AddItem != null ) {

                ProjectItem.ContentType type = ProjectItem.ContentType.Font;
                switch ( this.guiFileType.SelectedItem.ToString( ).ToUpper( ) ) {
                    case "MODEL":
                        type = ProjectItem.ContentType.Model;
                        break;
                    case "STUDIOMODEL":
                        type = ProjectItem.ContentType.StudioModel;
                        break;
                    case "GAMEMODEL":
                        type = ProjectItem.ContentType.GameModel;
                        break;
                    case "TEXTURE":
                        type = ProjectItem.ContentType.Texture;
                        break;
                    case "SHADER":
                        type = ProjectItem.ContentType.Shader;
                        break;
                    case "SOUND":
                        type = ProjectItem.ContentType.Sound;
                        break;
                    default:
                        type = ProjectItem.ContentType.Font;
                        break;
                }

                ProjectItem.GDProfile profile = ProjectItem.GDProfile.HiDef;
                switch ( this.guiProfile.SelectedItem.ToString( ).ToUpper( ) ) {
                    case "REACH":
                        profile = ProjectItem.GDProfile.Reach;
                        break;
                    default:
                        profile = ProjectItem.GDProfile.HiDef;
                        break;
                }

                this.AddItem( this, new ProjectItem( this.guiFileAsset.Text, type, this.guiBuild.Checked, profile ) );
            }

            this.Close( );
        }
    }
}