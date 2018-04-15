/* 
 * Line
 * ===============================================================
 * FileName: line.cs
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
    public struct Line : IEquatable<Line>
    {
        public Vector3 Start;
        public Vector3 End;


        public Line( Vector3 start, Vector3 end ) {
            this.Start = start;
            this.End = end;
        }

        public void Transform( Matrix transform ) {
            this.Start = Vector3.Transform( this.Start, transform );
            this.End = Vector3.Transform( this.End, transform );
        }
        public bool Equals( Line other ) {
            return ( ( this.Start == other.Start ) && ( this.End == other.End ) );
        }
        public override bool Equals( object obj ) {
            if ( obj != null && obj.GetType( ) == typeof( Line ) ) {
                return this.Equals( ( Line )obj );
            }

            return false;
        }
        public static bool operator ==( Line a, Line b ) {
            return Equals( a, b );
        }
        public static bool operator !=( Line a, Line b ) {
            return !Equals( a, b );
        }
        public override int GetHashCode( ) {
            return ( this.Start.GetHashCode( ) ^ this.End.GetHashCode( ) );
        }
    }
}