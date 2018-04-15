/* 
 * ShaderCompiler Utility
 * =====================================================================
 * FileName: sha.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using Troya.Tools;

internal static class SHA
{
    private const int MSG_NOP       = 0x0;
    private const int MSG_SUCCESS   = 0x1;
    private const int MSG_ERROR     = 0x9;

    [STAThread]
    internal static int Main( string[ ] args ) {
        int argCount = args.Length;

        string sourceEffectFile = string.Empty;
        string outputDirectory = string.Empty;

        Console.Title = "Troya Engine - Shader Compiler";
        print( " Troya Engine - Shader Compiler v" + AssemblyInfo.Version );

        if ( argCount > 1 ) {
            for ( int i = 0; i < argCount; i++ ) {
                string arg = args[ i ];
                string val = string.Empty;

                if ( i + 1 < argCount ) {
                    val = args[ i + 1 ];
                }

                switch ( arg ) {
                    // Input effect file:
                    case "/fx":
                        if ( val.EndsWith( ".fx" ) ) {
                            if ( File.Exists( val ) ) {
                                sourceEffectFile = Path.GetFullPath( val );
                            } else {
                                print( "Error: File does not exists! " + val, true );
                                return MSG_ERROR;
                            }
                        } else {
                            print( val );
                            print( "Error: File format does not supported! Supported format is: *.fx", true );
                            return MSG_ERROR;
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

            if ( !string.IsNullOrEmpty( sourceEffectFile ) ) {
                string outputFile = Path.GetFileNameWithoutExtension( sourceEffectFile ) + ".sha";

                if ( string.IsNullOrEmpty( outputDirectory ) ) {
                    string filePath = Path.GetFullPath( sourceEffectFile );
                    string fileName = Path.GetFileName( sourceEffectFile );
                    string path = filePath.Replace( fileName, string.Empty );

                    outputDirectory = Path.GetFullPath( path );
                }

                print( " Source File: " + sourceEffectFile );
                print( " Output File: " + outputFile );
                print( " Destination: " + outputDirectory );

                try {
                    string outPath = Path.Combine( outputDirectory, outputFile );
                    ShaderCompiler.CompileToFile( sourceEffectFile, outPath );

                    print( "Shader compiled!\r\n" );
                    Console.ReadKey( );
                    return MSG_SUCCESS;
                } catch ( Exception ex ) {
                    print( ex.Message, true );
                    return MSG_ERROR;
                }
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

        Console.WriteLine( "[ sha ] " + str );

        if ( error ) {
            Console.ForegroundColor = prevColor;
        }
    }
}