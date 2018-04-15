/* 
 * StudioModelProcessor.cs
 * =====================================================================
 * FileName: StudioModelProcessor.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 * 
 * can be included by: xnb.exe (from same directory)
 */

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace xnbplugin_studio
{
    [ContentProcessor( DisplayName = "StudioModelProcessor" )]
    public class StudioModelProcessor : ModelProcessor
    {
        List<Vector3> vertices = new List<Vector3>( );


        public override ModelContent Process( NodeContent input, ContentProcessorContext context ) {
            this.GenerateMipmaps = true;
            this.GenerateTangentFrames = false;

            MeshHelper.TransformScene( input, input.AbsoluteTransform );
            input.Transform = Matrix.Identity;

            this.findVertices( input, false );

            ModelContent model = base.Process( input, context );

            Dictionary<string, object> tagData = new Dictionary<string, object>( );
            tagData.Add( "Name", model.Root.Name );
            tagData.Add( "Vertices", vertices.ToArray( ) );
            tagData.Add( "Transform", input.AbsoluteTransform );
            tagData.Add( "BoundingSphere", BoundingSphere.CreateFromPoints( this.vertices ) );
            tagData.Add( "BoundingBox", BoundingBox.CreateFromPoints( this.vertices ) );

            model.Tag = tagData;

            return model;
        }

        void findVertices( NodeContent node, bool transformEachVertex ) {
            MeshContent mesh = ( node as MeshContent );

            if ( mesh != null ) {
                Matrix absoluteTransform = mesh.AbsoluteTransform;

                foreach ( GeometryContent geometry in mesh.Geometry ) {
                    foreach ( int index in geometry.Indices ) {
                        Vector3 vertex = geometry.Vertices.Positions[ index ];
                        if ( transformEachVertex ) {
                            vertex = Vector3.Transform( vertex, absoluteTransform );
                        }

                        this.vertices.Add( vertex );
                    }
                }
            }

            foreach ( NodeContent child in node.Children ) {
                this.findVertices( child, transformEachVertex );
            }
        }
    }
}
