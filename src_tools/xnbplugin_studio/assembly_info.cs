/* 
 * AssemblyInfo
 * =====================================================================
 * FileName: assembly_info.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 *
 * Troya Engine - Studio Model Processor Plugin
 */

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle( "xnbplugin_studio" )]
[assembly: AssemblyDescription( "Troya Engine" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "David Kutnar" )]
[assembly: AssemblyProduct( "StudioModelProcessor" )]
[assembly: AssemblyCopyright( "Copyright © David Kutnar 2018" )]
[assembly: AssemblyTrademark( "Tryoa Engine" )]
[assembly: AssemblyCulture( "" )]
[assembly: ComVisible( !AssemblyInfo.Obfuscate )]
[assembly: Guid( "33f6c5bd-2537-40ef-a726-2e167a159541" )]
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