/* 
 * AssemblyInfo
 * =====================================================================
 * FileName: assembly_info.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 *
 * Troya Engine - Content Manager
 */

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle( "contentman" )]
[assembly: AssemblyDescription( "Troya Engine" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "David Kutnar" )]
[assembly: AssemblyProduct( "Content Manager" )]
[assembly: AssemblyCopyright( "Copyright © David Kutnar 2018" )]
[assembly: AssemblyTrademark( "Troya Engine" )]
[assembly: AssemblyCulture( "" )]
[assembly: ComVisible( !AssemblyInfo.Obfuscate )]
[assembly: Guid( "4636944b-26cd-409b-9465-92d6e55f6d8b" )]
[assembly: AssemblyVersion( AssemblyInfo.Version )]
[assembly: AssemblyFileVersion( AssemblyInfo.Version )]
[assembly: NeutralResourcesLanguageAttribute( "en" )]
[assembly: ObfuscateAssembly( AssemblyInfo.Obfuscate )]

internal static class AssemblyInfo
{
    internal const string Version = "1.0.2.0";
    internal const string Build = "1504";
    internal const bool Obfuscate = true;
}