/* 
 * GameModelProcessor.cs
 * =====================================================================
 * FileName: GameModelProcessor.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 * 
 * can be included by: xnb.exe (from same directory)
 */

using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace xnbplugin_game
{
    [ContentProcessor( DisplayName = "GameModelProcessor" )]
    public class GameModelProcessor : ModelProcessor
    {
        const string DATA_DIR = "xnbplugin_data";

        // Maxon Cinema 4D Material Keys:
        const string C4D_DMAP = "Texture";
        const string C4D_NMAP = "Reflection";
        const string C4D_SMAP = "Specular";
        const string C4D_EMAP = "Emissive";

        const string KEY_DMAP = "DiffuseMap";
        const string KEY_NMAP = "NormalMap";
        const string KEY_SMAP = "SpecularMap";
        const string KEY_EMAP = "EmissiveMap";


        public override ModelContent Process( NodeContent input, ContentProcessorContext context ) {
            this.GenerateMipmaps = false;
            this.GenerateTangentFrames = true;

            MeshHelper.TransformScene( input, input.AbsoluteTransform );
            input.Transform = Matrix.Identity;

            return base.Process( input, context );
        }

        protected override MaterialContent ConvertMaterial( MaterialContent material, ContentProcessorContext context ) {
            OpaqueDataDictionary pparams = new OpaqueDataDictionary( );
            pparams[ "ColorKeyEnabled" ] = false;
            pparams[ "GenerateMipmaps" ] = this.GenerateMipmaps;
            pparams[ "TextureFormat" ] = this.TextureFormat;
            pparams[ "ResizeTexturesToPowerOfTwo" ] = this.ResizeTexturesToPowerOfTwo;
            pparams[ "PremultiplyTextureAlpha" ] = false;

            string exePath = Application.ExecutablePath;
            string appDir = exePath.Replace( Path.GetFileName( exePath ), string.Empty );
            string shaderPath = Path.Combine( appDir, DATA_DIR + @"\game.fx" );

            EffectMaterialContent vixenMaterial = new EffectMaterialContent( );
            vixenMaterial.Effect = new ExternalReference<EffectContent>( shaderPath );
            vixenMaterial.CompiledEffect = context.BuildAsset<EffectContent, CompiledEffectContent>( vixenMaterial.Effect, "EffectProcessor" );

            foreach ( KeyValuePair<string, ExternalReference<TextureContent>> texture in material.Textures ) {
                switch ( texture.Key ) {
                    case C4D_DMAP:
                        vixenMaterial.Textures.Add( KEY_DMAP, texture.Value );
                        break;
                    case C4D_NMAP:
                        vixenMaterial.Textures.Add( KEY_NMAP, texture.Value );
                        break;
                    case C4D_SMAP:
                        vixenMaterial.Textures.Add( KEY_SMAP, texture.Value );
                        break;
                    case C4D_EMAP:
                        vixenMaterial.Textures.Add( KEY_EMAP, texture.Value );
                        break;
                }
            }

            if ( !vixenMaterial.Textures.ContainsKey( KEY_DMAP ) ) {
                vixenMaterial.Textures[ KEY_DMAP ] = new ExternalReference<TextureContent>( Path.Combine( appDir, DATA_DIR + @"\dmap.tga" ) );
            }
            if ( !vixenMaterial.Textures.ContainsKey( KEY_NMAP ) ) {
                vixenMaterial.Textures[ KEY_DMAP ] = new ExternalReference<TextureContent>( Path.Combine( appDir, DATA_DIR + @"\nmap.tga" ) );
            }
            if ( !vixenMaterial.Textures.ContainsKey( KEY_SMAP ) ) {
                vixenMaterial.Textures[ KEY_DMAP ] = new ExternalReference<TextureContent>( Path.Combine( appDir, DATA_DIR + @"\smap.tga" ) );
            }
            if ( !vixenMaterial.Textures.ContainsKey( KEY_EMAP ) ) {
                vixenMaterial.Textures[ KEY_DMAP ] = new ExternalReference<TextureContent>( Path.Combine( appDir, DATA_DIR + @"\emap.tga" ) );
            }

            return context.Convert<MaterialContent, MaterialContent>( vixenMaterial, typeof( MaterialProcessor ).Name, pparams );
        }
    }
}
