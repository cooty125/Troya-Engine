/* 
 * AssemblyInfo
 * =====================================================================
 * FileName: assembly_info.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 *
 * Troya Engine - Shader Compiler Utility
 * Version: 2.6
 */

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle( "sha" )]
[assembly: AssemblyDescription( "Troya Engine" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "David Kutnar" )]
[assembly: AssemblyProduct( "SHA" )]
[assembly: AssemblyCopyright( "Copyright © David Kutnar 2018" )]
[assembly: AssemblyTrademark( "Troya Engine" )]
[assembly: AssemblyCulture( "" )]
[assembly: ComVisible( !AssemblyInfo.Obfuscate )]
[assembly: Guid( "b054caf1-a125-4aa5-ac99-e977c93625e5" )]
[assembly: AssemblyVersion( AssemblyInfo.Version )]
[assembly: AssemblyFileVersion( AssemblyInfo.Version )]
[assembly: NeutralResourcesLanguageAttribute( "en" )]
[assembly: ObfuscateAssembly( AssemblyInfo.Obfuscate )]


internal static class AssemblyInfo
{
    internal const string Version = "2.6.0.0";
    internal const string Build = "0204";
    internal const bool Obfuscate = true;
}