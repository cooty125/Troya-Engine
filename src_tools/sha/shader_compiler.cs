/* 
 * ShaderCompiler
 * =====================================================================
 * FileName: shader_compiler.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Graphics;

namespace Troya.Tools
{
    public static class ShaderCompiler
    {
        public static bool CompileToFile( string inFileName, string outFileName ) {
            byte[ ] bytes = ReadBytesFromSourceFile( inFileName );

            if ( bytes.Length > 0 ) {
                File.WriteAllBytes( outFileName, bytes );
                return true;
            }

            return false;
        }
        public static byte[ ] ReadBytesFromCompiledFile( string fileName ) {
            return File.ReadAllBytes( fileName );
        }
        public static byte[ ] ReadBytesFromSourceFile( string fileName ) {
            EffectImporter importer = new EffectImporter( );
            EffectProcessor processor = new EffectProcessor( );

            EffectContent content = importer.Import( fileName, new ShaderImporterContext( ) );
            CompiledEffectContent compiled = processor.Process( content, new ShaderProcessorContext( ) );

            return compiled.GetEffectCode( );
        }
    }
}