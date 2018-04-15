/* 
 * XNBBuilder
 * =====================================================================
 * FileName: xnb_builder.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System.IO;

namespace Vixen.Tools
{
    public static class XNBBuilder
    {
        public static void BuildModel( string fileName, string outputDirectory ) {
            BuildCustomItem( fileName, outputDirectory, null, "ModelProcessor" );
        }
        public static void BuildTexture( string fileName, string outputDirectory ) {
            BuildCustomItem( fileName, outputDirectory, null, "TextureProcessor" );
        }
        public static void BuildSpriteFont( string fileName, string outputDirectory ) {
            BuildCustomItem( fileName, outputDirectory, null, "FontDescriptionProcessor" );
        }
        public static void BuildSpriteFontTexture( string fileName, string outputDirectory ) {
            BuildCustomItem( fileName, outputDirectory, null, "FontTextureProcessor" );
        }
        public static void BuildSoundEffectTexture( string fileName, string outputDirectory ) {
            BuildCustomItem( fileName, outputDirectory, null, "SoundEffectProcessor" );
        }

        public static void BuildCustomItem( string fileName, string outputDirectory, string importer, string processor ) {
            string name = Path.GetFileNameWithoutExtension( fileName );

            ContentBuilder builder = new ContentBuilder( );
            builder.AddItem( fileName, name, importer, processor );
            builder.Build( outputDirectory );
            builder.Dispose( );
        }
    }
}