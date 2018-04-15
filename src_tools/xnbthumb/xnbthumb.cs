/* 
 * XNBThumbnail
 * ===============================================================
 * FileName: xnathumb.cs
 * ---------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2017 - All rights reserved.
 * ===============================================================
 */

using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Troya.Tools;

internal static class XNBThumbnail
{
    const int MSG_NOP = 0x0;
    const int MSG_SUCCESS = 0x1;
    const int MSG_ERROR = 0x9;

    [STAThread]
    internal static int Main( string[ ] args ) {
        int argCount = args.Length;

        string sourceFile = string.Empty;
        string outputDirectory = string.Empty;
        string contentDirectory = @".\";
        int thumbnailSize = 512;

        print( " Troya Engine - Thumbnail Utility v" + AssemblyInfo.Version );

        if ( argCount > 1 ) {
            for ( int i = 0; i < argCount; i++ ) {
                string arg = args[ i ];
                string val = string.Empty;

                if ( i + 1 < argCount ) {
                    val = args[ i + 1 ];
                }

                switch ( arg ) {
                    // Input XNB file:
                    case "/xnb":
                        if ( val.EndsWith( ".xnb" ) ) {
                            if ( File.Exists( val ) ) {
                                sourceFile = Path.GetFullPath( val );
                            } else {
                                print( "Error: File does not exists! " + val, true );
                                return MSG_ERROR;
                            }
                        } else {
                            print( "Error: File format does not supported! Supported format is: *.xnb", true );
                            return MSG_ERROR;
                        }
                        break;
                    case "/content":
                        contentDirectory = val;
                        break;
                    // Thumbnail size:
                    case "/size":
                        int.TryParse( val, out thumbnailSize );

                        if ( thumbnailSize > 2048 ) {
                            thumbnailSize = 2048;
                        } else if ( thumbnailSize < 32 ) {
                            thumbnailSize = 32;
                        }
                        break;
                    // Output directory:
                    case "/out":
                        string dirPath = Path.GetFullPath( val );

                        if ( !Directory.Exists( dirPath ) ) {
                            Directory.CreateDirectory( dirPath );
                        }

                        outputDirectory = dirPath;
                        break;
                }
            }

            if ( !string.IsNullOrEmpty( sourceFile ) ) {
                string outputFile = ( Path.GetFileNameWithoutExtension( sourceFile ) + ".png" );

                if ( string.IsNullOrEmpty( outputDirectory ) ) {
                    string filePath = Path.GetFullPath( sourceFile );
                    string fileName = Path.GetFileName( sourceFile );
                    string path = filePath.Replace( fileName, string.Empty );

                    outputDirectory = Path.GetFullPath( path );
                }

                print( " Size: " + thumbnailSize.ToString( ) + " x " + thumbnailSize.ToString( ) );
                print( " Source File: " + sourceFile );
                print( " Output File: " + outputFile );
                print( " Destination: " + outputDirectory );

                try {
                    Renderer renderer = new Renderer( thumbnailSize, thumbnailSize );
                    RenderTarget2D target = renderer.RenderToTarget2D( contentDirectory, sourceFile );

                    target.SaveAsPng( File.Create( Path.Combine( outputDirectory, outputFile ) ), thumbnailSize, thumbnailSize );
                } catch ( Exception ex ) {
                    print( ex.Message, true );
                    return MSG_ERROR;
                }

                print( "Thumbnail created!\r\n" );
                return MSG_SUCCESS;
            } else {
                print( "Error: Missing arguments. Check README.txt\r\n", true );
                return MSG_ERROR;
            }
        }

        return MSG_NOP;
    }

    static void print( string str, bool error = false ) {
        ConsoleColor prevColor = Console.ForegroundColor;
        if ( error ) {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine( "[ xnbthumb ] " + str );

        if ( error ) {
            Console.ForegroundColor = prevColor;
        }
    }
}