/* 
 * EffectImporter.cs
 * =====================================================================
 * FileName: EffectImporter.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace xnbplugin_game
{
    [ContentImporter( ".fx", DisplayName = "EffectImporter", CacheImportedData = true, DefaultProcessor = "EffectProcessor" )]
    public class EffectImporter : ContentImporter<EffectContent>
    {
        public override EffectContent Import( string filename, ContentImporterContext context ) {
            EffectContent effect = new EffectContent( );
            effect.Name = Path.GetFileNameWithoutExtension( filename );
            effect.EffectCode = File.ReadAllText( filename );

            return effect;
        }
    }
}