/* 
 * ContentBuilder Utility
 * =====================================================================
 * FileName: xnb.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Vixen.Tools;

internal static class XNB
{
    const int MSG_NOP = 0x0;
    const int MSG_SUCCESS = 0x1;
    const int MSG_ERROR = 0x9;

    [STAThread]
    internal static int Main( string[ ] args ) {
        int argCount = args.Length;

        string inputFileName = string.Empty;
        string outputDirectory = string.Empty;
        string importerName = null;
        string processorName = string.Empty;
        string contentType = string.Empty;
        GraphicsProfile graphicsProfile = GraphicsProfile.HiDef;

        print( " Troya Engine - DirectX Binary Content Builder v" + AssemblyInfo.Version );
        string[ ] plugins = getAvailableXNBPlugins( );

        if ( argCount > 1 ) {
            for ( int i = 0; i < argCount; i++ ) {
                string arg = args[ i ];
                string val = string.Empty;

                if ( i + 1 < argCount ) {
                    val = args[ i + 1 ];
                }

                switch ( arg ) {
                    // Source file:
                    case "/source":
                        inputFileName = val;
                        break;
                    // Content type:
                    case "/type":
                        contentType = val.ToUpper( );
                        break;
                    // Profile:
                    case "/profile":
                        switch ( val.ToUpper( ) ) {
                            case "HIDEF":
                                graphicsProfile = GraphicsProfile.HiDef;
                                break;
                            case "REACH":
                                graphicsProfile = GraphicsProfile.Reach;
                                break;
                        }
                        break;
                    // Output directory:
                    case "/outdir":
                        string dirPath = Path.GetFullPath( val );

                        if ( !Directory.Exists( dirPath ) ) {
                            Directory.CreateDirectory( dirPath );
                        }

                        outputDirectory = dirPath;
                        break;
                }
            }

            if ( !string.IsNullOrEmpty( inputFileName ) && !string.IsNullOrEmpty( contentType ) ) {
                string contentSourceFile = string.Empty;

                switch ( contentType ) {
                    case "MODEL":
                        if ( inputFileName.EndsWith( ".fbx" ) || inputFileName.EndsWith( ".x" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "ModelProcessor";
                        } else if ( inputFileName.EndsWith( ".obj" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            importerName = "ObjModelImporter";
                            processorName = "ModelProcessor";
                        } else {
                            print( "Error: File format does not supported! Supported formats are: *.fbx *.x *.obj", true );
                            return MSG_ERROR;
                        }
                        break;
                    case "STUDIOMODEL":
                        if ( inputFileName.EndsWith( ".fbx" ) || inputFileName.EndsWith( ".x" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "StudioModelProcessor";
                        } else if ( inputFileName.EndsWith( ".obj" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            importerName = "ObjModelImporter";
                            processorName = "StudioModelProcessor";
                        } else {
                            print( "Error: File format does not supported! Supported formats are: *.fbx *.x *.obj", true );
                            return MSG_ERROR;
                        }
                        break;
                    case "GAMEMODEL":
                        if ( inputFileName.EndsWith( ".fbx" ) || inputFileName.EndsWith( ".x" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "GameModelProcessor";
                        } else if ( inputFileName.EndsWith( ".obj" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            importerName = "ObjModelImporter";
                            processorName = "GameModelProcessor";
                        } else {
                            print( "Error: File format does not supported! Supported formats are: *.fbx *.x *.obj", true );
                            return MSG_ERROR;
                        }
                        break;
                    case "TEXTURE":
                        if ( inputFileName.EndsWith( ".bmp" ) ||
                            inputFileName.EndsWith( ".dds" ) ||
                            inputFileName.EndsWith( ".dib" ) ||
                            inputFileName.EndsWith( ".hdr" ) ||
                            inputFileName.EndsWith( ".jpg" ) ||
                            inputFileName.EndsWith( ".pfm" ) ||
                            inputFileName.EndsWith( ".png" ) ||
                            inputFileName.EndsWith( ".ppm" ) ||
                            inputFileName.EndsWith( ".tga" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "TextureProcessor";
                        } else {
                            print( "Error: File format does not supported! Supported formats are: *.bmp *.dds *.dib *.hdr *.jpg *.pfm *.png *.ppm *.tga", true );
                            return MSG_ERROR;
                        }
                        break;
                    case "FONT":
                        if ( inputFileName.EndsWith( ".bmp" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "FontTextureProcessor";
                        } else if ( inputFileName.EndsWith( ".spritefont" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "FontDescriptionProcessor";
                        } else {
                            print( "Error: File format does not supported! Supported formats are: *.bmp *.spritefont", true );
                            return MSG_ERROR;
                        }
                        break;
                    case "SOUND":
                        if ( inputFileName.EndsWith( ".wav" ) ) {
                            contentSourceFile = Path.GetFullPath( inputFileName );
                            processorName = "SoundEffectProcessor";
                        } else {
                            print( "Error: File format does not supported! Supported formats are: *.wav", true );
                            return MSG_ERROR;
                        }
                        break;
                }

                if ( !File.Exists( contentSourceFile ) ) {
                    print( "Error: File does not exists! " + contentSourceFile, true );
                    return MSG_ERROR;
                }

                string outputFile = ( Path.GetFileNameWithoutExtension( contentSourceFile ) + ".xnb" );

                if ( string.IsNullOrEmpty( outputDirectory ) ) {
                    string filePath = Path.GetFullPath( contentSourceFile );
                    string fileName = Path.GetFileName( contentSourceFile );
                    string path = filePath.Replace( fileName, string.Empty );

                    outputDirectory = Path.GetFullPath( path );
                }

                print( " Source File: " + contentSourceFile );
                print( " Output File: " + outputFile );
                print( " Destination: " + outputDirectory );
                print( "  Content Type: " + contentType );
                print( "  Profile: " + graphicsProfile );
                if ( importerName != null ) {
                    print( "  Importer: " + importerName );
                }
                print( "  Processor: " + processorName );

                try {
                    ContentBuilder builder = new ContentBuilder( );
                    builder.GraphicsProfile = graphicsProfile;

                    for ( int i = 0; i < plugins.Length; i++ ) {
                        builder.RegisterAssembly( plugins[ i ], true );
                    }

                    builder.Create( );
                    builder.AddItem( contentSourceFile, Path.GetFileNameWithoutExtension( contentSourceFile ), importerName, processorName );
                    bool result = builder.Build( outputDirectory );

                    if ( result ) {
                        if ( processorName == "GameModelProcessor" ) {
                            // Erase autogenerated "log" file [game_0.xnb]:
                            File.Delete( Path.Combine( outputDirectory, "game_0.xnb" ) );
                        }

                        print( "Content built!\r\n" );
                        return MSG_SUCCESS;
                    }

                    print( "Error:", true );
                    print( builder.ErrorLogger.Errors.ToArray( ), true, true );
                    return MSG_ERROR;
                } catch ( Exception ex ) {
                    print( ex.Message );
                    return MSG_ERROR;
                }
            } else {
                print( "Error: Missing arguments. Check README.txt\r\n", true );
                return MSG_ERROR;
            }
        }

        return MSG_NOP;
    }

    static string[ ] getAvailableXNBPlugins( ) {
        string exePath = Application.ExecutablePath.ToString( );
        string pluginsDir = exePath.Replace( Path.GetFileName( exePath ), string.Empty );

        List<string> pluginFileNames = new List<string>( );

        foreach ( string file in Directory.GetFiles( pluginsDir ) ) {
            string fileName = Path.GetFileName( file );

            if ( fileName.StartsWith( "xnbplugin_" ) && fileName.EndsWith( ".dll" ) ) {
                pluginFileNames.Add( file );
                print( "+ Plugin found: " + fileName );
            }
        }

        return pluginFileNames.ToArray( );
    }

    static void print( string str, bool error = false ) {
        ConsoleColor prevColor = Console.ForegroundColor;
        if ( error ) {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine( "[ xnb ] " + str );

        if ( error ) {
            Console.ForegroundColor = prevColor;
        }
    }
    static void print( string[ ] strs, bool inline, bool error = false ) {
        string output = string.Empty;

        foreach ( string item in strs ) {
            if ( inline ) {
                output += item;
            } else {
                print( item, error );
            }
        }

        if ( inline ) {
            print( output, error );
        }
    }
}