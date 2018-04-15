/* 
 * FontCharset
 * =====================================================================
 * FileName: charset.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;

namespace Troya.GUI
{
    internal static class Charset
    {
        // Default 128 bit charset
        // !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~
        public static char[ ] GetDefaultCharset( ) {
            char[ ] charset = new char[ 128 ];

            int i = 0;
            for ( char ch = ( char )0x20; ch < 0x7F; ch++ ) {
                charset[ i ] = ch;
                i++;
            }

            return charset;
        }
        public static char[ ] GetCharset( uint length ) {
            char[ ] charset = new char[ length ];

            int i = 0;
            for ( char ch = ( char )0x20; ch < length - 0x20; ch++ ) {
                charset[ i ] = ch;
                i++;
            }

            return charset;
        }
    }
}