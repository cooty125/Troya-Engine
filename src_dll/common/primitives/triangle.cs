/* 
 * Triangle
 * ===============================================================
 * FileName: triangle.cs
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
    public struct Triangle : IEquatable<Triangle>
    {
        public Vector3 PointA;
        public Vector3 PointB;
        public Vector3 PointC;


        public Triangle( Vector3 pointA, Vector3 pointB, Vector3 pointC ) {
            this.PointA = pointA;
            this.PointB = pointB;
            this.PointC = pointC;
        }

        public void Transform( Matrix transform ) {
            this.PointA = Vector3.Transform( this.PointA, transform );
            this.PointB = Vector3.Transform( this.PointB, transform );
            this.PointC = Vector3.Transform( this.PointC, transform );
        }
        public float? Intersects( ref Ray ray ) {
            Vector3 edge1 = Vector3.Subtract( this.PointB, this.PointA );
            Vector3 edge2 = Vector3.Subtract( this.PointC, this.PointA );

            Vector3 directionCrossEdge2;
            Vector3.Cross( ref ray.Direction, ref edge2, out directionCrossEdge2 );
            float determinant;
            Vector3.Dot( ref edge1, ref directionCrossEdge2, out determinant );

            if ( determinant > -float.Epsilon && determinant < float.Epsilon ) {
                return null;
            }

            float inverseDeterminant = ( 1.0f / determinant );
            Vector3 distanceVector = Vector3.Subtract( ray.Position, this.PointA );

            float triangleU;
            Vector3.Dot( ref distanceVector, ref directionCrossEdge2, out triangleU );
            triangleU *= inverseDeterminant;

            if ( triangleU < 0 || triangleU > 1 ) {
                return null;
            }

            Vector3 distanceCrossEdge1;
            Vector3.Cross( ref distanceVector, ref edge1, out distanceCrossEdge1 );

            float triangleV;
            Vector3.Dot( ref ray.Direction, ref distanceCrossEdge1, out triangleV );
            triangleV *= inverseDeterminant;

            if ( triangleV < 0 || triangleU + triangleV > 1 ) {
                return null;
            }

            float rayDistance;
            Vector3.Dot( ref edge2, ref distanceCrossEdge1, out rayDistance );
            rayDistance *= inverseDeterminant;

            if ( rayDistance < 0 ) {
                return null;
            }

            return rayDistance;
        }
        public bool Equals( Triangle other ) {
            return ( ( this.PointA == other.PointA ) && ( this.PointB == other.PointB ) && ( this.PointC == other.PointC ) );
        }
        public override bool Equals( object obj ) {
            if ( obj != null && obj.GetType( ) == typeof( Triangle ) ) {
                return this.Equals( ( Triangle )obj );
            }

            return false;
        }
        public static bool operator ==( Triangle a, Triangle b ) {
            return Equals( a, b );
        }
        public static bool operator !=( Triangle a, Triangle b ) {
            return !Equals( a, b );
        }
        public override int GetHashCode( ) {
            return ( this.PointA.GetHashCode( ) ^ this.PointB.GetHashCode( ) ^ this.PointC.GetHashCode( ) );
        }
    }
}