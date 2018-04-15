/* 
 * EulerHelper
 * =====================================================================
 * FileName: euler_heler.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 * 
 * Troya Engine - Common Library
 */

using System;
using Microsoft.Xna.Framework;

namespace Troya
{
    public class EulerHelper
    {
        public static Quaternion XYZToQuaternion( Vector3 xyz ) {
            float xcos = ( float )Math.Cos( xyz.X / 2 );
            float xsin = ( float )Math.Sin( xyz.X / 2 );
            float ycos = ( float )Math.Cos( xyz.Y / 2 );
            float ysin = ( float )Math.Sin( xyz.Y / 2 );
            float zcos = ( float )Math.Cos( xyz.Z / 2 );
            float zsin = ( float )Math.Sin( xyz.Z / 2 );

            return new Quaternion(
                xsin * ycos * zcos - xcos * ysin * zsin,
                xcos * ysin * zcos + xsin * ycos * zsin,
                xcos * ycos * zsin - xsin * ysin * zcos,
                xcos * ycos * zcos + xsin * ysin * zsin );
        }
        public static Vector3 QuaternionToXYZ( Quaternion q ) {
            double a2 = 2 * ( q.W * q.Y - q.X * q.Z );
            float x, y;
            if ( a2 <= -0.99999 ) {
                x = 2 * ( float )Math.Atan2( q.X, q.W );
                y = -( float )Math.PI / 2;
                return new Vector3(
                    x,
                    y,
                    0 );
            } else if ( a2 >= 0.99999 ) {
                x = 2 * ( float )Math.Atan2( q.X, q.W );
                y = ( float )Math.PI / 2;
                return new Vector3(
                    x,
                    y,
                    0 );
            } else
                y = ( float )Math.Asin( a2 );

            return new Vector3(
                ( float )Math.Atan2( 2 * ( q.W * q.X + q.Y * q.Z ), ( 1 - 2 * ( q.X * q.X + q.Y * q.Y ) ) ),
                y,
                ( float )Math.Atan2( 2 * ( q.W * q.Z + q.X * q.Y ), ( 1 - 2 * ( q.Y * q.Y + q.Z * q.Z ) ) ) );
        }
    }
}
