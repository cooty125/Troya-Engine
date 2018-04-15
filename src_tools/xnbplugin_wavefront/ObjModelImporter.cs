/* 
 * ObjModelImporter.cs
 * =====================================================================
 * FileName: ObjModelImporter.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 * 
 * can be included by: xnb.exe (from same directory)
 */

using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace xnbplugin_wavefront
{
    [ContentImporter( ".obj", DisplayName = "ObjModelImporter", CacheImportedData = true, DefaultProcessor = "ModelProcessor" )]
    public class ObjModelImporter : ContentImporter<NodeContent>
    {
        ContentImporterContext importerContext;

        NodeContent rootNode;
        List<Vector3> positions;
        List<Vector2> texCoords;
        List<Vector3> normals;

        MeshBuilder meshBuilder;
        int[ ] positionMap;

        int textureCoordinateDataIndex;
        int normalDataIndex;

        Dictionary<String, MaterialContent> materials;
        ContentIdentity mtlFileIdentity;
        BasicMaterialContent materialContent;


        public override NodeContent Import( string filename, ContentImporterContext context ) {
            importerContext = context;

            rootNode = new NodeContent( );
            positions = new List<Vector3>( );
            texCoords = new List<Vector2>( );
            normals = new List<Vector3>( );
            materials = new Dictionary<string, MaterialContent>( );

            meshBuilder = null;
            rootNode.Identity = new ContentIdentity( filename );

            try {
                foreach ( String[ ] lineTokens in getLineTokens( filename, rootNode.Identity ) ) {
                    this.parseObjLine( lineTokens );
                }

                if ( rootNode.Name == null ) {
                    rootNode.Name = Path.GetFileNameWithoutExtension( filename );
                }

                this.finishMesh( );

                return rootNode;
            } catch ( InvalidContentException ) {
                throw;
            } catch ( Exception e ) {
                throw new InvalidContentException( "Unable to parse obj file. Error:\n" + e.Message, rootNode.Identity, e );
            }
        }


        void parseObjLine( string[ ] lineTokens ) {
            switch ( lineTokens[ 0 ].ToLower( ) ) {
                case "o":
                    rootNode.Name = lineTokens[ 1 ];
                    break;
                case "v":
                    positions.Add( parseVector3( lineTokens ) );
                    break;
                case "vt": {
                        Vector2 vt = parseVector2( lineTokens );
                        vt.Y = 1 - vt.Y;

                        texCoords.Add( vt );
                        break;
                    }
                case "vn":
                    normals.Add( parseVector3( lineTokens ) );
                    break;
                case "g":
                    if ( meshBuilder != null ) {
                        this.finishMesh( );
                    }

                    if ( lineTokens.Length > 1 ) {
                        this.startMesh( lineTokens[ 1 ] );
                    } else {
                        this.startMesh( null );
                    }
                    break;
                case "s":
                    break;
                case "f":
                    if ( lineTokens.Length > 4 ) {
                        importerContext.Logger.LogWarning( null, rootNode.Identity, "N-sided polygons are not supported! Ignoring vertex." );
                        break;
                    }
                    
                    if ( meshBuilder == null ) {
                        this.startMesh( null );
                    }

                    for ( int vertexIndex = 1; vertexIndex <= 3; vertexIndex++ ) {
                        string[ ] indices = lineTokens[ vertexIndex ].Split( '/' );
                        int positionIndex = int.Parse( indices[ 0 ], CultureInfo.InvariantCulture ) - 1;

                        if ( indices.Length > 1 ) {
                            int texCoordIndex;
                            Vector2 texCoord;

                            if ( int.TryParse( indices[ 1 ], out texCoordIndex ) ) {
                                texCoord = texCoords[ texCoordIndex - 1 ];
                            } else {
                                texCoord = Vector2.Zero;
                            }

                            meshBuilder.SetVertexChannelData( textureCoordinateDataIndex, texCoord );
                        }

                        if ( indices.Length > 2 ) {
                            int normalIndex;
                            Vector3 normal;

                            if ( int.TryParse( indices[ 2 ], out normalIndex ) ) {
                                normal = normals[ normalIndex - 1 ];
                            } else {
                                normal = Vector3.Zero;
                            }

                            meshBuilder.SetVertexChannelData( normalDataIndex, normal );
                        }

                        meshBuilder.AddTriangleVertex( positionMap[ positionIndex ] );
                    }
                    break;
                case "mtllib":
                    for ( int i = 1; i < lineTokens.Length; i++ ) {
                        string mtlFileName = lineTokens[ i ];

                        if ( !Path.IsPathRooted( mtlFileName ) ) {
                            string directory = Path.GetDirectoryName( rootNode.Identity.SourceFilename );
                            mtlFileName = Path.GetFullPath( Path.Combine( directory, mtlFileName ) );
                        }

                        importerContext.AddDependency( mtlFileName );

                        this.importMaterials( mtlFileName );
                    }
                    break;
                case "usemtl": {
                        if ( meshBuilder == null ) {
                            this.startMesh( null );
                        }

                        string materialName = lineTokens[ 1 ];
                        MaterialContent material;

                        if ( materials.TryGetValue( materialName, out material ) ) {
                            meshBuilder.SetMaterial( material );
                        } else {
                            throw new InvalidContentException( String.Format( "Material '{0}' is not defined.", materialName ), rootNode.Identity );
                        }

                        break;
                    }

                default:
                    throw new InvalidContentException( "Unsupported or invalid line type '" + lineTokens[ 0 ] + "'", rootNode.Identity );
            }
        }

        void startMesh( string name ) {
            meshBuilder = MeshBuilder.StartMesh( name );
            meshBuilder.SwapWindingOrder = true;

            textureCoordinateDataIndex = meshBuilder.CreateVertexChannel<Vector2>( VertexChannelNames.TextureCoordinate( 0 ) );
            normalDataIndex = meshBuilder.CreateVertexChannel<Vector3>( VertexChannelNames.Normal( ) );
            positionMap = new int[ positions.Count ];

            for ( int i = 0; i < positions.Count; i++ ) {
                positionMap[ i ] = meshBuilder.CreatePosition( positions[ i ] );
            }
        }
        void finishMesh( ) {
            MeshContent meshContent = meshBuilder.FinishMesh( );

            if ( meshContent.Geometry.Count > 0 ) {
                rootNode.Children.Add( meshContent );
            } else {
                NodeContent nodeContent = new NodeContent( );
                nodeContent.Name = meshContent.Name;

                rootNode.Children.Add( nodeContent );
            }

            meshBuilder = null;
        }

        void importMaterials( string filename ) {
            mtlFileIdentity = new ContentIdentity( filename );
            materialContent = null;

            try {
                foreach ( String[ ] lineTokens in
                    getLineTokens( filename, mtlFileIdentity ) ) {
                    this.parseMtlLine( lineTokens );
                }
            } catch ( InvalidContentException ) {
                throw;
            } catch ( Exception e ) {
                throw new InvalidContentException( "Unable to parse mtl file. Error:\n" + e.Message, mtlFileIdentity, e );
            }

            if ( materialContent != null ) {
                materials.Add( materialContent.Name, materialContent );
            }
        }
        void parseMtlLine( string[ ] lineTokens ) {
            switch ( lineTokens[ 0 ].ToLower( ) ) {
                case "newmtl":
                    if ( materialContent != null ) {
                        materials.Add( materialContent.Name, materialContent );
                    }

                    materialContent = new BasicMaterialContent( );
                    materialContent.Identity = new ContentIdentity( mtlFileIdentity.SourceFilename );
                    materialContent.Name = lineTokens[ 1 ];
                    break;
                case "kd":
                    materialContent.DiffuseColor = parseVector3( lineTokens );
                    break;
                case "map_kd":
                    materialContent.Texture = new ExternalReference<TextureContent>( lineTokens[ 1 ], mtlFileIdentity );
                    break;
                case "ka":
                    break;
                case "ks":
                    materialContent.SpecularColor = parseVector3( lineTokens );
                    break;
                case "ns":
                    materialContent.SpecularPower = float.Parse( lineTokens[ 1 ], CultureInfo.InvariantCulture );
                    break;
                case "ke":
                    materialContent.EmissiveColor = parseVector3( lineTokens );
                    break;
                case "d":
                    materialContent.Alpha = float.Parse( lineTokens[ 1 ], CultureInfo.InvariantCulture );
                    break;
                case "illum":
                    materialContent.OpaqueData.Add( "Illumination mode", int.Parse( lineTokens[ 1 ], CultureInfo.InvariantCulture ) );
                    break;

                default:
                    throw new InvalidContentException( "Unsupported or invalid line type '" + lineTokens[ 0 ] + "'", mtlFileIdentity );
            }
        }

        static IEnumerable<string[ ]> getLineTokens( string filename, ContentIdentity identity ) {
            using ( StreamReader reader = new StreamReader( filename ) ) {
                int lineNumber = 1;

                while ( !reader.EndOfStream ) {
                    identity.FragmentIdentifier = lineNumber.ToString( );

                    string[ ] lineTokens = Regex.Split( reader.ReadLine( ).Trim( ), @"\s+" );

                    if ( lineTokens.Length > 0 && lineTokens[ 0 ] != String.Empty && !lineTokens[ 0 ].StartsWith( "#" ) ) {
                        yield return lineTokens;
                    }

                    lineNumber++;
                }

                identity.FragmentIdentifier = null;
            }
        }

        static Vector2 parseVector2( string[ ] lineTokens ) {
            return new Vector2(
                float.Parse( lineTokens[ 1 ], CultureInfo.InvariantCulture ),
                float.Parse( lineTokens[ 2 ], CultureInfo.InvariantCulture ) );
        }
        static Vector3 parseVector3( string[ ] lineTokens ) {
            return new Vector3(
                float.Parse( lineTokens[ 1 ], CultureInfo.InvariantCulture ),
                float.Parse( lineTokens[ 2 ], CultureInfo.InvariantCulture ),
                float.Parse( lineTokens[ 3 ], CultureInfo.InvariantCulture ) );
        }
    }
}
