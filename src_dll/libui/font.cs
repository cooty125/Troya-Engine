/* 
 * Font
 * =====================================================================
 * FileName: font.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Troya.GUI
{
    public class Font
    {
        char[ ] charset;
        List<Rectangle> charsBounds;

        public string Name { get; private set; }
        public int Size { get; private set; }
        public int Spacing { get; set; }
        
        public Texture2D CharSetTexture { get; private set; }


        public Font( ) {
            this.charset = Charset.GetDefaultCharset( );
            this.charsBounds = new List<Rectangle>( );
        }

        public Rectangle GetCharBounds( char character ) {
            if ( this.charsBounds.Count > 0 ) {
                int index = Array.IndexOf( this.charset, character );

                if ( index < this.charsBounds.Count ) {
                    return this.charsBounds[ index ];
                }
            }
            return Rectangle.Empty;
        }


        internal void setName( string name ) {
            this.Name = name;
        }
        internal void setSize( int size ) {
            this.Size = size;
        }
        internal void setCharSetTexture( Texture2D charsetTex ) {
            this.CharSetTexture = charsetTex;
        }
        internal void setCharSetBounds( List<Rectangle> charsetBounds ) {
            this.charsBounds = charsetBounds;
        }
    }
}