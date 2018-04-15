/* 
 * AssemblyInfo
 * =====================================================================
 * FileName: assembly_info.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 *
 * Troya Engine - Wavefront (*.obj) Model Importer Plugin
 */

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle( "xnbplugin_wavefront" )]
[assembly: AssemblyDescription( "Troya Engine" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "David Kutnar" )]
[assembly: AssemblyProduct( "ObjModelImporter" )]
[assembly: AssemblyCopyright( "Copyright © David Kutnar 2018" )]
[assembly: AssemblyTrademark( "Troya Engine" )]
[assembly: AssemblyCulture( "" )]
[assembly: ComVisible( false )]
[assembly: Guid( "2b88c1cf-4903-4e53-a2a2-bed6f08590df" )]
[assembly: AssemblyVersion( AssemblyInfo.Version )]
[assembly: AssemblyFileVersion( AssemblyInfo.Version )]
[assembly: NeutralResourcesLanguageAttribute( "en" )]
[assembly: ObfuscateAssembly( AssemblyInfo.Obfuscate )]

internal static class AssemblyInfo
{
    internal const string Version   = "1.2.0.0";
    internal const string Build     = "0204";
    internal const bool Obfuscate   = true;
}