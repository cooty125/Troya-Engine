/* 
 * Constants
 * ===============================================================
 * FileName: constants.cs
 * ---------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * ===============================================================
 * 
 * Troya Engine - Common Library
 */

namespace Troya
{
    public static class Constants
    {
        public const float PI                           = 3.141592f;
        public const float EPSILON                      = 1e-20F;
        public const float EULER                        = 0.577215f;

        public const int INT_SIZE                       = ( sizeof( int ) );
        public const int DOUBLE_SIZE                    = ( sizeof( double ) );
        public const int FLOAT_SIZE                     = ( sizeof( float ) );
        public const int BYTE_SIZE                      = ( sizeof( byte ) );
        public const int V3_SIZE                        = ( FLOAT_SIZE * 3 );
        public const int V2_SIZE                        = ( FLOAT_SIZE * 2 );
        public const int COLOR_SIZE                     = ( BYTE_SIZE * 4 );
    }
}