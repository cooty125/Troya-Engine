/* 
 * WndProcess
 * =====================================================================
 * FileName: wnd_process.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using Troya.Tools.Properties;

namespace Troya.Tools
{
    public partial class WndProcess : Form
    {
        string xnb = @".\xnb.exe";
        string sha = @".\sha.exe";
        int filesToBuild = 0;
        int filesBuilt = 0;
        int errors = 0;

        public WndProcess( string xnbPath, string shaPath ) {
            this.InitializeComponent( );

            this.xnb = xnbPath;
            this.sha = shaPath;
        }

        private void btnCancel_Click( object sender, EventArgs e ) {
            this.Close( );
        }

        public void BuildProject( Project project ) {
            this.filesBuilt = 0;
            this.errors = 0;
            this.guiOutput.Items.Clear( );
            
            ProjectItem[ ] items = this.getItemsToBuild( project );
            this.filesToBuild = items.Length;
            this.guiProgress.Maximum = this.filesToBuild;

            foreach ( ProjectItem item in items ) {
                this.buildItem( item );
            }

            if ( this.filesBuilt == this.filesToBuild ) {
                MessageBox.Show( "Build completed with " + this.errors.ToString( ) + " errors.", "Build", MessageBoxButtons.OK, MessageBoxIcon.Information );

                if ( this.guiAutoClose.Checked ) {
                    this.Close( );
                }
            }
        }

        ProjectItem[ ] getItemsToBuild( Project project ) {
            List<ProjectItem> items = new List<ProjectItem>( );

            foreach ( ProjectItem item in project.Items ) {
                if ( item.Build ) {
                    switch ( item.FileContentType ) {
                        case ProjectItem.ContentType.Font:
                            if ( Settings.Default.buildFonts ) {
                                items.Add( item );
                            }
                            break;
                        case ProjectItem.ContentType.Model:
                        case ProjectItem.ContentType.StudioModel:
                        case ProjectItem.ContentType.GameModel:
                            if ( Settings.Default.buildModels ) {
                                items.Add( item );
                            }
                            break;
                        case ProjectItem.ContentType.Texture:
                            if ( Settings.Default.buildTextures ) {
                                items.Add( item );
                            }
                            break;
                        case ProjectItem.ContentType.Shader:
                            if ( Settings.Default.buildShaders ) {
                                items.Add( item );
                            }
                            break;
                        case ProjectItem.ContentType.Sound:
                            if ( Settings.Default.buildSounds ) {
                                items.Add( item );
                            }
                            break;
                    }
                }
            }

            return items.ToArray( );
        }

        void buildItem( ProjectItem item ) {
            if ( item.Build ) {
                if ( item.FileContentType == ProjectItem.ContentType.Shader ) {
                    this.put( "[SHA] " + item.FileAsset );
                    bool done = this.useTool( this.sha, true, "/fx", item.FileAsset );

                    this.guiProgress.Increment( 1 );
                    this.filesBuilt++;

                    if ( done ) {
                        this.put( "[SHA] Build OK." );
                    } else {
                        this.put( "[SHA] Build ERROR!" );
                        this.errors++;
                    }
                } else {
                    this.put( "[XNB] " + item.FileAsset );
                    bool done = this.useTool( this.xnb, true,
                        "/source", item.FileAsset,
                        "/type", item.FileContentType.ToString( ).ToUpper( ),
                        "/profile", item.Profile.ToString( ).ToUpper( ) );

                    this.guiProgress.Increment( 1 );
                    this.filesBuilt++;

                    if ( done ) {
                        this.put( "[XNB] Build OK." );
                    } else {
                        this.put( "[XNB] Build ERROR!" );
                        this.errors++;
                    }
                }
            }
        }

        bool useTool( string tool, bool wait = true, params string[ ] arguments ) {
            string args = string.Empty;

            for ( int i = 0; i < arguments.Length; i++ ) {
                args += ( arguments[ i ] + " " );
            }
            args.Remove( 0, 1 );

            ProcessStartInfo startInfo = new ProcessStartInfo( ) {
                FileName = tool,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = args
            };

            Process proc = Process.Start( startInfo );

            if ( wait ) {
                proc.WaitForExit( );
                return true;
            }

            return false;
        }

        void put( string text ) {
            this.guiOutput.Items.Add( text );
        }
    }
}