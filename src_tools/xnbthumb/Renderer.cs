/* 
 * Renderer.cs
 * =====================================================================
 * FileName: Renderer.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Troya.GXI;

namespace Troya.Tools
{
    class Renderer
    {
        Control control;
        GraphicsDevice gDevice;
        GraphicsDeviceService gDeviceService;
        ContentManager content;

        RenderTarget2D renderTarget;

        public Renderer( int bufferWidth, int bufferHeight, int msaa = 8 ) {
            this.control = new Control( );

            ServiceContainer services = new ServiceContainer( );
            this.gDeviceService = GraphicsDeviceService.AddInstance( this.control.Handle, bufferWidth, bufferHeight, msaa );
            services.AddService<IGraphicsDeviceService>( this.gDeviceService );

            this.gDevice = this.gDeviceService.GraphicsDevice;
            this.content = new ContentManager( services, @".\content" );

            this.renderTarget = new RenderTarget2D( 
                this.gDevice, 
                bufferWidth, 
                bufferHeight, 
                false, 
                this.gDevice.PresentationParameters.BackBufferFormat, 
                this.gDevice.PresentationParameters.DepthStencilFormat, 
                msaa, 
                RenderTargetUsage.DiscardContents );
        }

        public RenderTarget2D RenderToTarget2D( string contentDirectory, string xnbPath ) {
            this.content.RootDirectory = contentDirectory;

            /*
            string exePath = Application.ExecutablePath;
            string exeFileName = Path.GetFileName( exePath );
            string exeDir = exePath.Replace( exeFileName, string.Empty );
            string modelPath = xnbPath.Replace( exePath, string.Empty ).Replace( ".xnb", string.Empty );*/

            string modelPath = xnbPath.Replace( ".xnb", string.Empty );

            Model model = this.content.Load<Model>( modelPath );
            Matrix[ ] boneTransforms = new Matrix[ model.Bones.Count ];
            model.CopyAbsoluteBoneTransformsTo( boneTransforms );

            Vector4 modelCenterRadius = this.measureModel( model, boneTransforms );
            this.render( model, boneTransforms, modelCenterRadius );

            return this.renderTarget;
        }
        public void Dispose( ) {
            this.renderTarget = null;
            this.gDeviceService.Dispose( true );
            this.gDevice.Dispose( );

            GC.SuppressFinalize( this );
        }


        Vector4 measureModel( Model model, Matrix[ ] boneTransforms ) {
            Vector3 modelCenter = Vector3.Zero;
            float modelRadius = 0f;

            foreach ( ModelMesh mesh in model.Meshes ) {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[ mesh.ParentBone.Index ];
                Vector3 meshCenter = Vector3.Transform( meshBounds.Center, transform );

                modelCenter += meshCenter;
            }

            modelCenter /= model.Meshes.Count;
            modelCenter = new Vector3( modelCenter.X - 16f, modelCenter.Y, modelCenter.Z );

            foreach ( ModelMesh mesh in model.Meshes ) {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[ mesh.ParentBone.Index ];
                Vector3 meshCenter = Vector3.Transform( meshBounds.Center, transform );

                float transformScale = transform.Forward.Length( );
                float meshRadius = ( ( meshCenter - modelCenter ).Length( ) + ( meshBounds.Radius * transformScale ) );

                modelRadius = Math.Max( modelRadius, meshRadius );
            }

            return new Vector4( modelCenter, modelRadius );
        }
        void render( Model model, Matrix[ ] boneTransforms, Vector4 modelCenterRadius ) {
            Vector3 modelCenter = new Vector3( modelCenterRadius.X, modelCenterRadius.Y, modelCenterRadius.Z );

            Vector3 camPos = modelCenter;
            camPos.Z += ( modelCenterRadius.W * 2f );
            camPos.Y += modelCenterRadius.W;

            float nearPlane = ( modelCenterRadius.W / 100f );
            float farPlane = ( modelCenterRadius.W * 100f );

            Matrix transform = Matrix.CreateRotationY( MathHelper.ToRadians( 45f ) );
            Matrix view = Matrix.CreateLookAt( camPos, modelCenter, Vector3.Up );
            Matrix projection = Matrix.CreatePerspectiveFieldOfView( 1f, this.gDevice.Viewport.AspectRatio, nearPlane, farPlane );

            this.gDevice.SetRenderTarget( this.renderTarget );
            //this.gDevice.Clear( new Color( 255, 255, 255, 0 ) );
            this.gDevice.Clear( new Color( 150, 150, 150, 255 ) );

            foreach ( ModelMesh mesh in model.Meshes ) {
                foreach ( BasicEffect effect in mesh.Effects ) {
                    effect.World = ( boneTransforms[ mesh.ParentBone.Index ] * transform );
                    effect.View = view;
                    effect.Projection = projection;

                    effect.PreferPerPixelLighting = true;
                    effect.SpecularPower = 15;
                    effect.DiffuseColor = Color.Gray.ToVector3( );
                    effect.AmbientLightColor = Color.Gray.ToVector3( );
                    effect.EnableDefaultLighting( );
                }

                mesh.Draw( );
            }

            this.gDevice.SetRenderTarget( null );
        }
    }
}