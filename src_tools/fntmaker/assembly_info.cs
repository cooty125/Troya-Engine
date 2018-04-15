/* 
 * AssemblyInfo
 * =====================================================================
 * FileName: assembly_info.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 *
 * Troya Engine - Font Maker Utility
 */

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: AssemblyTitle( "fntmaker" )]
[assembly: AssemblyDescription( "Troya Engine" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "David Kutnar" )]
[assembly: AssemblyProduct( "Font Maker Utility" )]
[assembly: AssemblyCopyright( "Copyright © David Kutnar 2018" )]
[assembly: AssemblyTrademark( "Troya Engine" )]
[assembly: AssemblyCulture( "" )]
[assembly: ComVisible( !AssemblyInfo.Obfuscate )]
[assembly: Guid( "dbeed9f0-bb33-472f-9968-5c9eadfe0a1c" )]
[assembly: AssemblyVersion( AssemblyInfo.Version )]
[assembly: AssemblyFileVersion( AssemblyInfo.Version )]
[assembly: NeutralResourcesLanguageAttribute( "en" )]
[assembly: ObfuscateAssembly( AssemblyInfo.Obfuscate )]

internal static class AssemblyInfo
{
    internal const string Version   = "1.1.0.0";
    internal const string Build     = "0204";
    internal const bool Obfuscate   = true;
}