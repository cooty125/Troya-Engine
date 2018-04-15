/* 
 * WndBuild
 * =====================================================================
 * FileName: wnd_build.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Windows.Forms;
using Troya.Tools.Properties;

namespace Troya.Tools
{
    public partial class WndBuild : Form
    {
        public event EventHandler BuildStart = null;

        public WndBuild( ) {
            this.InitializeComponent( );

            this.guiFonts.Checked = Settings.Default.buildFonts;
            this.guiModels.Checked = Settings.Default.buildModels;
            this.guiTextures.Checked = Settings.Default.buildTextures;
            this.guiShaders.Checked = Settings.Default.buildShaders;
            this.guiSounds.Checked = Settings.Default.buildSounds;
        }

        private void btnOK_Click( object sender, EventArgs e ) {
            if ( this.BuildStart != null ) {
                this.Hide( );

                this.saveSettings( );
                this.BuildStart( this, EventArgs.Empty );
            }

            this.Close( );
        }

        private void btnClose_Click( object sender, EventArgs e ) {
            this.Close( );
        }

        private void WndBuild_FormClosing( object sender, FormClosingEventArgs e ) {
            this.saveSettings( );
        }

        void saveSettings( ) {
            Settings.Default.buildFonts = this.guiFonts.Checked;
            Settings.Default.buildModels = this.guiModels.Checked;
            Settings.Default.buildTextures = this.guiTextures.Checked;
            Settings.Default.buildShaders = this.guiShaders.Checked;
            Settings.Default.buildSounds = this.guiSounds.Checked;

            Settings.Default.Save( );
        }
    }
}