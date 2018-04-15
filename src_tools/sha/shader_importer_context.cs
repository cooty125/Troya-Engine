/* 
 * ShaderImporterContext
 * =====================================================================
 * FileName: shader_importer_context.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using Microsoft.Xna.Framework.Content.Pipeline;

namespace Troya.Tools
{
    internal class ShaderImporterContext : ContentImporterContext
    {
        public override ContentBuildLogger Logger {
            get { 
                return null; 
            }
        }
        public override string IntermediateDirectory {
            get {
                return string.Empty;
            }
        }
        public override string OutputDirectory {
            get {
                return string.Empty;
            }
        }


        public ShaderImporterContext( ) {

        }

        public override void AddDependency( string fileName ) {

        }
    }
}