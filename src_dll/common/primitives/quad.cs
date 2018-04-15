/* 
 * Quad
 * ===============================================================
 * FileName: quad.cs
 * ---------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * ===============================================================
 * 
 * Troya Engine - Common Library
 */

using System;
using Microsoft.Xna.Framework;

namespace Troya
{
    public struct Quad : IEquatable<Quad>
    {
        public Vector3 LeftTop;
        public Vector3 LeftBottom;
        public Vector3 RightTop;
        public Vector3 RightBottom;

        public Quad( Vector3 point, float width, float height, bool twoDim = false ) {
            this.LeftTop = point;
            this.LeftBottom = new Vector3( point.X, point.Y + height, point.Z );
            this.RightTop = new Vector3( point.X + width, point.Y, point.Z );
            this.RightBottom = new Vector3( point.X + width, point.Y + height, point.Z );

            if ( twoDim ) {
                this.LeftBottom = new Vector3( point.X, point.Y, point.Z + height );
                this.RightTop = new Vector3( point.X + width, point.Y, point.Z );
                this.RightBottom = new Vector3( point.X + width, point.Y, point.Z + height );
            }
        }
        public Quad( Vector3 leftTop, Vector3 leftBottom, Vector3 rightTop, Vector3 rightBottom ) {
            this.LeftTop = leftTop;
            this.LeftBottom = leftBottom;
            this.RightTop = rightTop;
            this.RightBottom = rightBottom;
        }

        public void Transform( Matrix transform ) {
            this.LeftTop = Vector3.Transform( this.LeftTop, transform );
            this.LeftBottom = Vector3.Transform( this.LeftBottom, transform );
            this.RightTop = Vector3.Transform( this.RightTop, transform );
            this.RightBottom = Vector3.Transform( this.RightBottom, transform );
        }
        public bool Equals( Quad other ) {
            return ( ( this.LeftTop == other.LeftTop ) && ( this.LeftBottom == other.LeftBottom ) && ( this.RightTop == other.RightTop ) && ( this.RightBottom == other.RightBottom ) );
        }
        public override bool Equals( object obj ) {
            if ( obj != null && obj.GetType( ) == typeof( Quad ) ) {
                return this.Equals( ( Quad )obj );
            }

            return false;
        }
        public static bool operator ==( Quad a, Quad b ) {
            return Equals( a, b );
        }
        public static bool operator !=( Quad a, Quad b ) {
            return !Equals( a, b );
        }
        public override int GetHashCode( ) {
            return ( this.LeftTop.GetHashCode( ) ^ this.LeftBottom.GetHashCode( ) ^ this.RightTop.GetHashCode( ) ^ this.RightBottom.GetHashCode( ) );
        }
    }
}