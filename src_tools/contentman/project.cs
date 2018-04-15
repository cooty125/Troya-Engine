/* 
 * Content Project
 * =====================================================================
 * FileName: item.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace Troya.Tools
{
    public class Project
    {
        string fileName;
        string contentDirectory;
        List<ProjectItem> items;

        public string FileName {
            get { return this.fileName; }
        }
        public string ContentDirectory {
            get { return this.contentDirectory; }
            set { this.contentDirectory = value; }
        }
        public ProjectItem[ ] Items {
            get { return this.items.ToArray( ); }
        }

        public Project( ) {
            this.items = new List<ProjectItem>( );
        }

        public void Open( string fileName ) {
            if ( File.Exists( fileName ) && fileName.EndsWith( ".conp" ) ) {
                this.fileName = fileName;
                this.items.Clear( );

                StreamReader reader = new StreamReader( this.fileName );
                this.contentDirectory = reader.ReadLine( );

                while ( !reader.EndOfStream ) {
                    string line = reader.ReadLine( );
                    string[ ] parts = line.Split( new char[ ] { ';' } );

                    ProjectItem.ContentType type = ProjectItem.ContentType.Font;
                    switch ( parts[ 1 ].ToUpper( ) ) {
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
                    switch ( parts[ 3 ].ToUpper( ) ) {
                        case "REACH":
                            profile = ProjectItem.GDProfile.Reach;
                            break;
                        default:
                            profile = ProjectItem.GDProfile.HiDef;
                            break;
                    }

                    this.items.Add( new ProjectItem( parts[ 0 ], type, bool.Parse( parts[ 2 ] ), profile ) );
                }

                reader.Close( );
            }
        }

        public void Save( ) {
            StreamWriter writer = new StreamWriter( this.fileName );
            writer.WriteLine( this.contentDirectory );

            foreach ( ProjectItem item in this.items ) {
                writer.WriteLine( item.FileAsset + ";" + item.FileContentType.ToString( ) + ";" + item.Build.ToString( ) + ";" + item.Profile.ToString( ) );
            }

            writer.Close( );
        }

        public void SaveAs( string fileName ) {
            this.fileName = fileName;
            this.Save( );
        }

        public bool AddItem( ProjectItem item ) {
            if ( !itemExists( item ) ) {
                this.items.Add( item );
                return true;
            }

            return false;
        }

        public bool RemoveItem( int itemID ) {
            if ( itemID < this.items.Count ) {
                this.items.RemoveAt( itemID );
                return true;
            }

            return false;
        }

        public void UpdateItem( int itemID, ProjectItem item ) {
            if ( itemID > this.items.Count ) {
                this.items[ itemID ] = item;
            }
        }

        bool itemExists( ProjectItem item ) {
            foreach ( ProjectItem i in this.items ) {
                if ( i.FileAsset == item.FileAsset && i.FileContentType == item.FileContentType ) {
                    return true;
                }
            }

            return false;
        }
    }
}