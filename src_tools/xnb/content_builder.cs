/* 
 * ContentBuilder
 * ===============================================================
 * FileName: content_builder.cs
 * ---------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * ===============================================================
 */

using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Vixen.Tools
{
    public class ContentBuilder : IDisposable
    {
        List<string> assemblies = new List<string>( );

        ErrorLogger errLogger;
        Project buildProject;
        ProjectRootElement projectRootElement;
        BuildParameters buildParameters;
        List<ProjectItem> projectItems = new List<ProjectItem>();
        string processDirectory;
        GraphicsProfile graphicsProfile = GraphicsProfile.Reach;
        string targetName = string.Empty;
        bool isDisposed = false;

        public ErrorLogger ErrorLogger {
            get { return this.errLogger; }
        }
        public GraphicsProfile GraphicsProfile {
            get { return this.graphicsProfile; }
            set { this.graphicsProfile = value; }
        }


        public ContentBuilder( ) {
            this.assemblies.Add( "Microsoft.Xna.Framework.Content.Pipeline.FBXImporter, Version=4.0.0.0, PublicKeyToken=842cf8be1de50553" );
            this.assemblies.Add( "Microsoft.Xna.Framework.Content.Pipeline.XImporter, Version=4.0.0.0, PublicKeyToken=842cf8be1de50553" );
            this.assemblies.Add( "Microsoft.Xna.Framework.Content.Pipeline.TextureImporter, Version=4.0.0.0, PublicKeyToken=842cf8be1de50553" );
        }
        ~ContentBuilder( ) {
            this.Dispose( false );
        }

        public void RegisterAssembly( string fileName, bool directPath ) {
            string appPath = Path.GetDirectoryName( Application.ExecutablePath );

            if ( directPath ) {
                this.assemblies.Add( fileName );
            } else {
                this.assemblies.Add( Path.Combine( appPath, fileName ) );
            }
        }
        public void Create( ) {
            this.createTempDirectory( );
            this.createProject( );
        }
        public void AddItem( string fileName, string name, string importer, string processor ) {
            ProjectItem item = this.buildProject.AddItem( "Compile", fileName )[ 0 ];
            item.SetMetadataValue( "Link", Path.GetFileName( fileName ) );
            item.SetMetadataValue( "Name", name );

            if ( !string.IsNullOrEmpty( importer ) ) {
                item.SetMetadataValue( "Importer", importer );
            }

            if ( !string.IsNullOrEmpty( processor ) ) {
                item.SetMetadataValue( "Processor", processor );
            }

            this.projectItems.Add( item );
        }
        public void ClearItems( ) {
            this.buildProject.RemoveItems( projectItems );
            this.projectItems.Clear( );
        }
        public bool Build( string outPath ) {
            BuildManager.DefaultBuildManager.BeginBuild( buildParameters );
            BuildRequestData request = new BuildRequestData( buildProject.CreateProjectInstance( ), new string[ 0 ]);
            BuildSubmission submission = BuildManager.DefaultBuildManager.PendBuildRequest( request ); 
            submission.ExecuteAsync( null, null );
            submission.WaitHandle.WaitOne( );
            BuildManager.DefaultBuildManager.EndBuild( );

            if ( submission.BuildResult.OverallResult == BuildResultCode.Failure ) {
                return false;
            }

            this.copyBuiltContent( outPath );
            Thread.Sleep( 250 );
            this.deleteTempDirectory( );
            return true;
        }
        public void Dispose( ) {
            this.Dispose( true );
            GC.SuppressFinalize( this );
        }
        protected virtual void Dispose( bool disposing ) {
            if ( !this.isDisposed ) {
                this.isDisposed = true;
            }
        }


        void createTempDirectory( ) {
            int processId = Process.GetCurrentProcess( ).Id;
            this.processDirectory = Path.Combine( Path.GetTempPath( ), GetType( ).FullName );

            Directory.CreateDirectory( processDirectory );
        }
        void deleteTempDirectory( ) {
            string dirPath = Path.Combine( Path.GetTempPath( ), "Vixen.Tools.ContentBuilder" );

            if ( Directory.GetDirectories( this.processDirectory ).Length != 0 ) {
                Directory.Delete( this.processDirectory, true );
            }
        }
        void copyBuiltContent( string destinationDir ) {
            string path = Path.Combine( this.processDirectory, "content" );

            foreach ( string file in Directory.GetFiles( path  ) ) {
                string filePath = Path.Combine( destinationDir, Path.GetFileName( file ) );
                File.Copy( file, filePath, true );
            }
        }
        void createProject( ) {
            string buildDirectory = Path.GetFullPath( this.processDirectory );
            string projectPath = Path.Combine( buildDirectory, "content.contentproj" );

            this.projectRootElement = ProjectRootElement.Create( projectPath + new Random( ).Next( 0, 100 ).ToString( ) );
            this.projectRootElement.AddImport( "$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\v4.0\\Microsoft.Xna.GameStudio.ContentPipeline.targets" );

            this.buildProject = new Project( this.projectRootElement );
            this.buildProject.SetProperty( "XnaPlatform", "Windows" );

            if ( graphicsProfile == GraphicsProfile.HiDef ) {
                this.buildProject.SetProperty( "XnaProfile", "HiDef" );
            } else {
                this.buildProject.SetProperty( "XnaProfile", "Reach" );
            }

            this.buildProject.SetProperty( "XnaFrameworkVersion", "v4.0" );
            this.buildProject.SetProperty( "Configuration", "Release" );
            this.buildProject.SetProperty( "OutputPath", this.processDirectory );

            foreach ( string pipelineAssembly in this.assemblies.ToArray( ) ) {
                this.buildProject.AddItem( "Reference", pipelineAssembly );
            }

            this.errLogger = new ErrorLogger( );

            this.buildParameters = new BuildParameters( ProjectCollection.GlobalProjectCollection );
            this.buildParameters.Loggers = new ILogger[ ] { this.errLogger };
        }
    }
}